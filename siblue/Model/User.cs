using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace siblue.Model;

public class User
{
    public Guid Id { get; set; }
    public string? Password { get; set; } = "pegawai";
    public string? Pin { get; set; } = "101010";
    public DateTimeOffset PasswordExpiredAt { get; set; } = DateTimeOffset.UtcNow.AddDays(30);
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTime? DeletedAt { get; set; }
    //public ICollection<Employee>? Employees { get; set; }
}