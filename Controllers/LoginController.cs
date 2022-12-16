using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using EmbroidaryManagementSystem.Models;
using EmbroidaryManagementSystem.Methods;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmbroidaryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        
        private readonly EmbroidaryManagementSystemContext _context;
        
        public LoginController(EmbroidaryManagementSystemContext context)
        {
            _context = context;
        }
        
        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /*
        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */
        private IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // POST api/<LoginController>
        [HttpPost]
        public async Task<IActionResult> PostLogin(string username, string password)
        {
            try
            {
                var login = await _context.UserTb.FindAsync(username, password);
                
                if(login == null)
                {
                    return NotFound();
                }
                else
                {
                    var token = new TokenOperations(_configuration).CreateToken(login.Username);
                    //return token != null ? Ok(token) : BadRequest();
                    if(token != null)
                    {
                        return Ok(token);
                    }
                    else
                    {
                        return BadRequest();
                    }
                    //return login.Username;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("getUser")]
        [Authorize]
        public async Task<IActionResult> GetUserAsync()
        {
            var token = HttpContext.Request.Headers["Authorization"];
            var username = new TokenOperations(_configuration).DecodeToken(token);
            var user = await _context.UserTb.FindAsync(username);
            //var user = _userList.FirstOrDefault(x => x.Email == email);
            //return user != null ? Ok(user) : BadRequest();
            if (user != null)
            {
                return Ok(token);
            }
            else
            {
                return BadRequest();
            }
        }
        /*
        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
