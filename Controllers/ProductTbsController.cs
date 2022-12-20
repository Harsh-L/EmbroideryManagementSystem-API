using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmbroidaryManagementSystem.Models;
using System.Collections;

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

            return Ok();
        }

        // POST: api/ProductTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductTb>> PostProductTb(ProductTb productTb)
        {
            var max_id = _context.ProductTb.Where(data => data.PdId == _context.ProductTb.Max(id => id.PdId)).Select(data => data.PdId).ToList();
            int id = Convert.ToInt32(max_id[0]) + 1;
            ProductTb data = new ProductTb { PdId = id, Name = productTb.Name, Cgst = productTb.Cgst, Igst = productTb.Igst, Sgst = productTb.Sgst, Type = productTb.Type };
            


            _context.ProductTb.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            { 
                if (ProductTbExists(id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductTb", id, productTb);
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
