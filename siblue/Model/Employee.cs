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
    public bool IsActive { get; set; }
    public Position? Position { get; set; }
    public User? User { get; set; }
    public bool IsPaidLeave { get; set; }
    [Timestamp]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Timestamp]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    [Timestamp]
    public DateTime? DeletedAt { get; set; }
}