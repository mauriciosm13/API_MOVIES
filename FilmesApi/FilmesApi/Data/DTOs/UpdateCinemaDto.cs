using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOs
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O Campo nome é obrigatório!")]
        public string Name { get; set; }
    }
}
