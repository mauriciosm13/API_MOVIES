using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }
}
