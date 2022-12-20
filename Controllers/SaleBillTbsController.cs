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

            return Ok();
        }

        // POST: api/SaleBillTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SaleBillTb>> PostSaleBillTb(SaleBillTb saleBillTb)
        {
            List<int> max_id;
            int id;
            SaleBillTb data;
            try
            {
                max_id = _context.SaleBillTb.Where(data => data.SbId == _context.SaleBillTb.Max(id => id.SbId)).Select(data => data.SbId).ToList();
                id = Convert.ToInt32(max_id[0]) + 1;
                data = new SaleBillTb { SbId = id, PaId = saleBillTb.PaId, BillNo = saleBillTb.BillNo, Gstno = saleBillTb.Gstno, ChallNo = saleBillTb.ChallNo, Date = saleBillTb.Date, Amount = saleBillTb.Amount, Discount = saleBillTb.Discount, Sgst = saleBillTb.Sgst, Cgst = saleBillTb.Cgst, Igst = saleBillTb.Igst, TotalAmount = saleBillTb.TotalAmount };
            }
            catch (Exception)
            {
                id = 101;
                data = new SaleBillTb { SbId = id, PaId = saleBillTb.PaId, BillNo = saleBillTb.BillNo, Gstno = saleBillTb.Gstno, ChallNo = saleBillTb.ChallNo, Date = saleBillTb.Date, Amount = saleBillTb.Amount, Discount = saleBillTb.Discount, Sgst = saleBillTb.Sgst, Cgst = saleBillTb.Cgst, Igst = saleBillTb.Igst, TotalAmount = saleBillTb.TotalAmount };
            }
            
            _context.SaleBillTb.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SaleBillTbExists(id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSaleBillTb", id, saleBillTb);
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
