using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HR_Service.Data;
using HR_Service.Models;
using HR_Service.Services.ListBackups.Interfaces;
using HR_Service.Services.ListBackups.Implementations;

namespace HR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListBackupController : ControllerBase
    {
        private readonly ApiDBContext _context;
        private readonly IListBackupService _list_backup_service;

        public ListBackupController(ApiDBContext context, IListBackupService list_backup_service)
        {
            _context = context;
            _list_backup_service = list_backup_service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListBackup>>> GetListBackups()
        {
            try
            {
                IEnumerable<ListBackup> list_backups = await _context.list_backup.ToListAsync();

                return Ok(list_backups);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.InnerException);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ListBackup>> GetListBackup(Guid id)
        {
            try
            {
                ListBackup? list_backup = await _context.list_backup.FindAsync(id);

                if (list_backup == null)
                {
                    return NotFound();
                }

                return Ok(list_backup);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.InnerException);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ListBackup>> CreateListBackup(ListBackup list_backup)
        {
            try
            {
                _context.list_backup.Add(list_backup);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetListBackup), new { id = list_backup.id }, null);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.InnerException);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateListBackup(Guid id, ListBackup list_backup)
        {
            try
            {
                if (id != list_backup.id)
                {
                    return Conflict();
                }

                ListBackup? backup_to_update = await _context.list_backup.FindAsync(id);

                if (backup_to_update == null)
                {
                    return NotFound();
                }

                _context.Entry(list_backup).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteListBackup(Guid id)
        {
            try
            {
                ListBackup? list_backup = await _context.list_backup.FindAsync(id);

                if (list_backup == null)
                {
                    return NotFound();
                }

                _context.list_backup.Remove(list_backup);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.InnerException);
            }
        }

        [HttpGet("Matrix")]
        public async Task<ActionResult<IEnumerable<ListBackupMatrix>>> GetAllListBackupMatrix()
        {
            try
            {
                return Ok(await _list_backup_service.GetAllListBackupMatrix());
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.InnerException);
            }
        }

        [HttpPost("Matrix")]
        public async Task<ActionResult<IEnumerable<ListBackup>>> CreateListBackupMatrix(ListBackupMatrix list_backup_matrix)
        {
            try
            {
                IEnumerable<ListBackup> list_backups = await _list_backup_service.CreateListBackupMatrix(list_backup_matrix);

                return CreatedAtAction(nameof(GetListBackups), new { ids = list_backups.ToList().Select(x => x.id) }, null);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.InnerException);
            }
        }

        [HttpGet("Matrix/{nik}")]
        public async Task<ActionResult<ListBackupMatrix>> GetListBackupMatrixByNik(string nik)
        {
            try
            {
                ListBackupMatrix? list_backup_matrix = await _list_backup_service.GetListBackupMatrixByNik(nik);

                if (list_backup_matrix == null)
                {
                    return NotFound();
                }

                return Ok(list_backup_matrix);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.InnerException);
            }
        }
    }
}
