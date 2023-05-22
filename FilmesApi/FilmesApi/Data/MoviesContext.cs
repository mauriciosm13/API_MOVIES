﻿using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> opts) : base(opts) 
        { 

        }  

        public DbSet<Movie> Movies { get; set; }
    }
}