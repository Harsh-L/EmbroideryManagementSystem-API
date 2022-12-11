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
    public class ModuleMasterTbsController : ControllerBase
    {
        private readonly EmbroidaryManagementSystemContext _context;

        public ModuleMasterTbsController(EmbroidaryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/ModuleMasterTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleMasterTb>>> GetModuleMasterTb()
        {
            return await _context.ModuleMasterTb.ToListAsync();
        }

        // GET: api/ModuleMasterTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleMasterTb>> GetModuleMasterTb(int id)
        {
            var moduleMasterTb = await _context.ModuleMasterTb.FindAsync(id);

            if (moduleMasterTb == null)
            {
                return NotFound();
            }

            return moduleMasterTb;
        }

        // PUT: api/ModuleMasterTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModuleMasterTb(int id, ModuleMasterTb moduleMasterTb)
        {
            if (id != moduleMasterTb.ModuleId)
            {
                return BadRequest();
            }

            _context.Entry(moduleMasterTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleMasterTbExists(id))
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

        // POST: api/ModuleMasterTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ModuleMasterTb>> PostModuleMasterTb(ModuleMasterTb moduleMasterTb)
        {
            _context.ModuleMasterTb.Add(moduleMasterTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ModuleMasterTbExists(moduleMasterTb.ModuleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetModuleMasterTb", new { id = moduleMasterTb.ModuleId }, moduleMasterTb);
        }

        // DELETE: api/ModuleMasterTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ModuleMasterTb>> DeleteModuleMasterTb(int id)
        {
            var moduleMasterTb = await _context.ModuleMasterTb.FindAsync(id);
            if (moduleMasterTb == null)
            {
                return NotFound();
            }

            _context.ModuleMasterTb.Remove(moduleMasterTb);
            await _context.SaveChangesAsync();

            return moduleMasterTb;
        }

        private bool ModuleMasterTbExists(int id)
        {
            return _context.ModuleMasterTb.Any(e => e.ModuleId == id);
        }
    }
}
