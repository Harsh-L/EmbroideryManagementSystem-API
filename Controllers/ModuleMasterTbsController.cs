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

            return Ok();
        }

        // POST: api/ModuleMasterTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ModuleMasterTb>> PostModuleMasterTb(ModuleMasterTb moduleMasterTb)
        {
            List<int> max_id;
            int id;
            ModuleMasterTb data;
            try
            {
                max_id = _context.ModuleMasterTb.Where(data => data.ModuleId == _context.ModuleMasterTb.Max(id => id.ModuleId)).Select(data => data.ModuleId).ToList();
                id = Convert.ToInt32(max_id[0]) + 1;
                data = new ModuleMasterTb {ModuleId=id, Name=moduleMasterTb.Name, Insert=moduleMasterTb.Insert, Update=moduleMasterTb.Update, Delete=moduleMasterTb.Delete, View=moduleMasterTb.View};

            }
            catch (Exception)
            {
                id = 101;
                data = new ModuleMasterTb { ModuleId = id, Name = moduleMasterTb.Name, Insert = moduleMasterTb.Insert, Update = moduleMasterTb.Update, Delete = moduleMasterTb.Delete, View = moduleMasterTb.View };
            }

            _context.ModuleMasterTb.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ModuleMasterTbExists(id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                } 
            }

            return CreatedAtAction("GetModuleMasterTb", id, moduleMasterTb);
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
