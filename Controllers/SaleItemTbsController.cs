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
    public class SaleItemTbsController : ControllerBase
    {
        private readonly EmbroidaryManagementSystemContext _context;

        public SaleItemTbsController(EmbroidaryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/SaleItemTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleItemTb>>> GetSaleItemTb()
        {
            return await _context.SaleItemTb.ToListAsync();
        }

        // GET: api/SaleItemTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleItemTb>> GetSaleItemTb(int id)
        {
            var saleItemTb = await _context.SaleItemTb.FindAsync(id);

            if (saleItemTb == null)
            {
                return NotFound();
            }

            return saleItemTb;
        }

        // PUT: api/SaleItemTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaleItemTb(int id, SaleItemTb saleItemTb)
        {
            if (id != saleItemTb.SiId)
            {
                return BadRequest();
            }

            _context.Entry(saleItemTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleItemTbExists(id))
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

        // POST: api/SaleItemTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SaleItemTb>> PostSaleItemTb(SaleItemTb saleItemTb)
        {
            var max_id = _context.SaleItemTb.Where(data => data.SiId== _context.SaleItemTb.Max(id => id.SiId)).Select(data => data.SiId).ToList();
            int id = Convert.ToInt32(max_id[0]) + 1;
            SaleItemTb data = new SaleItemTb { SiId=id,
                                                BillNo=saleItemTb.BillNo,
                                                Name=saleItemTb.Name,
                                                Design=saleItemTb.Design,
                                                Work=saleItemTb.Work,
                                                Plain=saleItemTb.Plain,
                                                Rate=saleItemTb.Rate,
                                                Amount=saleItemTb.Amount,
                                                Sgst=saleItemTb.Sgst,
                                                Cgst=saleItemTb.Sgst,
                                                Igst=saleItemTb.Igst};
            _context.SaleItemTb.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SaleItemTbExists(id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSaleItemTb", id, saleItemTb);
        }

        // DELETE: api/SaleItemTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SaleItemTb>> DeleteSaleItemTb(int id)
        {
            var saleItemTb = await _context.SaleItemTb.FindAsync(id);
            if (saleItemTb == null)
            {
                return NotFound();
            }

            _context.SaleItemTb.Remove(saleItemTb);
            await _context.SaveChangesAsync();

            return saleItemTb;
        }

        private bool SaleItemTbExists(int id)
        {
            return _context.SaleItemTb.Any(e => e.SiId == id);
        }
    }
}
