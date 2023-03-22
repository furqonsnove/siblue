using System.ComponentModel.DataAnnotations.Schema;
using HR_Service.Models.UserManagement;

namespace HR_Service.Models.Masters
{
    [Table("log_notif")]
    public class LogNotification
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public string? NotificationTitle { get; set; }
        public string? NotificationBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}