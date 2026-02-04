using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Models;
using UserManagement.Application.DTOs;
using UserManagement.Application.ServicesInterfaces;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _userService.LoginAsync(new LoginDto
            {
                Username = request.Username,
                Password = request.Password
            });

            return Ok(result);
        }
    }
}
