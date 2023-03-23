using System.ComponentModel.DataAnnotations;

namespace siblue.Model;

public class PaidLeaveApplication
{
    public Guid Id { get; set; }
    public Employee? Employee { get; set; }
    public Employee? EmployeeBackup { get; set; }
    public Employee? Reviewer { get; set; }
    public string? ApplicationStatus { get; set; }
    public string? Description { get; set; }
    public DateTime PaidLeaveStartDate { get; set; }
    public DateTime PaidLeaveEndDate { get; set; }
    public DateTime ExpiredAt { get; set; } = DateTime.Now.AddDays(2);
    [Timestamp] public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(7);
    [Timestamp] public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(7);
    [Timestamp] public DateTime? DeletedAt { get; set; }
}