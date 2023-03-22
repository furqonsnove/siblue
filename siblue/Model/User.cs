using System.ComponentModel.DataAnnotations;

namespace siblue.Model;

public class User
{
    public Guid Id { get; set; }
    public string? Password { get; set; } = "pegawai";
    public string? Pin { get; set; } = "101010";
    public DateTime PasswordExpiredAt { get; set; } = DateTime.Now.AddDays(30);
    [Timestamp]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Timestamp]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Timestamp]
        public DateTime? DeletedAt { get; set; }
    public ICollection<Employee>? Employees { get; set; }
}