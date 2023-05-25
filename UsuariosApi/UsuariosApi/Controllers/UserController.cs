using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.DTOs;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {

        private UserService _userService;

        public UserController(UserService usereService)
        {
            _userService = usereService;
        }

        [HttpPost("/CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {

            await _userService.CreateUser(dto);


            return Ok("Usuário cadastrado");
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> LoginAsync(LoginUserDto dto)
        {
            var token = await _userService.Login(dto);
            return Ok(token);
        }
    }
}
