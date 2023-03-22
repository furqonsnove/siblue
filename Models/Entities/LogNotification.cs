using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Service.Models.Masters
{
    public class LogNotification
    {
        public Guid id { get; set; }
        public Guid employee_id { get; set; }
        public string? notification_title { get; set; }
        public string? notification_body { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
    }
}