using System.ComponentModel.DataAnnotations;

namespace siblue.Model;

public class LogNotif
{
    public Guid Id { get; set; }

    public Guid EmployeeId { get; set; }

    public Employee? Employee { get; set; }
    public string? NotificationTitle { get; set; }
    public string? NotificationBody { get; set; }
    [Timestamp] public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Timestamp] public DateTime UpdatedAt { get; set; } = DateTime.Now;
    [Timestamp] public DateTime? DeletedAt { get; set; }

}