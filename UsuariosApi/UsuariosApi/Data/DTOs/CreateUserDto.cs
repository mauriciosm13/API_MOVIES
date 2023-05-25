using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.DTOs
{
    public class CreateUserDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string? DateBirth { get; set; }
        [Required]
        [Compare("Password")]
        public string? RePassword { get; set; }
    }
}
