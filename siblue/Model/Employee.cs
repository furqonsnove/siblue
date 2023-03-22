using System.ComponentModel.DataAnnotations;

namespace siblue.Model;

public enum Gender
{
    L,P
}

public class Employee
{
    public Guid Id { get; set; }
    public string? Nik { get; set; }
    public string? Name { get; set; }
    public Gender? Gender { get; set; }
    public DateTime JoinedAt { get; set; }
    public bool IsActive { get; set; } = true;

    public Guid PositionId { get; set; }
    public Position? Position { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public bool IsPaidLeave { get; set; } = false;
    [Timestamp]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Timestamp]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    [Timestamp]
    public DateTime? DeletedAt { get; set; }

    public ICollection<LogNotif>? Notifications { get; set; }
}