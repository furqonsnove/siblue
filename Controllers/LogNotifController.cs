using HR_Service.Contract;
using HR_Service.DTO.Masters;
using Microsoft.AspNetCore.Mvc;

namespace HR_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogNotifControllers : ControllerBase
    {
        private readonly ILogNotifService _notificationService;
        public LogNotifControllers(ILogNotifService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotificationsAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var notifications = await _notificationService.GetNotificationsAsync(page, pageSize);

            return Ok(notifications);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationAsync(int id)
        {
            var notification = await _notificationService.GetNotificationAsync(id);

            if (notification == null)
            {
                return NotFound();
            }

            return Ok(notification);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetNotificationsByEmployeeIdAsync(string employeeId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var notifications = await _notificationService.GetNotificationsByEmployeeIdAsync(employeeId, page, pageSize);

            return Ok(notifications);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotificationAsync([FromBody] CreateLogNotificationDTO dto)
        {
            var notification = await _notificationService.CreateNotificationAsync(dto);

            return CreatedAtAction(nameof(GetNotificationAsync), new { id = notification.Id }, notification);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotificationAsync(int id, [FromBody] UpdateLogNotificationDTO dto)
        {
            var notification = await _notificationService.UpdateNotificationAsync(id, dto);

            if (notification == null)
            {
                return NotFound();
            }

            return Ok(notification);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificationAsync(int id)
        {
            await _notificationService.DeleteNotificationAsync(id);

            return NoContent();
        }

    }

}