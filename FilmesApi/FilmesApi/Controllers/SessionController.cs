using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private MoviesContext _context;
        private IMapper _mapper;

        public SessionController(MoviesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateSession(CreateSessionDto dto)
        {
            Session session = _mapper.Map<Session>(dto);
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSessionById), new { Id = session.Id }, session);
        }

        [HttpGet]
        public IEnumerable<ReadSessionDto> RecuperaSessoes()
        {
            return _mapper.Map<List<ReadSessionDto>>(_context.Sessions.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetSessionById(int id)
        {
            Session sesions = _context.Sessions.FirstOrDefault(sesions => sesions.Id == id);
            if (sesions != null)
            {
                ReadSessionDto sessionDto = _mapper.Map<ReadSessionDto>(sesions);

                return Ok(sessionDto);
            }
            return NotFound();
        }
    }
}
