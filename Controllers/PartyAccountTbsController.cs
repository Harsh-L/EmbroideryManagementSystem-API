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
    public class PartyAccountTbsController : ControllerBase
    {
        private readonly EmbroidaryManagementSystemContext _context;

        public PartyAccountTbsController(EmbroidaryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/PartyAccountTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartyAccountTb>>> GetPartyAccountTb()
        {
            return await _context.PartyAccountTb.ToListAsync();
        }

        // GET: api/PartyAccountTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartyAccountTb>> GetPartyAccountTb(int id)
        {
            var partyAccountTb = await _context.PartyAccountTb.FindAsync(id);

            if (partyAccountTb == null)
            {
                return NotFound();
            }

            return partyAccountTb;
        }

        // PUT: api/PartyAccountTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartyAccountTb(int id, PartyAccountTb partyAccountTb)
        {
            if (id != partyAccountTb.PaId)
            {
                return BadRequest();
            }

            _context.Entry(partyAccountTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyAccountTbExists(id))
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

        // POST: api/PartyAccountTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PartyAccountTb>> PostPartyAccountTb(PartyAccountTb partyAccountTb)
        {
            List<int> max_id;
            int id;
            PartyAccountTb data;
            try
            {
                max_id = _context.PartyAccountTb.Where(data => data.PaId == _context.PartyAccountTb.Max(id => id.PaId)).Select(data => data.PaId).ToList();
                id = Convert.ToInt32(max_id[0]) + 1;
                data = new PartyAccountTb
                {
                    PaId = id,
                    PName = partyAccountTb.PName,
                    Gstno = partyAccountTb.Gstno,
                    Aline1 = partyAccountTb.Aline1,
                    Aline2 = partyAccountTb.Aline2,
                    City = partyAccountTb.City,
                    Pincode = partyAccountTb.Pincode,
                    StateCountry = partyAccountTb.StateCountry,
                    Type = partyAccountTb.Type
                };
            }
            catch (Exception)
            {
                id = 101;
                data = new PartyAccountTb
                {
                    PaId = id,
                    PName = partyAccountTb.PName,
                    Gstno = partyAccountTb.Gstno,
                    Aline1 = partyAccountTb.Aline1,
                    Aline2 = partyAccountTb.Aline2,
                    City = partyAccountTb.City,
                    Pincode = partyAccountTb.Pincode,
                    StateCountry = partyAccountTb.StateCountry,
                    Type = partyAccountTb.Type
                };
            }

            _context.PartyAccountTb.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PartyAccountTbExists(id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPartyAccountTb", id, partyAccountTb);
        }

        // DELETE: api/PartyAccountTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PartyAccountTb>> DeletePartyAccountTb(int id)
        {
            var partyAccountTb = await _context.PartyAccountTb.FindAsync(id);
            if (partyAccountTb == null)
            {
                return NotFound();
            }

            _context.PartyAccountTb.Remove(partyAccountTb);
            await _context.SaveChangesAsync();

            return partyAccountTb;
        }

        private bool PartyAccountTbExists(int id)
        {
            return _context.PartyAccountTb.Any(e => e.PaId == id);
        }
    }
}
