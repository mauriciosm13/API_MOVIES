using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Movie> filmes = new List<Movie>();
    private static int id = 0;

    [HttpPost]
    public IActionResult AddMovie([FromBody] Movie filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(GetMovie), new { id = filme.Id}, filme);
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies([FromQuery] int skip = 0, int take = 50)
    { 
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovie(int id)
    {
        var filme =  filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();
        return Ok(filme);
    }
}
