using AutoMapper;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDTO, Movie>();
        }
    }
}
