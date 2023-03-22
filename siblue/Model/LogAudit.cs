using System.ComponentModel.DataAnnotations;

namespace siblue.Model;

public class LogAudit
{
    public Guid Id { get; set; }
    public string? Modul { get; set; }
    public string? Activity { get; set; }
    public string? Detail { get; set; }
    [Timestamp] public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Timestamp] public DateTime UpdatedAt { get; set; } = DateTime.Now;
    [Timestamp] public DateTime? DeletedAt { get; set; }
}