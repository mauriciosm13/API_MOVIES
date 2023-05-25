using Microsoft.AspNetCore.Identity;

namespace UsuariosApi.Models
{
    public class User : IdentityUser
    {
        public DateTime DateBirth { get; set; }
        public User(): base() { }
    }
}
