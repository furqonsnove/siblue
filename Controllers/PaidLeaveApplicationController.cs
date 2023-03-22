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
    public class PaidLeaveApplicationController : ControllerBase
    {
        private readonly ApiDBContext _context;

        public PaidLeaveApplicationController(ApiDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaidLeaveApplication>>> GetPaidLeaveApplications()
        {
            try
            {
                var paid_leave_applications = await _context.paid_leave_application.ToListAsync();

                return Ok(paid_leave_applications);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaidLeaveApplication>> GetPaidLeaveApplication(Guid id)
        {
            try
            {
                var paid_leave_application = await _context.paid_leave_application.FindAsync(id);

                if (paid_leave_application == null)
                {
                    return NotFound();
                }

                return Ok(paid_leave_application);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PaidLeaveApplication>> CreatePaidLeaveApplication(PaidLeaveApplication paid_leave_application)
        {
            try
            {
                _context.paid_leave_application.Add(paid_leave_application);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPaidLeaveApplication), new { id = paid_leave_application.id }, null);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePaidLeaveApplication(Guid id, PaidLeaveApplication paid_leave_application)
        {
            try
            {
                if (id != paid_leave_application.id)
                {
                    return Conflict();
                }

                var paid_leave_application_to_update = await _context.paid_leave_application.FindAsync(id);

                if (paid_leave_application_to_update == null)
                {
                    return NotFound();
                }

                _context.Entry(paid_leave_application).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePaidLeaveApplication(Guid id)
        {
            try
            {
                var paid_leave_application = await _context.paid_leave_application.FindAsync(id);

                if (paid_leave_application == null)
                {
                    return NotFound();
                }

                _context.paid_leave_application.Remove(paid_leave_application);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }
    }
}
