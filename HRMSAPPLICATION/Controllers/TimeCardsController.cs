﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMSAPPLICATION.Models;

namespace HRMSAPPLICATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeCardsController : ControllerBase
    {
        private readonly HrmsystemContext _context;

        public TimeCardsController(HrmsystemContext context)
        {
            _context = context;
        }

        // GET: api/TimeCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeCard>>> GetTimeCards()
        {
            return await _context.TimeCards.ToListAsync();
        }

        // GET: api/TimeCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeCard>> GetTimeCard(int id)
        {
            var timeCard = await _context.TimeCards.FindAsync(id);

            if (timeCard == null)
            {
                return NotFound();
            }

            return timeCard;
        }

        // PUT: api/TimeCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeCard(int id, TimeCard timeCard)
        {
            if (id != timeCard.Sno)
            {
                return BadRequest();
            }

            _context.Entry(timeCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeCardExists(id))
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

        // POST: api/TimeCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TimeCard>> PostTimeCard(TimeCard timeCard)
        {
            _context.TimeCards.Add(timeCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeCard", new { id = timeCard.Sno }, timeCard);
        }

        // DELETE: api/TimeCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeCard(int id)
        {
            var timeCard = await _context.TimeCards.FindAsync(id);
            if (timeCard == null)
            {
                return NotFound();
            }

            _context.TimeCards.Remove(timeCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeCardExists(int id)
        {
            return _context.TimeCards.Any(e => e.Sno == id);
        }
    }
}
