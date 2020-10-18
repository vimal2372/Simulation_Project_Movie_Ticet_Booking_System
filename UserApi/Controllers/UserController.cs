using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using UserApi.Model;
using UserApi.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(UserController));
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            _log4net.Info("get method invoked");
            var users = _userRepository.GetUsers();
           
           return new OkObjectResult(users);
           // return NotFound();  
        }


        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            using (var scope = new TransactionScope())
            {
                _log4net.Info("post method invoked");
                _userRepository.InsertUser(user);
                scope.Complete();
                return Ok();

                //return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            
            }
        }


        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userRepository.DeleteUser(id);
            return new OkResult();
        }
    }
}
