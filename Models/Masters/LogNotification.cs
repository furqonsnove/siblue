using System.ComponentModel.DataAnnotations.Schema;
using HR_Service.Models.UserManagement;

namespace HR_Service.Models.Masters
{
    [Table("log_notif")]
    public class LogNotification
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("employee_id")]
        public Guid EmployeeId { get; set; }
        [Column("employee")]
        public Employee? Employee { get; set; }
        [Column("notification_title")]
        public string? NotificationTitle { get; set; }
        [Column("notification_body")]
        public string? NotificationBody { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}