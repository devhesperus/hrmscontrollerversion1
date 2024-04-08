using System;
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
    public class LeaveapproveManagersController : ControllerBase
    {
        private readonly HrmsystemContext _context;

        public LeaveapproveManagersController(HrmsystemContext context)
        {
            _context = context;
        }

        // GET: api/LeaveapproveManagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveapproveManager>>> GetLeaveapproveManagers()
        {
            return await _context.LeaveapproveManagers.ToListAsync();
        }

        // GET: api/LeaveapproveManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveapproveManager>> GetLeaveapproveManager(int id)
        {
            var leaveapproveManager = await _context.LeaveapproveManagers.FindAsync(id);

            if (leaveapproveManager == null)
            {
                return NotFound();
            }

            return leaveapproveManager;
        }

        // PUT: api/LeaveapproveManagers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveapproveManager(int id, LeaveapproveManager leaveapproveManager)
        {
            if (id != leaveapproveManager.Sno)
            {
                return BadRequest();
            }

            _context.Entry(leaveapproveManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveapproveManagerExists(id))
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

        // POST: api/LeaveapproveManagers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LeaveapproveManager>> PostLeaveapproveManager(LeaveapproveManager leaveapproveManager)
        {
            _context.LeaveapproveManagers.Add(leaveapproveManager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeaveapproveManager", new { id = leaveapproveManager.Sno }, leaveapproveManager);
        }

        // DELETE: api/LeaveapproveManagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveapproveManager(int id)
        {
            var leaveapproveManager = await _context.LeaveapproveManagers.FindAsync(id);
            if (leaveapproveManager == null)
            {
                return NotFound();
            }

            _context.LeaveapproveManagers.Remove(leaveapproveManager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeaveapproveManagerExists(int id)
        {
            return _context.LeaveapproveManagers.Any(e => e.Sno == id);
        }
    }
}
