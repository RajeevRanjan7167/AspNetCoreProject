using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApp.API.Data;
using AspNetCoreApp.API.Dtos;
using AspNetCoreApp.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using AspNetCoreApp.API.Helpers;

namespace AspNetCoreApp.API.Controllers
{
    //[ServiceFilter(typeof(logUserActivity))]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceRepository _repo;
        private readonly IMapper _mapper;
        public ResourcesController(IResourceRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetResoures()
        {
            var resoures = await _repo.GetResources();
            var resourceToReturn = _mapper.Map<IEnumerable<ResourceForListDTO>>(resoures);
            return Ok(resourceToReturn);
        }

        [HttpGet("{Id}", Name = "GetResource")]
        [AllowAnonymous]
        public async Task<IActionResult> GetResource(int Id)
        {
            var resource = await _repo.GetResource(Id);
            var resourceToReturn = _mapper.Map<ResourceForListDTO>(resource);
            return Ok(resourceToReturn);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> updateResource(int id, ResourceForUpdateDTO resourceForUpdateDTO)
        {
            //if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();

            var resourceForRepo = await _repo.GetResource(id);
            _mapper.Map(resourceForUpdateDTO, resourceForRepo);

            if(await _repo.SaveAll())
                return NoContent();
            
            throw new Exception($"Updating user {id} failed on save");            
        }
    }
}