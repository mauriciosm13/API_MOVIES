using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Movie> filmes = new List<Movie>();

    [HttpPost]
    public void AddMovie([FromBody] Movie filme)
    {
        
            filmes.Add(filme);
            Console.WriteLine(filme.Title);
            Console.WriteLine(filme.Duration);
       
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies()
    { 
        return filmes;
    }
}
