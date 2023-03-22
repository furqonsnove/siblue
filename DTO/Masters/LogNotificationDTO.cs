namespace HR_Service.DTO.Masters
{
    public class LogNotificationDTO
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string? NotificationTitle { get; set; }
        public string? NotificationBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }

    public class CreateLogNotificationDTO
    {
        public Guid EmployeeId { get; set; }
        public string? NotificationTitle { get; set; }
        public string? NotificationBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
    public class UpdateLogNotificationDTO
    {
        public Guid EmployeeId { get; set; }
        public string? NotificationTitle { get; set; }
        public string? NotificationBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}