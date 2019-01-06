using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FunWebApi.Data;
using FunWebApi.Dtos;
using FunWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FunWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository _repo, IConfiguration _config)
        {
            this._config = _config;
            this._repo = _repo;

        }
        [HttpPost("register")]

        public async Task<IActionResult> Register(UsersDto UsersDto)
        {

            UsersDto.username = UsersDto.username.ToLower(); // English version 

            if (await _repo.UserExist(UsersDto.username)) return BadRequest("Username already exists");


            var UserCreate = new User { Username = UsersDto.username };

            var user = await _repo.Register(UserCreate, UsersDto.password);

            return StatusCode(201);

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
               throw new Exception("aaa");
                var userRepo = await _repo.Login(userLoginDto.username, userLoginDto.password);
                if (userRepo == null) return Unauthorized();
                var claims = new[]
                {

             new Claim (ClaimTypes.NameIdentifier,userRepo.Id.ToString()),
             new Claim (ClaimTypes.Name,userRepo.Username)

             };

                var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
                var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(30),
                    SigningCredentials = creds
                };


                var tokenhandler = new JwtSecurityTokenHandler();

                var token = tokenhandler.CreateToken(tokenDescriptor);

                return Ok(new
                {
                    token = tokenhandler.WriteToken(token)

                });


         


        }
    }



}