using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using AdminApi.Model;
using AdminApi.Repository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AdminController));
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            _log4net.Info("get method invoked");
            var admins = _adminRepository.GetAdmins();
             return new OkObjectResult(admins);
           // return NotFound();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var admin = _adminRepository.GetAdminById(id);
            return new OkObjectResult(admin);

        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] Admin admin)
        {
            using (var scope = new TransactionScope())
            {
                _adminRepository.InsertAdmin(admin);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = admin.Id }, admin);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Admin admin) { 
      
            if(admin!= null)
            {
                using (var scope = new TransactionScope())
                {
                    _adminRepository.UpdateAdmin(admin);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _adminRepository.DeleteAdmin(id);
            return new OkResult();
        }
    }
}
