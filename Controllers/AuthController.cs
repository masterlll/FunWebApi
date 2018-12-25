using System.Threading.Tasks;
using FunWebApi.Data;
using FunWebApi.Dtos;
using FunWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FunWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController :ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository _repo)
        {
            this._repo = _repo;

        }
        [HttpPost("register")]

    public async Task<IActionResult> Register(UsersDto UsersDto )
    {
        
      UsersDto.username =UsersDto.username.ToLower(); // English version 

        if (await _repo.UserExist(UsersDto.username))  return BadRequest("Username already exists");


        var UserCreate = new User{Username=UsersDto.username};

        var user =  await _repo.Register(UserCreate,UsersDto.password);

        return StatusCode(201) ;

    }
    }
}