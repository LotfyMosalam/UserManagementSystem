using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Models;
using UserManagement.Application.DTOs;
using UserManagement.Application.ServicesInterfaces;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateRequest request)
        {
            var user = await _userService.CreateUserAsync(new UserCreateDto
            {
                Username = request.Username,
                Password = request.Password,
                UserFullName = request.UserFullName,
                DateOfBirth = request.DateOfBirth,
                IsActive = request.IsActive
            });

            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserUpdateRequest request)
        {
            await _userService.UpdateUserAsync(new UserUpdateDto
            {
                Id = request.Id,
                Username = request.Username,
                Password = request.Password,
                UserFullName = request.UserFullName,
                DateOfBirth = request.DateOfBirth,
                IsActive = request.IsActive
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
