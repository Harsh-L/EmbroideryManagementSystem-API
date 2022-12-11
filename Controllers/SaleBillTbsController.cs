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
    public class SaleBillTbsController : ControllerBase
    {
        private readonly EmbroidaryManagementSystemContext _context;

        public SaleBillTbsController(EmbroidaryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/SaleBillTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleBillTb>>> GetSaleBillTb()
        {
            return await _context.SaleBillTb.ToListAsync();
        }

        // GET: api/SaleBillTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleBillTb>> GetSaleBillTb(int id)
        {
            var saleBillTb = await _context.SaleBillTb.FindAsync(id);

            if (saleBillTb == null)
            {
                return NotFound();
            }

            return saleBillTb;
        }

        // PUT: api/SaleBillTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaleBillTb(int id, SaleBillTb saleBillTb)
        {
            if (id != saleBillTb.SbId)
            {
                return BadRequest();
            }

            _context.Entry(saleBillTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleBillTbExists(id))
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

        // POST: api/SaleBillTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SaleBillTb>> PostSaleBillTb(SaleBillTb saleBillTb)
        {
            _context.SaleBillTb.Add(saleBillTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SaleBillTbExists(saleBillTb.SbId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSaleBillTb", new { id = saleBillTb.SbId }, saleBillTb);
        }

        // DELETE: api/SaleBillTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SaleBillTb>> DeleteSaleBillTb(int id)
        {
            var saleBillTb = await _context.SaleBillTb.FindAsync(id);
            if (saleBillTb == null)
            {
                return NotFound();
            }

            _context.SaleBillTb.Remove(saleBillTb);
            await _context.SaveChangesAsync();

            return saleBillTb;
        }

        private bool SaleBillTbExists(int id)
        {
            return _context.SaleBillTb.Any(e => e.SbId == id);
        }
    }
}
