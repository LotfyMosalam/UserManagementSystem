using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DTOs;

namespace UserManagement.Application.ServicesInterfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateUserAsync(UserCreateDto dto);
        Task<List<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto> GetUserByIdAsync(int id);
        Task UpdateUserAsync(UserUpdateDto dto);
        Task DeleteUserAsync(int id);
        Task<UserResponseDto> LoginAsync(LoginDto dto);
    }
}
