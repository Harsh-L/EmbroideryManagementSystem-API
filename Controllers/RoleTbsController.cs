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
    public class RoleTbsController : ControllerBase
    {
        private readonly EmbroidaryManagementSystemContext _context;

        public RoleTbsController(EmbroidaryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/RoleTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleTb>>> GetRoleTb()
        {
            return await _context.RoleTb.ToListAsync();
        }

        // GET: api/RoleTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleTb>> GetRoleTb(int id)
        {
            var roleTb = await _context.RoleTb.FindAsync(id);

            if (roleTb == null)
            {
                return NotFound();
            }

            return roleTb;
        }

        // PUT: api/RoleTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoleTb(int id, RoleTb roleTb)
        {
            if (id != roleTb.RId)
            {
                return BadRequest();
            }

            _context.Entry(roleTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleTbExists(id))
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

        // POST: api/RoleTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RoleTb>> PostRoleTb(RoleTb roleTb)
        {
            var max_id = _context.RoleTb.Where(data => data.RId == _context.RoleTb.Max(id => id.RId)).Select(data => data.RId).ToList();
            int id = Convert.ToInt32(max_id[0]) + 1;
            RoleTb data = new RoleTb {RId=id, Name=roleTb.Name };

            _context.RoleTb.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoleTbExists(id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoleTb", id, roleTb);
        }

        // DELETE: api/RoleTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoleTb>> DeleteRoleTb(int id)
        {
            var roleTb = await _context.RoleTb.FindAsync(id);
            if (roleTb == null)
            {
                return NotFound();
            }

            _context.RoleTb.Remove(roleTb);
            await _context.SaveChangesAsync();

            return roleTb;
        }

        private bool RoleTbExists(int id)
        {
            return _context.RoleTb.Any(e => e.RId == id);
        }
    }
}
