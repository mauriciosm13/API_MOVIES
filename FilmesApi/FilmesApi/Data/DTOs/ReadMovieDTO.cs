using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOs
{
    public class ReadMovieDTO
    {
        public string Title { get; set; }
        public string Gender { get; set; }
        public int Duration { get; set; }
        public DateTime TimeGet { get; set; } = DateTime.Now;
    }
}
