﻿using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Campo nome é obrigatório!")]
        public string Name { get; set; }
        public int AddressId { get; set;}
        public virtual Address Address { get; set; }
        public virtual ICollection<Session> Sessions { get; set; } 
    }
}
