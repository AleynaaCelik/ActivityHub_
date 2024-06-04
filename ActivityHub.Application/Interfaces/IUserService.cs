using ActivityHub.Application.Dtos;
using ActivityHub.Application.DTOs;
using Microsoft.AspNetCore.Identity;

namespace ActivityHub.Application.Interfaces
{
    public interface IUserService
    {
        //Task AddUserAsync(CreateUserDto createUserDto);
        //Task<IEnumerable<UserDto>> GetAllUsersAsync();
        //Task<UserDto> GetUserByIdAsync(Guid id);

        //Task<SignInResult> AuthenticateUserAsync(LoginDto loginDto);

        Task<IdentityResult> AddUserAsync(CreateUserDto createUserDto);
        Task<SignInResult> AuthenticateUserAsync(LoginDto loginDto);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(Guid id);


    }
}
