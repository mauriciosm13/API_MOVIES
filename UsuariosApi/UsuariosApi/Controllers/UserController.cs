
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.DTOs;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateUser(CreateUserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
