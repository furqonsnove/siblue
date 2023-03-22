using Npgsql.Internal.TypeHandlers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Service.Models
{
    public class LogAudit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid id { get; set; }
        public string modul { get; set; }
        public string activity { get; set; }
        public string detail { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow.AddHours(7);
        public DateTime updated_at { get; set; } = DateTime.UtcNow.AddHours(7);
        public DateTime? deleted_at { get; set; }
    }
}
