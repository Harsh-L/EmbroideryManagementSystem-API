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
    public class InStockItemTbsController : ControllerBase
    {
        private readonly EmbroidaryManagementSystemContext _context;

        public InStockItemTbsController(EmbroidaryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/InStockItemTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InStockItemTb>>> GetInStockItemTb()
        {
            return await _context.InStockItemTb.ToListAsync();
        }

        // GET: api/InStockItemTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InStockItemTb>> GetInStockItemTb(int id)
        {
            var inStockItemTb = await _context.InStockItemTb.FindAsync(id);

            if (inStockItemTb == null)
            {
                return NotFound();
            }

            return inStockItemTb;
        }

        // PUT: api/InStockItemTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInStockItemTb(int id, InStockItemTb inStockItemTb)
        {
            if (id != inStockItemTb.InStockItem)
            {
                return BadRequest();
            }

            _context.Entry(inStockItemTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InStockItemTbExists(id))
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

        // POST: api/InStockItemTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InStockItemTb>> PostInStockItemTb(InStockItemTb inStockItemTb)
        {
            _context.InStockItemTb.Add(inStockItemTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InStockItemTbExists(inStockItemTb.InStockItem))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInStockItemTb", new { id = inStockItemTb.InStockItem }, inStockItemTb);
        }

        // DELETE: api/InStockItemTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InStockItemTb>> DeleteInStockItemTb(int id)
        {
            var inStockItemTb = await _context.InStockItemTb.FindAsync(id);
            if (inStockItemTb == null)
            {
                return NotFound();
            }

            _context.InStockItemTb.Remove(inStockItemTb);
            await _context.SaveChangesAsync();

            return inStockItemTb;
        }

        private bool InStockItemTbExists(int id)
        {
            return _context.InStockItemTb.Any(e => e.InStockItem == id);
        }
    }
}
