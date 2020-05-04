using System;
using System.Threading.Tasks;
using AspNetCoreApp.API.Data;
using AspNetCoreApp.API.Dtos.cityDTO;
using AspNetCoreApp.API.Dtos.fieldDTO;
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
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _repo;
        private readonly IMapper _mapper;

        public CityController(ICityRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{Id}", Name = "getCity")]
        [AllowAnonymous]
        public async Task<IActionResult> getCity(int id)
        {
            var city = await _repo.GetCity(id);
            var returnToCity = _mapper.Map<cityForSelectDTO>(city);
            return Ok(returnToCity);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> getCities()
        {
            var cities = await _repo.GetCities();
            var returnToCities = _mapper.Map<IEnumerable<cityForSelectDTO>>(cities);
            return Ok(returnToCities);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> updateCity(int id, cityForUpdateDTO _cityForUpdateDTO)
        {
            var cityForRepo = await _repo.GetCity(id);
            _mapper.Map(_cityForUpdateDTO, cityForRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save");
        }

        [HttpPost("generateCity")]
        [AllowAnonymous]
        public async Task<IActionResult> generateCity(cityForCreateDTO _cityForCreateDTO)
        {
            if (await _repo.UserExists(_cityForCreateDTO.ct_Name))
                return BadRequest("City name already exists !!");

            var createToCity = _mapper.Map<city>(_cityForCreateDTO);
            var createdCity = await _repo.GenerateCity(createToCity);

            var cityToReturn = _mapper.Map<cityForSelectDTO>(createdCity);
            return CreatedAtRoute("getCity", new
            {
                Controller = "City",
                id = createdCity.id
            }, cityToReturn);
        }
    }
}