using TodoListApi.DTOs;
using TodoListApi.Models;

namespace TodoListApi.Interfeces
{
    public interface IAuthService
    {
        Task<UserRegisterDto> UserRegister(UserRegisterDto userDto);
        Task<UserLoginDto> UserLogin(UserLoginDto userDto);
        bool VerifyPasswordHash(string password, string storedHash);
    }
}
