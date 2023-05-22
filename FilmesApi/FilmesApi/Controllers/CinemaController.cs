using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    public class CinemaController : ControllerBase
    {
        private CinemasContext _context;
        private IMapper _mapper;


        [HttpPost]
        public IActionResult AddCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCinemaById), new { Id = cinema.Id }, cinemaDto);
        }

        [HttpGet]
        public IEnumerable<ReadCinemaDto> GetCinemas()
        {
            return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
        }
        [HttpGet("{id}")]
        public object GetCinemaById(int Id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == Id);
            if (cinema == null)
            {
                ReadCinemaDto dto = _mapper.Map<ReadCinemaDto>(cinema);
                return Ok(dto);
            }
            return NotFound();
        }
        [HttpPut]
        public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
                return NotFound();

            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteCinema(int Id) 
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == Id);
            if(cinema == null)
                return NotFound();

            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
        
 }
