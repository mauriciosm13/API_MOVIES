using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private MoviesContext _context;
    private IMapper _mapper;

    public FilmeController(MoviesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieDTO filmeDto)
    {
        Movie filme = _mapper.Map<Movie>(filmeDto);
        _context.Movies.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovie), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<ReadMovieDTO> GetMovies([FromQuery] int skip = 0, int take = 50, string? cinemaName = null)
    {
        if (cinemaName == null)
        {
            return _mapper.Map<List<ReadMovieDTO>>(_context.Movies.Skip(skip).Take(take).ToList());
        }

        return _mapper.Map<List<ReadMovieDTO>>(_context.Movies.Skip(skip).Take(take).Where(movie => movie.Sessions.Any(session => session.Cinema.Name == cinemaName)).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetMovie(int id)
    {
        var filme = _context.Movies.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();

        var filmeDto = _mapper.Map<ReadMovieDTO>(filme);
        return Ok(filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDTO filmeDto)
    {
        var filme = _context.Movies.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{Id}")]
    public IActionResult UpdatePatchMovie(int id, JsonPatchDocument<UpdateMovieDTO> patch)
    {
        var filme = _context.Movies.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        var movieUpdate = _mapper.Map<UpdateMovieDTO>(filme);

        patch.ApplyTo(movieUpdate, ModelState);

        if (!TryValidateModel(movieUpdate))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(movieUpdate, filme);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{Id}")]
    public IActionResult DeleteMovie(int id)
    {
        var filme = _context.Movies.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        _context.Remove(filme);
        _context.SaveChanges();

        return NoContent();
    }
}
