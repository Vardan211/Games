using System.Threading.Tasks;
using Games.Domain.Interfaces;
using Games.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Games.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var result = await _userService.Login(request);

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationDto request)
        {
            var result = await _userService.Register(request);

            return Ok(result);
        }
    }
}
