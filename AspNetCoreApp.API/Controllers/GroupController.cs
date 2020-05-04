using System;
using System.Threading.Tasks;
using AspNetCoreApp.API.Data;
using AspNetCoreApp.API.Dtos.groupDTO;
using AspNetCoreApp.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCoreApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _repo;
        private readonly IMapper _mapper;
        public GroupController(IGroupRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{Id}", Name = "getGroup")]
        [AllowAnonymous]
        public async Task<IActionResult> getGroup(int id)
        {
            var group = await _repo.GetGroup(id);
            var returnToGroup = _mapper.Map<groupForSelectDTO>(group);
            return Ok(returnToGroup);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> getGroups()
        {
            var groups = await _repo.GetGroups();
            var returnToGroups = _mapper.Map<IEnumerable<groupForSelectDTO>>(groups);
            return Ok(returnToGroups);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> updateGroup(int id, groupForUpdateDTO _groupForUpdateDTO)
        {
            var groupForRepo = await _repo.GetGroup(id);
            _mapper.Map(_groupForUpdateDTO, groupForRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save");
        }

        [HttpPost("generateGroup")]
        [AllowAnonymous]
        public async Task<IActionResult> generateGroup(groupForCreateDTO _groupForCreateDTO)
        {
            if (await _repo.UserExists(_groupForCreateDTO.group_Name))
                return BadRequest("Group name already exists !!");

            var createToGroup = _mapper.Map<Groups>(_groupForCreateDTO);
            var createdGroup = await _repo.GenerateGroup(createToGroup);

            var groupToReturn = _mapper.Map<groupForSelectDTO>(createdGroup);
            return CreatedAtRoute("getGroup", new
            {
                Controller = "Group",
                id = createdGroup.id
            }, groupToReturn);
        }
    }
}