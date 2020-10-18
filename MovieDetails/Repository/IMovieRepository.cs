using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieDetails.Model;

namespace MovieDetails.Repository
{
  public  interface IMovieRepository
    {
        public void DeleteMovie(int userId);
        public Movie GetMovieById(int userId);
        public IEnumerable<Movie> GetMovies();
        public void InsertMoive(Movie movie);
        public void Save();
        public void UpdateMovie(Movie movie);
    }
}
