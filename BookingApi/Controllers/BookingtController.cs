using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using BookingtApi.Repository;
using UserApi.Repository;
using BookingtApi.Model;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingtController : ControllerBase
    {
        private readonly IBookingtRepository _bookingtRepository;

        public BookingtController(IBookingtRepository bookingtRepository)
        {
            _bookingtRepository = bookingtRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var admins = _bookingtRepository.GetBookingts();
            return new OkObjectResult(admins);
           
        }

        // GET api/<UserController>/5
       

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] Bookingt bookingt)
        {
            using (var scope = new TransactionScope())
            {
                _bookingtRepository.InsertBookingt(bookingt);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = bookingt.Id }, bookingt);
            }
        }

        // PUT api/<UserController>/5
      

       
    }
}
