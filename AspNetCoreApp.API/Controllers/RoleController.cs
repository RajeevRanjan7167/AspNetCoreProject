using System;
using System.Threading.Tasks;
using AspNetCoreApp.API.Data;
using AspNetCoreApp.API.Dtos.roleDTO;
using AspNetCoreApp.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _repo;
        private readonly IMapper _mapper;
        public RoleController(IRoleRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{Id}", Name ="getRole")]
        [AllowAnonymous]
        public async Task<IActionResult> getRole(int id)
        {
            var role = await _repo.GetRole(id);
            var roleToReturn = _mapper.Map<roleForListDTO>(role);
            return Ok(roleToReturn);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> getRoles()
        {
            var roles = await _repo.GetRoles();
            var rolesToReturn = _mapper.Map<roleForListDTO>(roles);
            return  Ok(rolesToReturn);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> updateRole(int id, roleForUpdateDTO _roleForUpdateDTO)
        {
            var roleForRepo = await _repo.GetRole(id);
            _mapper.Map(_roleForUpdateDTO , roleForRepo);
            
            if (await _repo.SaveAll())
                return NoContent();
            
            throw new Exception($"Updating user {id} failed on save");
        }

        [HttpPost("generateRole")]
        [AllowAnonymous]
        public async Task<IActionResult> generateRole(roleForCreateDTO _roleForCreateDTO)
        {
            if( await _repo.UserExists(_roleForCreateDTO.role_Name))
                return BadRequest("Role name already exists !!");
            
            var createToRole = _mapper.Map<Roles>(_roleForCreateDTO);
            var createdRole = await _repo.GenerateRole(createToRole);

            var roleToReturn = _mapper.Map<roleForListDTO>(createdRole);
             return CreatedAtRoute("getRole", new { Controller ="Role", 
                id = createdRole.id},roleToReturn);
        }

    }
}