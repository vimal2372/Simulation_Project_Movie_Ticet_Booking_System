using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieDetails.Model;
using MovieDetails.Repository;

namespace MovieDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
       readonly log4net.ILog _log4net =log4net.LogManager.GetLogger(typeof(MovieController));
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
           
        }

 
            [HttpGet]
        public IActionResult Get()
        {
            var users = _movieRepository.GetMovies();
           _log4net.Error("get method invoked");
            
            return new OkObjectResult(users);
            // return NotFound();
        }


        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            using (var scope = new TransactionScope())
            {
                _movieRepository.InsertMoive(movie);
                scope.Complete();
                return Ok();
            }
        }

     
        [HttpPut]
        public IActionResult Put([FromBody] Movie movie) { 
      
            if(movie!= null)
            {
                using (var scope = new TransactionScope())
                {
                    _movieRepository.UpdateMovie(movie);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

      
    }
}
