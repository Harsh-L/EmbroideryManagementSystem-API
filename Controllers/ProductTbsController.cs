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
    public class ProductTbsController : ControllerBase
    {
        private readonly EmbroidaryManagementSystemContext _context;

        public ProductTbsController(EmbroidaryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/ProductTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTb>>> GetProductTb()
        {
            return await _context.ProductTb.ToListAsync();
        }

        // GET: api/ProductTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTb>> GetProductTb(int id)
        {
            var productTb = await _context.ProductTb.FindAsync(id);

            if (productTb == null)
            {
                return NotFound();
            }

            return productTb;
        }

        // PUT: api/ProductTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductTb(int id, ProductTb productTb)
        {
            if (id != productTb.PdId)
            {
                return BadRequest();
            }

            _context.Entry(productTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTbExists(id))
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

        // POST: api/ProductTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductTb>> PostProductTb(ProductTb productTb)
        {
            _context.ProductTb.Add(productTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductTbExists(productTb.PdId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductTb", new { id = productTb.PdId }, productTb);
        }

        // DELETE: api/ProductTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductTb>> DeleteProductTb(int id)
        {
            var productTb = await _context.ProductTb.FindAsync(id);
            if (productTb == null)
            {
                return NotFound();
            }

            _context.ProductTb.Remove(productTb);
            await _context.SaveChangesAsync();

            return productTb;
        }

        private bool ProductTbExists(int id)
        {
            return _context.ProductTb.Any(e => e.PdId == id);
        }
    }
}
