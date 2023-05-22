using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOs
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O Campo nome é obrigatório!")]
        public string Name { get; set; }
    }
}
