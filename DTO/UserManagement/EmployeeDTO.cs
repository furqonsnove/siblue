namespace HR_Service.DTO.UserManagement
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? NIK { get; set; }
        public string? Gender { get; set; }
        public DateTime? JoinedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsPaidLeave { get; set; } = false;
        public Guid PositionId { get; set; }
        public Guid UserId { get; set; }
    }

}