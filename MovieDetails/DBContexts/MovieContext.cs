using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieDetails.Model;


namespace MovieDetails.DBContexts
{
    public class MovieContext:DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Movie_Name ="James Bond",
        Movie_Description="THis is a action movie",
                    DateAndTime="21/11/2020",
       MoviePicture ="###"

    },
                new Movie
                {

                    Id = 2,
                    Movie_Name = "Jumanji",
                    Movie_Description = "This is a adventures movie",
                    DateAndTime = "22/11/2020",
                    MoviePicture = "###"
                }
               
            );

    }
}
