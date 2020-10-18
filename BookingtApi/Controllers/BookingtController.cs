using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using BookingtApi.Model;
using BookingtApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingtController : ControllerBase
    {
        readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(BookingtController));
        private readonly IBookingtRepository _bookingtRepository;

        public BookingtController(IBookingtRepository bookingtRepository)
        {
            _bookingtRepository = bookingtRepository;
        }

    
        [HttpGet]
        public IActionResult Get()
        {
            _log4net.Info("get method invoked");
            var users = _bookingtRepository.GetBookingts();
             return new OkObjectResult(users);
            // return NotFound();
            //return Ok();
        }


        [HttpGet("{id}")]
        

      
        [HttpPost]
        public IActionResult Post([FromBody] Bookingt bookingt)
        {
            using (var scope = new TransactionScope())
            {
                _bookingtRepository.InsertBookingt(bookingt);
                scope.Complete();
                return Ok();
            }
        }

     
    }
}
