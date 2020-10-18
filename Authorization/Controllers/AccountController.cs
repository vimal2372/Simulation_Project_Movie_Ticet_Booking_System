using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Authorization.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
         private IConfiguration _config;
        IAuthRepo _authrepo;

        readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AccountController));

        public AccountController(IConfiguration config,IAuthRepo authRepo)
        {
            _config = config;
            _authrepo = authRepo;
           
        }
       
        [HttpPost]
        public IActionResult Login(Authenticate user)
        {
            _log4net.Info("post method invoked");
            IActionResult response = Unauthorized();
            if (user != null)
            {
                var tokenString = _authrepo.GenerateJSONWebToken();
                response = Ok(new { token = tokenString });
            }
                   
            return response;
           // return NotFound();
        }
      /*   private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
       private string GenerateJSONWebToken(Authenticate userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/

    }
}
