using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOs
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ReadAddressDto ReadAddressDto { get; set; }
        public ICollection<ReadSessionDto> ReadSessionsDto { get; set; }
    }
}
