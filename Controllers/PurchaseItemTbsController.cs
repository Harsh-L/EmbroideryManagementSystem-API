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
    public class PurchaseItemTbsController : ControllerBase
    {
        private readonly EmbroidaryManagementSystemContext _context;

        public PurchaseItemTbsController(EmbroidaryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseItemTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseItemTb>>> GetPurchaseItemTb()
        {
            return await _context.PurchaseItemTb.ToListAsync();
        }

        // GET: api/PurchaseItemTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseItemTb>> GetPurchaseItemTb(int id)
        {
            var purchaseItemTb = await _context.PurchaseItemTb.FindAsync(id);

            if (purchaseItemTb == null)
            {
                return NotFound();
            }

            return purchaseItemTb;
        }

        // PUT: api/PurchaseItemTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseItemTb(int id, PurchaseItemTb purchaseItemTb)
        {
            if (id != purchaseItemTb.PiId)
            {
                return BadRequest();
            }

            _context.Entry(purchaseItemTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseItemTbExists(id))
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

        // POST: api/PurchaseItemTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PurchaseItemTb>> PostPurchaseItemTb(PurchaseItemTb purchaseItemTb)
        {
            List<int> max_id;
            int id;
            PurchaseItemTb data;
            try
            {
                max_id = _context.PurchaseItemTb.Where(data => data.PiId == _context.PurchaseItemTb.Max(id => id.PiId)).Select(data => data.PiId).ToList();
                id = Convert.ToInt32(max_id[0]) + 1;
                data = new PurchaseItemTb
                {
                    PiId = id,
                    Name = purchaseItemTb.Name,
                    Design = purchaseItemTb.Design,
                    Quantity = purchaseItemTb.Quantity,
                    Rate = purchaseItemTb.Rate,
                    Amount = purchaseItemTb.Amount,
                    ChallNo = purchaseItemTb.ChallNo,
                    Sgst = purchaseItemTb.Sgst,
                    Cgst = purchaseItemTb.Cgst,
                    Igst = purchaseItemTb.Igst
                };
            }
            catch (Exception)
            {
                id = 101;
                data = new PurchaseItemTb
                {
                    PiId = id,
                    Name = purchaseItemTb.Name,
                    Design = purchaseItemTb.Design,
                    Quantity = purchaseItemTb.Quantity,
                    Rate = purchaseItemTb.Rate,
                    Amount = purchaseItemTb.Amount,
                    ChallNo = purchaseItemTb.ChallNo,
                    Sgst = purchaseItemTb.Sgst,
                    Cgst = purchaseItemTb.Cgst,
                    Igst = purchaseItemTb.Igst
                };
            }
            
            _context.PurchaseItemTb.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PurchaseItemTbExists(id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPurchaseItemTb", id, purchaseItemTb);
        }

        // DELETE: api/PurchaseItemTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseItemTb>> DeletePurchaseItemTb(int id)
        {
            var purchaseItemTb = await _context.PurchaseItemTb.FindAsync(id);
            if (purchaseItemTb == null)
            {
                return NotFound();
            }

            _context.PurchaseItemTb.Remove(purchaseItemTb);
            await _context.SaveChangesAsync();

            return purchaseItemTb;
        }

        private bool PurchaseItemTbExists(int id)
        {
            return _context.PurchaseItemTb.Any(e => e.PiId == id);
        }
    }
}
