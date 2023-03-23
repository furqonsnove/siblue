using System.ComponentModel.DataAnnotations;

namespace siblue.Model;

public class LogAudit
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Modul { get; set; }
    public string? Activity { get; set; }
    public string? Detail { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(7);
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(7);
    public DateTime? DeletedAt { get; set; }
}