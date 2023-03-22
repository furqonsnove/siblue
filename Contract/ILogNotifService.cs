using HR_Service.DTO.Masters;

namespace HR_Service.Contract
{
    public interface ILogNotifService
    {
        Task<List<LogNotificationDTO>> GetNotificationsAsync(int page, int pageSize);
        Task<List<LogNotificationDTO>> GetNotificationsByEmployeeIdAsync(string employeeId, int page, int pageSize);
        Task<LogNotificationDTO> GetNotificationAsync(int id);
        Task<LogNotificationDTO> CreateNotificationAsync(CreateLogNotificationDTO dto);
        Task<LogNotificationDTO> UpdateNotificationAsync(int id, UpdateLogNotificationDTO dto);
        Task DeleteNotificationAsync(int id);
    }

}