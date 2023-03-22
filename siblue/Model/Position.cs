using System.ComponentModel.DataAnnotations;

namespace siblue.Model;

public class Position
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public int? Level { get; set; }
    public bool? IsActive { get; set; }
    [Timestamp]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Timestamp]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    [Timestamp]
    public DateTime? DeletedAt { get; set; }
}