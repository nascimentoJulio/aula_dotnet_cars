using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volkswagen.Dashboard.Services.Auth;

namespace Volkswagen.Dashboard.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authService.Register(request);

            if (result)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.Login(request);

            return Ok(result);
        }

    }
}
