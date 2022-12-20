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
    public class UserRightsTbsController : ControllerBase
    {
        private readonly EmbroidaryManagementSystemContext _context;

        public UserRightsTbsController(EmbroidaryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/UserRightsTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRightsTb>>> GetUserRightsTb()
        {
            return await _context.UserRightsTb.ToListAsync();
        }

        // GET: api/UserRightsTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRightsTb>> GetUserRightsTb(int id)
        {
            var userRightsTb = await _context.UserRightsTb.FindAsync(id);

            if (userRightsTb == null)
            {
                return NotFound();
            }

            return userRightsTb;
        }

        // PUT: api/UserRightsTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRightsTb(int id, UserRightsTb userRightsTb)
        {
            if (id != userRightsTb.UserRightsId)
            {
                return BadRequest();
            }

            _context.Entry(userRightsTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRightsTbExists(id))
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

        // POST: api/UserRightsTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserRightsTb>> PostUserRightsTb(UserRightsTb userRightsTb)
        {
            _context.UserRightsTb.Add(userRightsTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserRightsTbExists(userRightsTb.UserRightsId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserRightsTb", new { id = userRightsTb.UserRightsId }, userRightsTb);
        }

        // DELETE: api/UserRightsTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserRightsTb>> DeleteUserRightsTb(int id)
        {
            var userRightsTb = await _context.UserRightsTb.FindAsync(id);
            if (userRightsTb == null)
            {
                return NotFound();
            }

            _context.UserRightsTb.Remove(userRightsTb);
            await _context.SaveChangesAsync();

            return userRightsTb;
        }

        private bool UserRightsTbExists(int id)
        {
            return _context.UserRightsTb.Any(e => e.UserRightsId == id);
        }
    }
}
