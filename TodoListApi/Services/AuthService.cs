using Microsoft.EntityFrameworkCore;
using TodoListApi.Context;
using TodoListApi.DTOs;
using TodoListApi.Interfeces;
using TodoListApi.Models;

namespace TodoListApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly TodoListContext _context;

        public AuthService(TodoListContext context)
        {
            _context = context;
        }

        public async Task<User> UserLogin(UserLoginDto userLoginDto)
        {

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == userLoginDto.Email.ToLower());

            if (user == null)
                return null;

            if (!VerifyPasswordHash(userLoginDto.Password, user.PasswordH))
                return null;

            return user;

        }

        public async Task<User> UserRegister(UserRegisterDto userRegisterDto)
        {
            if(await _context.Users.AnyAsync(u => u.Email.ToLower() == userRegisterDto.Email.ToLower())) 
            {
                throw new Exception("El correo ya existe.");
            }

            var user = new User
            {
                Email = userRegisterDto.Email,
                PasswordH = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password)
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return  user;
        }

        public bool VerifyPasswordHash(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
    }
}
