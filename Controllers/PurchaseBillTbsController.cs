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
    public class PurchaseBillTbsController : ControllerBase
    {
        private readonly EmbroidaryManagementSystemContext _context;

        public PurchaseBillTbsController(EmbroidaryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseBillTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseBillTb>>> GetPurchaseBillTb()
        {
            return await _context.PurchaseBillTb.ToListAsync();
        }

        // GET: api/PurchaseBillTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseBillTb>> GetPurchaseBillTb(int id)
        {
            var purchaseBillTb = await _context.PurchaseBillTb.FindAsync(id);

            if (purchaseBillTb == null)
            {
                return NotFound();
            }

            return purchaseBillTb;
        }

        // PUT: api/PurchaseBillTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseBillTb(int id, PurchaseBillTb purchaseBillTb)
        {
            if (id != purchaseBillTb.PbId)
            {
                return BadRequest();
            }

            _context.Entry(purchaseBillTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseBillTbExists(id))
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

        // POST: api/PurchaseBillTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PurchaseBillTb>> PostPurchaseBillTb(PurchaseBillTb purchaseBillTb)
        {
            List<int> max_id;
            int id;
            PurchaseBillTb data;
            try
            {
                max_id = _context.PurchaseBillTb.Where(data => data.PbId == _context.PurchaseBillTb.Max(id => id.PbId)).Select(data => data.PbId).ToList();
                id = Convert.ToInt32(max_id[0]) + 1;
                data = new PurchaseBillTb
                {
                    PbId = id,
                    PaId = purchaseBillTb.PaId,
                    ChallNo = purchaseBillTb.ChallNo,
                    Gstno = purchaseBillTb.Gstno,
                    Date = purchaseBillTb.Date,
                    Amount = purchaseBillTb.Amount,
                    Discount = purchaseBillTb.Discount,
                    Sgst = purchaseBillTb.Sgst,
                    Cgst = purchaseBillTb.Cgst,
                    Igst = purchaseBillTb.Igst,
                    TotalAmount = purchaseBillTb.TotalAmount
                };
            }
            catch (Exception)
            {
                id = 101;
                data = new PurchaseBillTb
                {
                    PbId = id,
                    PaId = purchaseBillTb.PaId,
                    ChallNo = purchaseBillTb.ChallNo,
                    Gstno = purchaseBillTb.Gstno,
                    Date = purchaseBillTb.Date,
                    Amount = purchaseBillTb.Amount,
                    Discount = purchaseBillTb.Discount,
                    Sgst = purchaseBillTb.Sgst,
                    Cgst = purchaseBillTb.Cgst,
                    Igst = purchaseBillTb.Igst,
                    TotalAmount = purchaseBillTb.TotalAmount
                };
            }
            
            _context.PurchaseBillTb.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PurchaseBillTbExists(id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPurchaseBillTb", id, purchaseBillTb);
        }

        // DELETE: api/PurchaseBillTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseBillTb>> DeletePurchaseBillTb(int id)
        {
            var purchaseBillTb = await _context.PurchaseBillTb.FindAsync(id);
            if (purchaseBillTb == null)
            {
                return NotFound();
            }

            _context.PurchaseBillTb.Remove(purchaseBillTb);
            await _context.SaveChangesAsync();

            return purchaseBillTb;
        }

        private bool PurchaseBillTbExists(int id)
        {
            return _context.PurchaseBillTb.Any(e => e.PbId == id);
        }
    }
}
