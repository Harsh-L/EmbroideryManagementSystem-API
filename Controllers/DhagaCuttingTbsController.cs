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
    public class DhagaCuttingTbsController : ControllerBase
    {
        private readonly EmbroidaryManagementSystemContext _context;

        public DhagaCuttingTbsController(EmbroidaryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/DhagaCuttingTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DhagaCuttingTb>>> GetDhagaCuttingTb()
        {
            return await _context.DhagaCuttingTb.ToListAsync();
        }

        // GET: api/DhagaCuttingTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DhagaCuttingTb>> GetDhagaCuttingTb(int id)
        {
            var dhagaCuttingTb = await _context.DhagaCuttingTb.FindAsync(id);

            if (dhagaCuttingTb == null)
            {
                return NotFound();
            }

            return dhagaCuttingTb;
        }

        // PUT: api/DhagaCuttingTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDhagaCuttingTb(int id, DhagaCuttingTb dhagaCuttingTb)
        {
            if (id != dhagaCuttingTb.DcId)
            {
                return BadRequest();
            }

            _context.Entry(dhagaCuttingTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DhagaCuttingTbExists(id))
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

        // POST: api/DhagaCuttingTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DhagaCuttingTb>> PostDhagaCuttingTb(DhagaCuttingTb dhagaCuttingTb)
        {
            List<int> max_id;
            int id;
            DhagaCuttingTb data;
            try
            {
                max_id = _context.DhagaCuttingTb.Where(data => data.DcId == _context.DhagaCuttingTb.Max(id => id.DcId)).Select(data => data.DcId).ToList();
                id = Convert.ToInt32(max_id[0]) + 1;
                data = new DhagaCuttingTb { DcId = id, Name = dhagaCuttingTb.Name, EmpId = dhagaCuttingTb.EmpId, Date = dhagaCuttingTb.Date, Saree = dhagaCuttingTb.Saree, Price = dhagaCuttingTb.Price, Total = dhagaCuttingTb.Total };
            }
            catch (Exception)
            {
                id = 101;
                data = new DhagaCuttingTb { DcId = id, Name = dhagaCuttingTb.Name, EmpId = dhagaCuttingTb.EmpId, Date = dhagaCuttingTb.Date, Saree = dhagaCuttingTb.Saree, Price = dhagaCuttingTb.Price, Total = dhagaCuttingTb.Total };
            }

            _context.DhagaCuttingTb.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DhagaCuttingTbExists(id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDhagaCuttingTb", id, dhagaCuttingTb);
        }

        // DELETE: api/DhagaCuttingTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DhagaCuttingTb>> DeleteDhagaCuttingTb(int id)
        {
            var dhagaCuttingTb = await _context.DhagaCuttingTb.FindAsync(id);
            if (dhagaCuttingTb == null)
            {
                return NotFound();
            }

            _context.DhagaCuttingTb.Remove(dhagaCuttingTb);
            await _context.SaveChangesAsync();

            return dhagaCuttingTb;
        }

        private bool DhagaCuttingTbExists(int id)
        {
            return _context.DhagaCuttingTb.Any(e => e.DcId == id);
        }
    }
}
