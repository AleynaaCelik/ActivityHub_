using ActivityHub.Application.Dtos;
using ActivityHub.Application.DTOs;
using ActivityHub.Application.Interfaces;
using ActivityHub.Domain.Entities;
using ActivityHub.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityHub.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<IdentityResult> AddUserAsync(CreateUserDto createUserDto)
        {
            var user = new User
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                Password = _passwordHasher.HashPassword(null, createUserDto.Password) // Hash the password
            };

            try
            {
                await _userRepository.AddAsync(user);
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return IdentityResult.Failed(new IdentityError { Description = ex.Message });
            }
        }

        public async Task<SignInResult> AuthenticateUserAsync(LoginDto loginDto)
        {
            var user = (await _userRepository.GetAllAsync())
                .FirstOrDefault(u => u.Email == loginDto.Email);

            if (user == null)
            {
                return SignInResult.Failed;
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginDto.Password);
            if (result == PasswordVerificationResult.Success)
            {
                return SignInResult.Success;
            }

            return SignInResult.Failed;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new UserDto
            {
                Id = Guid.Parse(user.Id), // Eğer user.Id string ise
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            });
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return new UserDto
            {
                Id = Guid.Parse(user.Id), // Eğer user.Id string ise
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }
    }
}
