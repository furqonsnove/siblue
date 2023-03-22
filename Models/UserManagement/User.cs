using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Service.Models.UserManagement
{
    [Table("users")]
    public class User
    {
        public Guid Id { get; set; }
        public string Password { get; set; } = "pegawai";
        public string PIN { get; set; } = "101010";
        public DateTime PasswordExpiredAt { get; set; } = DateTime.UtcNow.AddDays(30);
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}