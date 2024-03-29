﻿using System;
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
    public class FeedBackTbsController : ControllerBase
    {
        private readonly EmbroidaryManagementSystemContext _context;

        public FeedBackTbsController(EmbroidaryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/FeedBackTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedBackTb>>> GetFeedBackTb()
        {
            return await _context.FeedBackTb.ToListAsync();
        }

        // GET: api/FeedBackTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedBackTb>> GetFeedBackTb(int id)
        {
            var feedBackTb = await _context.FeedBackTb.FindAsync(id);

            if (feedBackTb == null)
            {
                return NotFound();
            }

            return feedBackTb;
        }

        // PUT: api/FeedBackTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedBackTb(int id, FeedBackTb feedBackTb)
        {
            if (id != feedBackTb.FbId)
            {
                return BadRequest();
            }

            _context.Entry(feedBackTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedBackTbExists(id))
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

        // POST: api/FeedBackTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FeedBackTb>> PostFeedBackTb(FeedBackTb feedBackTb)
        {
            List<int> max_id;
            int id;
            FeedBackTb data;
            try
            {
                max_id = _context.FeedBackTb.Where(data => data.FbId == _context.FeedBackTb.Max(id => id.FbId)).Select(data => data.FbId).ToList();
                id = Convert.ToInt32(max_id[0]) + 1;
                data = new FeedBackTb { FbId = id, Name = feedBackTb.Name, Email = feedBackTb.Email, Phone = feedBackTb.Phone, Message = feedBackTb.Message, Time = feedBackTb.Time };
            }
            catch (Exception)
            {
                id = 101;
                data = new FeedBackTb { FbId = id, Name = feedBackTb.Name, Email = feedBackTb.Email, Phone = feedBackTb.Phone, Message = feedBackTb.Message, Time = feedBackTb.Time };
                
            }
            
            _context.FeedBackTb.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FeedBackTbExists(id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFeedBackTb", id, feedBackTb);
        }

        // DELETE: api/FeedBackTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FeedBackTb>> DeleteFeedBackTb(int id)
        {
            var feedBackTb = await _context.FeedBackTb.FindAsync(id);
            if (feedBackTb == null)
            {
                return NotFound();
            }

            _context.FeedBackTb.Remove(feedBackTb);
            await _context.SaveChangesAsync();

            return feedBackTb;
        }

        private bool FeedBackTbExists(int id)
        {
            return _context.FeedBackTb.Any(e => e.FbId == id);
        }
    }
}
