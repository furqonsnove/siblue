using AutoMapper;
using HR_Service.Contract;
using HR_Service.Data;
using HR_Service.DTO.Masters;
using HR_Service.Models.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace HR_Service.Services
{
    public class LogNotifService : ILogNotifService
    {
        private readonly ApiDBContext _dbContext;
        private readonly IDistributedCache _redis;
        private readonly IMapper _mapper;

        public LogNotifService(ApiDBContext dbContext, IDistributedCache redisCacheClient, IMapper mapper)
        {
            _dbContext = dbContext;
            _redis = redisCacheClient;
            _mapper = mapper;
        }

        public async Task<List<LogNotificationDTO>> GetNotificationsAsync(int page, int pageSize)
        {
            var cacheKey = $"notifications-{page}-{pageSize}";
            var cachedNotifications = await _redis.GetStringAsync(cacheKey);
            if (cachedNotifications != null)
            {
                return _mapper.Map<List<LogNotificationDTO>>(JsonConvert.DeserializeObject(cachedNotifications));
            }

            var notifications = await _dbContext.LogNotifications
                .OrderByDescending(n => n.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            await _redis.SetStringAsync(cacheKey, JsonConvert.SerializeObject(notifications));

            return _mapper.Map<List<LogNotificationDTO>>(notifications);
        }

        public async Task<List<LogNotificationDTO>> GetNotificationsByEmployeeIdAsync(string employeeId, int page, int pageSize)
        {
            var cacheKey = $"notifications-{employeeId}-{page}-{pageSize}";
            var cachedNotifications = await _redis.GetStringAsync(cacheKey);
            if (cachedNotifications != null)
            {
                return _mapper.Map<List<LogNotificationDTO>>(JsonConvert.DeserializeObject(cachedNotifications));
            }

            if (Guid.TryParse(employeeId, out Guid employeeGuid))
            {
                var notifications = await _dbContext.LogNotifications
                    .Where(n => n.EmployeeId == employeeGuid)
                    .OrderByDescending(n => n.CreatedAt)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                await _redis.SetStringAsync(cacheKey, JsonConvert.SerializeObject(notifications));

                return _mapper.Map<List<LogNotificationDTO>>(notifications);
            }
            else
            {
                throw new ArgumentException("Invalid employeeId parameter");
            }
        }

        public async Task<LogNotificationDTO> GetNotificationAsync(int id)
        {
            var notification = await _dbContext.LogNotifications.FindAsync(id);
            return _mapper.Map<LogNotificationDTO>(notification);
        }

        public async Task<LogNotificationDTO> CreateNotificationAsync(CreateLogNotificationDTO dto)
        {
            var notification = _mapper.Map<LogNotification>(dto);
            notification.CreatedAt = DateTime.UtcNow;
            notification.UpdatedAt = DateTime.UtcNow;

            await _dbContext.LogNotifications.AddAsync(notification);
            await _dbContext.SaveChangesAsync();

            await _redis.RemoveAsync("notifications-");

            return _mapper.Map<LogNotificationDTO>(notification);
        }

        public async Task<LogNotificationDTO> UpdateNotificationAsync(int id, UpdateLogNotificationDTO dto)
        {
            var notification = await _dbContext.LogNotifications.FindAsync(id);

            if (notification == null)
            {
                throw new KeyNotFoundException($"Notification with id {id} not found.");
            }

            notification.NotificationTitle = dto.NotificationTitle ?? notification.NotificationTitle;
            notification.NotificationBody = dto.NotificationBody ?? notification.NotificationBody;
            notification.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();

            await _redis.RemoveAsync("notifications-");

            return _mapper.Map<LogNotificationDTO>(notification);
        }

        public async Task DeleteNotificationAsync(int id)
        {
            var notification = await _dbContext.LogNotifications.FindAsync(id);

            if (notification == null)
            {
                throw new KeyNotFoundException($"Notification with id {id} not found.");
            }

            _dbContext.LogNotifications.Remove(notification);
            await _dbContext.SaveChangesAsync();

            await _redis.RemoveAsync("notifications-");
        }
    }
}