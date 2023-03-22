using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HR_Service.Data;
using HR_Service.Models;
using HR_Service.models;

namespace HR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackupController : ControllerBase
    {
        private readonly ApiDBContext _context;

        public BackupController(ApiDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Backup>>> GetBackups()
        {
            try
            {
                var backups = await _context.backup.ToListAsync();

                return Ok(backups);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.InnerException);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Backup>> GetBackup(Guid id)
        {
            try
            {
                var backup = await _context.backup.FindAsync(id);

                if (backup == null)
                {
                    return NotFound();
                }

                return Ok(backup);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.InnerException);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Backup>> CreateBackup(Backup backup)
        {
            try
            {
                _context.backup.Add(backup);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetBackup), new { id = backup.id }, null);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.InnerException);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBackup(Guid id, Backup backup)
        {
            try
            {
                if (id != backup.id)
                {
                    return Conflict();
                }

                var backup_to_update = await _context.backup.FindAsync(id);

                if (backup_to_update == null)
                {
                    return NotFound();
                }

                _context.Entry(backup).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBackup(Guid id)
        {
            try
            {
                var backup = await _context.backup.FindAsync(id);

                if (backup == null)
                {
                    return NotFound();
                }

                _context.backup.Remove(backup);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.InnerException);
            }
        }
    }
}
