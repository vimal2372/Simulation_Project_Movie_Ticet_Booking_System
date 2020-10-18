using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieDetails.Model;
using MovieDetails.DBContexts;

namespace MovieDetails.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _dbContext;
       

        public MovieRepository(MovieContext dbContext)
        {
           
            _dbContext = dbContext;
        }

        public void DeleteMovie(int userId)
        {
            var user = _dbContext.Movies.Find(userId);
            _dbContext.Movies.Remove(user);
            Save();
        }

       
        public Movie GetMovieById(int movieId)
        {
            return _dbContext.Movies.Find(movieId);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _dbContext.Movies.ToList();
        }

      
       

        public void InsertMoive(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            Save();
        }

       

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            _dbContext.Entry(movie).State = EntityState.Modified;
            Save();
        }

        
    }
}
