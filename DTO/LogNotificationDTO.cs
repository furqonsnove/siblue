namespace HR_Service.DTO.Masters
{
    public class LogNotificationDTO
    {
        public Guid id { get; set; }
        public Guid employee_id { get; set; }
        public string? notification_title { get; set; }
        public string? notification_body { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
    }

    public class CreateLogNotificationDTO
    {
        public Guid employee_id { get; set; }
        public string? notification_title { get; set; }
        public string? notification_body { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
    }
    public class UpdateLogNotificationDTO
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