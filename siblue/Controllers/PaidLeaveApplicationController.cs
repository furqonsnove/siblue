using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using siblue.Db;
using siblue.Model;

namespace siblue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaidLeaveApplicationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaidLeaveApplicationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PaidLeaveApplication
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaidLeaveApplication>>> GetPaidLeaveApplications()
        {
          if (_context.PaidLeaveApplications == null)
          {
              return NotFound();
          }
            return await _context.PaidLeaveApplications.ToListAsync();
        }

        // GET: api/PaidLeaveApplication/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaidLeaveApplication>> GetPaidLeaveApplication(Guid id)
        {
          if (_context.PaidLeaveApplications == null)
          {
              return NotFound();
          }
            var paidLeaveApplication = await _context.PaidLeaveApplications.FindAsync(id);

            if (paidLeaveApplication == null)
            {
                return NotFound();
            }

            return paidLeaveApplication;
        }

        // PUT: api/PaidLeaveApplication/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaidLeaveApplication(Guid id, PaidLeaveApplication paidLeaveApplication)
        {
            if (id != paidLeaveApplication.Id)
            {
                return BadRequest();
            }

            _context.Entry(paidLeaveApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaidLeaveApplicationExists(id))
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

        // POST: api/PaidLeaveApplication
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaidLeaveApplication>> PostPaidLeaveApplication(PaidLeaveApplication paidLeaveApplication)
        {
          if (_context.PaidLeaveApplications == null)
          {
              return Problem("Entity set 'ApplicationDbContext.PaidLeaveApplications'  is null.");
          }
            _context.PaidLeaveApplications.Add(paidLeaveApplication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaidLeaveApplication", new { id = paidLeaveApplication.Id }, paidLeaveApplication);
        }

        // DELETE: api/PaidLeaveApplication/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaidLeaveApplication(Guid id)
        {
            if (_context.PaidLeaveApplications == null)
            {
                return NotFound();
            }
            var paidLeaveApplication = await _context.PaidLeaveApplications.FindAsync(id);
            if (paidLeaveApplication == null)
            {
                return NotFound();
            }

            _context.PaidLeaveApplications.Remove(paidLeaveApplication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaidLeaveApplicationExists(Guid id)
        {
            return (_context.PaidLeaveApplications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
