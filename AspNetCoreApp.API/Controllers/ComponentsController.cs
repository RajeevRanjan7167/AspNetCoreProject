using System;
using System.Threading.Tasks;
using AspNetCoreApp.API.Data;
using AspNetCoreApp.API.Dtos.componentDTO;
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
    public class ComponentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IComponentsRepository _repo;

        public ComponentsController(IComponentsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{Id}", Name = "getComponent")]
        [AllowAnonymous]
        public async Task<IActionResult> getComponent(int id)
        {
            var Component = await _repo.GetComponent(id);
            var returnToComponent = _mapper.Map<componentForSelectDTO>(Component);
            return Ok(returnToComponent);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> getComponents()
        {
            var Components = await _repo.GetComponents();
            var returnToComponents = _mapper.Map<IEnumerable<componentForSelectDTO>>(Components);
            return Ok(returnToComponents);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> updateGroup(int id, componentForUpdateDTO _componentForUpdateDTO)
        {
            var componentForRepo = await _repo.GetComponent(id);
            _mapper.Map(_componentForUpdateDTO, componentForRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save");
        }

        [HttpPost("generateGroup")]
        [AllowAnonymous]
        public async Task<IActionResult> GenerateComponent(componentForCreateDTO _componentForCreateDTO)
        {
            if (await _repo.UserExists(_componentForCreateDTO.com_Name))
                return BadRequest("Component name already exists !!");

            var createToComponent = _mapper.Map<components>(_componentForCreateDTO);
            var createdComponent = await _repo.GenerateComponent(createToComponent);

            var componentToReturn = _mapper.Map<componentForSelectDTO>(createdComponent);
            return CreatedAtRoute("getComponent", new
            {
                Controller = "Components",
                id = createdComponent.id
            }, componentToReturn);
        }
    }
}