using System;
using System.Threading.Tasks;
using AspNetCoreApp.API.Data;
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
    public class FieldController : ControllerBase
    {
        private readonly IFieldRepository _repository;
        private readonly IMapper _mapper;

        public FieldController(IFieldRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{Id}", Name = "getFiled")]
        [AllowAnonymous]
        public async Task<IActionResult> getFiled(int id)
        {
            var field = await _repository.GetField(id);
            var returnTofield = _mapper.Map<fieldForSelectDTO>(field);
            return Ok(returnTofield);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> getFields()
        {
            var fields = await _repository.GetFields();
            var returnToFields = _mapper.Map<IEnumerable<fieldForSelectDTO>>(fields);
            return Ok(returnToFields);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> updateField(int id, fieldForUpdateDTO _fieldForUpdateDTO)
        {
            var fieldForRepo = await _repository.GetField(id);
            _mapper.Map(_fieldForUpdateDTO, fieldForRepo);

            if (await _repository.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save");
        }

        [HttpPost("generateField")]
        [AllowAnonymous]
        public async Task<IActionResult> generateField(filedForCreateDTO _filedForCreateDTO)
        {
            if (await _repository.UserExists(_filedForCreateDTO.fi_Name))
                return BadRequest("Field name already exists !!");

            var createToField = _mapper.Map<Fields>(_filedForCreateDTO);
            var createdField = await _repository.GenerateField(createToField);

            var fieldToReturn = _mapper.Map<fieldForSelectDTO>(createdField);
            return CreatedAtRoute("getFiled", new
            {
                Controller = "Field",
                id = createdField.id
            }, fieldToReturn);
        }
    }
}