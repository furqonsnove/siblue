using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using siblue.Db;
using siblue.Model;
using siblue.Service;

namespace siblue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ListBackupController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IListBackupRepository _list_backup_service;

        public ListBackupController(ApplicationDbContext context, IListBackupRepository list_backup_service)
        {
            _context = context;
            _list_backup_service = list_backup_service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListBackup>>> GetListBackups()
        {
            try
            {
                IEnumerable<ListBackup> list_backups = await _context.ListBackups.ToListAsync();

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
                ListBackup? list_backup = await _context.ListBackups.FindAsync(id);

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
                _context.ListBackups.Add(list_backup);
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

                ListBackup? backup_to_update = await _context.ListBackups.FindAsync(id);

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
                ListBackup? list_backup = await _context.ListBackups.FindAsync(id);

                if (list_backup == null)
                {
                    return NotFound();
                }

                _context.ListBackups.Remove(list_backup);
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
                // TODO: Check if employee is exist
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

        [HttpPut("Matrix/{employee_id}")]
        public async Task<ActionResult> UpdateListBackupMatrix(Guid employee_id, ListBackupMatrix list_backup_matrix)
        {
            try
            {
                if (employee_id != list_backup_matrix.employee_id)
                {
                    return Conflict();
                }

                // TODO: Check if employee is exist
                IEnumerable<ListBackup> list_backups = await _list_backup_service.GetAllListBackupByEmployeeId(employee_id);

                if (list_backups == null || !list_backups.Any())
                {
                    return NotFound();
                }

                await _list_backup_service.UpdateListBackupMatrix(employee_id, list_backup_matrix);

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.InnerException);
            }
        }

    }
}
