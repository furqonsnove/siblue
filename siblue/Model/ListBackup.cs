using System.ComponentModel.DataAnnotations;

namespace siblue.Model;

public class ListBackup
{
    public Guid Id { get; set; }
    public Employee? Employee { get; set; }
    public Employee? EmployeeBackup { get; set; }
    public int Level { get; set; }
    [Timestamp] public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Timestamp] public DateTime UpdatedAt { get; set; } = DateTime.Now;
    [Timestamp] public DateTime? DeletedAt { get; set; }
}