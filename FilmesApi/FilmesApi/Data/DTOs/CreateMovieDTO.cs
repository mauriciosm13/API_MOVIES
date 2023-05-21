using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOs
{
    public class CreateMovieDTO
    {
        [Required(ErrorMessage = "O Título é obrigatorio")]
        public string Title { get; set; }
        [Required(ErrorMessage = "O Genero é obrigatorio")]
        [StringLength(50, ErrorMessage = "Tamanho Máximo de caracteres é de 50")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "A Duração é obrigatorio")]
        public int Duration { get; set; }
    }
}
