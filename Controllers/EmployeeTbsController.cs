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
    public class EmployeeTbsController : ControllerBase
    {
        private readonly EmbroidaryManagementSystemContext _context;

        public EmployeeTbsController(EmbroidaryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeTb>>> GetEmployeeTb()
        {
            return await _context.EmployeeTb.ToListAsync();
        }

        // GET: api/EmployeeTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeTb>> GetEmployeeTb(int id)
        {
            var employeeTb = await _context.EmployeeTb.FindAsync(id);

            if (employeeTb == null)
            {
                return NotFound();
            }

            return employeeTb;
        }

        // PUT: api/EmployeeTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeTb(int id, EmployeeTb employeeTb)
        {
            if (id != employeeTb.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(employeeTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTbExists(id))
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

        // POST: api/EmployeeTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeTb>> PostEmployeeTb(EmployeeTb employeeTb)
        {
            var max_id = _context.EmployeeTb.Where(data => data.EmpId == _context.EmployeeTb.Max(id => id.EmpId)).Select(data => data.EmpId).ToList();
            int id = Convert.ToInt32(max_id[0]) + 1;
            EmployeeTb data = new EmployeeTb { EmpId=id, Name=employeeTb.Name, Aadhar=employeeTb.Aadhar ,Category=employeeTb.Category, Phone=employeeTb.Phone };
            _context.EmployeeTb.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeTbExists(id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeTb", id, employeeTb);
        }

        // DELETE: api/EmployeeTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeTb>> DeleteEmployeeTb(int id)
        {
            var employeeTb = await _context.EmployeeTb.FindAsync(id);
            if (employeeTb == null)
            {
                return NotFound();
            }

            _context.EmployeeTb.Remove(employeeTb);
            await _context.SaveChangesAsync();

            return employeeTb;
        }

        private bool EmployeeTbExists(int id)
        {
            return _context.EmployeeTb.Any(e => e.EmpId == id);
        }
    }
}
