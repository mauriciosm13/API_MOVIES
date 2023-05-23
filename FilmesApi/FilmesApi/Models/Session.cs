using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Session
    {
        [Key]
        [Required]
        public int Id { get; set; }

    }
}
