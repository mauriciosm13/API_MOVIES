using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class CinemasContext : DbContext
    {
        public CinemasContext(DbContextOptions<CinemasContext> opts) : base(opts) 
        { 

        }  

        public DbSet<Cinema> Cinemas { get; set; }
    }
}
