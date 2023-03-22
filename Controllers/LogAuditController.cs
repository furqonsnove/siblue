using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HR_Service.Data;
using HR_Service.Models;

namespace HR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogAuditController : ControllerBase
    {
        private readonly ApiDBContext _context;

        public LogAuditController(ApiDBContext context)
        {
            _context = context;
        }

        // GET: api/log_audit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogAudit>>> GetLogAudit()
        {
          if (_context.log_audit == null)
          {
              return NotFound();
          }
            return await _context.log_audit.ToListAsync();
        }

        // GET: api/LogAudit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogAudit>> GetLogAudit(Guid id)
        {
          if (_context.log_audit == null)
          {
              return NotFound();
          }
            var log_audit = await _context.log_audit.FindAsync(id);

            if (log_audit == null)
            {
                return NotFound();
            }

            return log_audit;
        }

        // PUT: api/LogAudit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogAudit(Guid id, LogAudit log_audit)
        {
            if (id != log_audit.id)
            {
                return BadRequest();
            }

            _context.Entry(log_audit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!log_auditExists(id))
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

        // POST: api/log_audit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LogAudit>> PostLogAudit(LogAudit log_audit)
        {
          if (_context.log_audit == null)
          {
              return Problem("Entity set 'ApiDBContext.LogAudit'  is null.");
          }
            _context.log_audit.Add(log_audit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogAudit", new { id = log_audit.id }, log_audit);
        }

        // DELETE: api/LogAudit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogAudit(Guid id)
        {
            if (_context.log_audit == null)
            {
                return NotFound();
            }
            var log_audit = await _context.log_audit.FindAsync(id);
            if (log_audit == null)
            {
                return NotFound();
            }

            _context.log_audit.Remove(log_audit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool log_auditExists(Guid id)
        {
            return (_context.log_audit?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
