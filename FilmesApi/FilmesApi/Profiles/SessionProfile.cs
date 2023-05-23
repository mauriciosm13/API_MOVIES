using AutoMapper;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile() 
        {
            CreateMap<CreateSessionDto, Session>();
            CreateMap<Session, ReadSessionDto>();
        }
    }
}
