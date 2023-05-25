﻿using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.DTOs
{
    public class LoginUserDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
