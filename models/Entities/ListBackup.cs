using Npgsql.Internal.TypeHandlers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Service.Models
{
    public class ListBackup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid id { get; set; }
        public Guid employee_id { get; set; }
        public Guid employee_backup_id { get; set; }
        public int level { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow.AddHours(7);
        public DateTime update_at { get; set; } = DateTime.UtcNow.AddHours(7);
        public DateTime? delete_at { get; set; }
    }
}
