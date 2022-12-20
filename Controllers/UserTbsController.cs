using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmbroidaryManagementSystem.Models;

namespace EmbroidaryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTbsController : ControllerBase
    {
        private readonly EmbroidaryManagementSystemContext _context;

        public UserTbsController(EmbroidaryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/UserTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTb>>> GetUserTb()
        {
            return await _context.UserTb.ToListAsync();
        }

        // GET: api/UserTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTb>> GetUserTb(int id)
        {
            var userTb = await _context.UserTb.FindAsync(id);

            if (userTb == null)
            {
                return NotFound();
            }

            return userTb;
        }

        // PUT: api/UserTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTb(int id, UserTb userTb)
        {
            if (id != userTb.UId)
            {
                return BadRequest();
            }

            _context.Entry(userTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTbExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/UserTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserTb>> PostUserTb(UserTb userTb)
        {
            List<int> max_id;
            int id;
            UserTb data;
            try
            {
                max_id = _context.UserTb.Where(data => data.UId == _context.UserTb.Max(id => id.UId)).Select(data => data.UId).ToList();
                id = Convert.ToInt32(max_id[0]) + 1;
                data = new UserTb
                {
                    UId = id,
                    Name = userTb.Name,
                    ContactNo = userTb.ContactNo,
                    Username = userTb.Username,
                    Email = userTb.Email,
                    Password = userTb.Password,
                    Dtstamp = userTb.Dtstamp,
                    UserRightsId = userTb.UserRightsId
                };
            }
            catch (Exception)
            {
                id = 101;
                data = new UserTb
                {
                    UId = id,
                    Name = userTb.Name,
                    ContactNo = userTb.ContactNo,
                    Username = userTb.Username,
                    Email = userTb.Email,
                    Password = userTb.Password,
                    Dtstamp = userTb.Dtstamp,
                    UserRightsId = userTb.UserRightsId
                };
                
            }
            
            _context.UserTb.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserTbExists(id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserTb", id, userTb);
        }

        // DELETE: api/UserTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserTb>> DeleteUserTb(int id)
        {
            var userTb = await _context.UserTb.FindAsync(id);
            if (userTb == null)
            {
                return NotFound();
            }

            _context.UserTb.Remove(userTb);
            await _context.SaveChangesAsync();

            return userTb;
        }

        private bool UserTbExists(int id)
        {
            return _context.UserTb.Any(e => e.UId == id);
        }
    }
}
