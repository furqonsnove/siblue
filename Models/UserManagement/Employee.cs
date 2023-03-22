using System.ComponentModel.DataAnnotations.Schema;
using HR_Service.Models.Masters;

namespace HR_Service.Models.UserManagement
{
    [Table("employees")]
    public class Employee
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? NIK { get; set; }
        public string? Gender { get; set; }
        public DateTime? JoinedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsPaidLeave { get; set; } = false;

        public Guid PositionId { get; set; }
        public Position? Position { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public ICollection<LogNotification>? Notifications { get; set; }
    }

}