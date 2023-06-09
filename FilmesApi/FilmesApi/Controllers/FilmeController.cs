﻿using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;
using FilmesApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private MoviesContext _context;
    private IMapper _mapper;
    private FilmeService _service;

    public FilmeController(MoviesContext context, IMapper mapper, FilmeService service)
    {
        _context = context;
        _mapper = mapper;
        _service = service;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieDTO filmeDto)
    {
        _service.AddMovie(filmeDto);

        return Ok("Filme cadastrado com sucesso");
    }

    [HttpGet]
    public IEnumerable<ReadMovieDTO> GetMovies([FromQuery] int skip = 0, int take = 50, string cinemaName = null)
    {

        var listReturn = _service.GetMovies(skip, take, cinemaName);

        return listReturn;
    }

    [HttpGet("{id}")]
    public IActionResult GetMovie(int id)
    {

        var movie = _service.GetMovie(id);
       
        return Ok(movie);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDTO filmeDto)
    {
        var returnUpdate = _service.UpdateMovie(id, filmeDto);
        if (returnUpdate != id)
            return NotFound();

        return NoContent();
        
    }

    [HttpDelete("{Id}")]
    public IActionResult DeleteMovie(int id)
    {
        var resultReturn = _service.DeleteMovie(id);
        if (resultReturn != id)
            return NotFound();

        return NoContent();
    }
}
