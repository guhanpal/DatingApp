using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            this._repo = repo;

        }

        [HttpPost]
        public async Task<IActionResult> Post(UserForRegisterDto userForRegisterDto)
        {
            //validate Request
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _repo.UserExists(userForRegisterDto.Username))
            return BadRequest("Username already exists");
            
            var userToCreate = new User{
                Username=userForRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreate,userForRegisterDto.Password);

            return StatusCode(201);

        }
    }
}