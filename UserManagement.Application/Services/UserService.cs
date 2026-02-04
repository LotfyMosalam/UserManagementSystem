using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DTOs;
using UserManagement.Application.ServicesInterfaces;
using UserManagement.Domain.Entities;
using UserManagement.Domain.RepositoryInterfaces;

namespace UserManagement.Application.Services
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponseDto> CreateUserAsync(UserCreateDto dto)
        {
            ValidateUserCreate(dto);

            var existingUser = await _userRepository.GetByUsernameAsync(dto.Username);
            if (existingUser != null)
                throw new Exception("Username already exists");

            var user = new User(
                dto.Username,
                dto.Password,
                dto.UserFullName,
                dto.DateOfBirth,
                dto.IsActive);

            await _userRepository.AddAsync(user);

            return MapToResponse(user);
        }

        public async Task<List<UserResponseDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(MapToResponse).ToList();
        }

        public async Task<UserResponseDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id)
                ?? throw new Exception("User not found");

            return MapToResponse(user);
        }

        public async Task UpdateUserAsync(UserUpdateDto dto)
        {
            ValidateUserUpdate(dto);

            var user = await _userRepository.GetByIdAsync(dto.Id)
                ?? throw new Exception("User not found");

            user.Update(
                dto.Username,
                dto.Password,
                dto.UserFullName,
                dto.DateOfBirth,
                dto.IsActive);

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id)
                ?? throw new Exception("User not found");

            await _userRepository.DeleteAsync(user);
        }

        public async Task<UserResponseDto> LoginAsync(LoginDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
                throw new Exception("Username and password are required");

            var user = await _userRepository.GetByUsernameAsync(dto.Username)
                ?? throw new Exception("Invalid credentials");

            if (!user.IsActive)
                throw new Exception("User is inactive");

            if (user.Password != dto.Password)
                throw new Exception("Invalid credentials");

            return MapToResponse(user);
        }

        private static void ValidateUserCreate(UserCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username))
                throw new Exception("Username is required");

            if (string.IsNullOrWhiteSpace(dto.Password))
                throw new Exception("Password is required");

            if (string.IsNullOrWhiteSpace(dto.UserFullName))
                throw new Exception("Full name is required");
        }

        private static void ValidateUserUpdate(UserUpdateDto dto)
        {
            if (dto.Id <= 0)
                throw new Exception("Invalid user id");

            ValidateUserCreate(new UserCreateDto
            {
                Username = dto.Username,
                Password = dto.Password,
                UserFullName = dto.UserFullName,
                DateOfBirth = dto.DateOfBirth
            });
        }

        private static UserResponseDto MapToResponse(User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                UserFullName = user.UserFullName,
                IsActive = user.IsActive,
                DateOfBirth = user.DateOfBirth,
                CreationDate = user.CreationDate
            };
        }
    }

}