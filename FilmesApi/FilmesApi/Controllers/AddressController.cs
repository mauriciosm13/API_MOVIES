using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private MoviesContext _context;
        private IMapper _mapper;

        public AddressController(MoviesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddAddress([FromBody] CreateAddressDto filmeDto)
        {
            Address filme = _mapper.Map<Address>(filmeDto);
            _context.Addresses.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAddress), new { id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<ReadMovieDTO> GetAddresses()
        {
            return _mapper.Map<List<ReadMovieDTO>>(_context.Addresses.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetAddress(int id)
        {
            var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

            if (address == null) return NotFound();

            var addressDto = _mapper.Map<ReadAddressDto>(address);
            return Ok(addressDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDto addressDto)
        {
            var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null) return NotFound();

            _mapper.Map(addressDto, address);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteAddress(int id)
        {
            var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null) return NotFound();

            _context.Remove(address);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
