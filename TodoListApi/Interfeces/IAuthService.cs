using TodoListApi.DTOs;
using TodoListApi.Models;

namespace TodoListApi.Interfeces
{
    public interface IAuthService
    {
        Task<User> UserRegister(UserRegisterDto userRegisterDto);
        Task<User>UserLogin(UserLoginDto userLoginDto);
        bool VerifyPasswordHash(string password, string storedHash);
    }
}
