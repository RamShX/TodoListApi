using Microsoft.AspNetCore.Mvc;
using TodoListApi.DTOs;
using TodoListApi.Interfeces;
using TodoListApi.Models;

namespace TodoListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserRegisterDto registerDto) 
        {
            try
            {
                var user = await _authService.UserRegister(registerDto);
                var response = new
                {
                    Id = user.Id,
                    Email = user.Email
                };
                return Ok(new {message = $"Se ha registrado correctamente!!", data = response});
            }
            catch (Exception)
            {

                return BadRequest("Error al registrar el usuario");
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(UserLoginDto loginDto)
        {
            var user = await _authService.UserLogin(loginDto);
            if (user == null)
                return Unauthorized("Email o contraseña incorrectos");
           
            return Ok(new {message = $"Ha accedido!!", data = user});
        }


    }
}
