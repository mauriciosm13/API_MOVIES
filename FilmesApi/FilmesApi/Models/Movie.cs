using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Movie
{
    [Key]
    [Required(ErrorMessage = "O id é obrigatorio")]
    public int Id { get; set; }
    [Required(ErrorMessage = "O Título é obrigatorio")]
    public string Title { get; set; }
    [Required(ErrorMessage = "O Genero é obrigatorio")]
    [MaxLength(50, ErrorMessage = "Tamanho Máximo de caracteres é de 50")]
    public string Gender { get; set; }
    [Required(ErrorMessage = "A Duração é obrigatorio")]
    public int Duration { get; set; }
}

