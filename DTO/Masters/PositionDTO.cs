namespace HR_Service.DTO.Masters
{
    public class PositionDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Level { get; set; }
        public bool IsActive { get; set; } = true;
    }

}