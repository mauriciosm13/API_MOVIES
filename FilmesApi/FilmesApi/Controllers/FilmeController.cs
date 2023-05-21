using FilmesApi.Data;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private MoviesContext _context;

    public FilmeController(MoviesContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] Movie filme)
    {
        _context.Movies.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovie), new { id = filme.Id}, filme);
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies([FromQuery] int skip = 0, int take = 50)
    { 
        return _context.Movies.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovie(int id)
    {
        var filme = _context.Movies.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();
        return Ok(filme);
    }
}
