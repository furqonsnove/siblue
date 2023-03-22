using AutoMapper;
using HR_Service.DTO.Masters;
using HR_Service.Models.Masters;

namespace HR_Service.Data
{
    public class MasterMaps : Profile
    {
        public MasterMaps()
        {
            CreateMap<LogNotification, LogNotificationDTO>().ReverseMap();
            CreateMap<LogNotification, CreateLogNotificationDTO>().ReverseMap();
            CreateMap<LogNotification, UpdateLogNotificationDTO>().ReverseMap();
        }
    }
}