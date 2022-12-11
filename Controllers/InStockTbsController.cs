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
    public class InStockTbsController : ControllerBase
    {
        private readonly EmbroidaryManagementSystemContext _context;

        public InStockTbsController(EmbroidaryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/InStockTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InStockTb>>> GetInStockTb()
        {
            return await _context.InStockTb.ToListAsync();
        }

        // GET: api/InStockTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InStockTb>> GetInStockTb(int id)
        {
            var inStockTb = await _context.InStockTb.FindAsync(id);

            if (inStockTb == null)
            {
                return NotFound();
            }

            return inStockTb;
        }

        // PUT: api/InStockTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInStockTb(int id, InStockTb inStockTb)
        {
            if (id != inStockTb.InStockId)
            {
                return BadRequest();
            }

            _context.Entry(inStockTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InStockTbExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InStockTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InStockTb>> PostInStockTb(InStockTb inStockTb)
        {
            _context.InStockTb.Add(inStockTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InStockTbExists(inStockTb.InStockId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInStockTb", new { id = inStockTb.InStockId }, inStockTb);
        }

        // DELETE: api/InStockTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InStockTb>> DeleteInStockTb(int id)
        {
            var inStockTb = await _context.InStockTb.FindAsync(id);
            if (inStockTb == null)
            {
                return NotFound();
            }

            _context.InStockTb.Remove(inStockTb);
            await _context.SaveChangesAsync();

            return inStockTb;
        }

        private bool InStockTbExists(int id)
        {
            return _context.InStockTb.Any(e => e.InStockId == id);
        }
    }
}
