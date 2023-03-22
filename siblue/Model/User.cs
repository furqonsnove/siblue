using System.ComponentModel.DataAnnotations;

namespace siblue.Model;

public class User
{
    public Guid Id { get; set; }
    public string? Password { get; set; }
    public string? Pin { get; set; }
    public DateTime PasswordExpiredAt { get; set; } = DateTime.Now.AddDays(30);
    [Timestamp]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Timestamp]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Timestamp]
        public DateTime? DeletedAt { get; set; }
}