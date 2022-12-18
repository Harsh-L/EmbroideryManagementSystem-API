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
using System.Net.Http;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmbroidaryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        
        private readonly EmbroidaryManagementSystemContext _context;
        private IConfiguration _configuration;
        public LoginController(EmbroidaryManagementSystemContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }

        // GET: api/<LoginController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        [HttpGet]
        public void Get()
        {
        }
        /*
        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */

        //public LoginController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        // POST api/<LoginController>
        [HttpPost]
        public async Task<ActionResult> PostLogin([FromBody]UserTb user)
        {
            try
            {
                
                var login = from u in _context.UserTb
                            where u.Username == user.Username & u.Password == user.Password
                            select new { u.Username, u.UserRightsId };
                //var login = await _context.UserTb.FindAsync(user);

                //var modId = from m in _context.UserRightsTb
                //            where m.UserRightsId is login.UserRightsId
                //            select m;
                

                var functions = (from m in _context.ModuleMasterTb
                            join u in _context.UserRightsTb on m.ModuleId
                            equals u.ModuleId
                            select new { user.Username, m.Insert, m.Update, m.Delete, m.View }).ToList();

                //HttpContext.Request.Headers["Permissions"] = functions[0].ToString();
                var userData = functions[0].ToString();

                //Response.Headers.Add("Permissions", functions[0].ToString());

                if (login == null)
                {
                    return NotFound();
                }
                else
                {
                    //var token = new TokenOperations(_configuration).CreateToken(user.Username);
                    var token = new TokenOperations(_configuration).CreateToken(userData);
                    if (token != null)
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
            var user = from u in _context.UserTb
                       where u.Username == username
                       select u.Username;
            //var user = await _context.UserTb.FindAsync(username);
            //var user = _userList.FirstOrDefault(x => x.Email == email);
            //return user != null ? Ok(user) : BadRequest();
            
            //var perm = Response.Headers["Permissions"];
            //var perm = Request.Headers["Permissions"];

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
