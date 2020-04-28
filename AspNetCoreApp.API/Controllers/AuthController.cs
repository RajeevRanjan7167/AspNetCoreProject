using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreApp.API.Data;
using AspNetCoreApp.API.Dtos;
using AutoMapper;
using AspNetCoreApp.API.Helpers;
using AspNetCoreApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AspNetCoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
            _mapper = mapper;
            _config = config;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(ResourceForRegisterDTO resourceForRegisterDTO)
        {
            resourceForRegisterDTO.rm_Login_Id = resourceForRegisterDTO.rm_Login_Id.ToLower();

            if (await _repo.UserExists(resourceForRegisterDTO.rm_Login_Id))
                return BadRequest("Username already exists !!");

            var createToResource = _mapper.Map<ResourcesMST>(resourceForRegisterDTO);            
            var createdResource = await _repo.Register(createToResource, resourceForRegisterDTO.password);

            var resourceToReturn = _mapper.Map<ResourceForListDTO>(createdResource);

            return CreatedAtRoute("GetResource", new { Controller ="Resources", 
                id = createdResource.ID},resourceToReturn);
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userForRepo = await _repo.Login(userForLoginDto.rm_Login_Id.ToLower(), userForLoginDto.password);

            if (userForRepo == null)
                return Unauthorized();

            var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,userForRepo.ID.ToString()),
                    new Claim(ClaimTypes.Name, userForRepo.rm_Login_Id)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(TokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}