using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Register(string username,string password){
            //validate Request
            username = username.ToLower();
            if(await _repo.UserExists())
            
        }
    }
}