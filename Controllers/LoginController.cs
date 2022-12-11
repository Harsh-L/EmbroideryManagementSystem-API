using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using EmbroidaryManagementSystem.Models;

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
        // POST api/<LoginController>
        [HttpPost]
        public async Task<ActionResult<String>> PostLogin(string username, string password)
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
                    return login.Username;
                }
            }
            catch (Exception)
            {

                throw;
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
