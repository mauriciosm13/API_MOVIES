using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions<CinemasContext> opts) : base(opts)
        {

        }

        public DbSet<Address> Addresses { get; set; }
    }
}
