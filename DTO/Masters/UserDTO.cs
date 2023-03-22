namespace HR_Service.DTO.Masters
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Password { get; set; } = "pegawai";
        public string PIN { get; set; } = "101010";
        public DateTime PasswordExpiredAt { get; set; } = DateTime.UtcNow.AddDays(30);
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}