using AutoMapper;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>().ForMember(cinemaDto => cinemaDto.ReadAddressDto, opt => opt.MapFrom(cinema => cinema.Address)).ForMember(cinemaDto => cinemaDto.ReadSessionsDto, opt => opt.MapFrom(cinema => cinema.Sessions));
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
