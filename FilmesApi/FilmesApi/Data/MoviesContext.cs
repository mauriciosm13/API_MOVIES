using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> opts) : base(opts) 
        { 

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Session>().HasKey(session => new { session.MovieId, session.CinemaId });

            builder.Entity<Session>().HasOne(session => session.Cinema).WithMany(cinema => cinema.Sessions).HasForeignKey(session => session.CinemaId);

            builder.Entity<Session>().HasOne(session => session.Movie).WithMany(movie => movie.Sessions).HasForeignKey(session => session.MovieId);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
