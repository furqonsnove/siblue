using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Service.Models.UserManagement
{
    [Table("positions")]
    public class Position
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Level { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Employee>? Employees { get; set; }
    }
}