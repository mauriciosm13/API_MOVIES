using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Services
{
    public class FilmeService
    {
        private MoviesContext _context;
        private IMapper _mapper;

        public FilmeService(MoviesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ReadMovieDTO AddMovie(CreateMovieDTO filmeDto)
        {
            Movie filme = _mapper.Map<Movie>(filmeDto);
            _context.Movies.Add(filme);
            _context.SaveChanges();
            return GetMovie(filme.Id);
        }

        public IEnumerable<ReadMovieDTO> GetMovies(int skip, int take, string cinemaName = null)
        {
            if (cinemaName == null)
            {
                return _mapper.Map<List<ReadMovieDTO>>(_context.Movies.Skip(skip).Take(take).ToList());
            }

            return _mapper.Map<List<ReadMovieDTO>>(_context.Movies.Skip(skip).Take(take).Where(movie => movie.Sessions.Any(session => session.Cinema.Name == cinemaName)).ToList());
        }

        public ReadMovieDTO GetMovie(int id)
        {
            var filme = _context.Movies.FirstOrDefault(filme => filme.Id == id);

            if (filme == null) return null;

            return _mapper.Map<ReadMovieDTO>(filme);
        }

        public int UpdateMovie(int id, UpdateMovieDTO filmeDto)
        {
            var filme = _context.Movies.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) 
                return 0;

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();

            return id;
        }

        public int DeleteMovie(int id)
        {
            var filme = _context.Movies.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return 0;

            _context.Remove(filme);
            _context.SaveChanges();

            return id;
        }
    }
}
