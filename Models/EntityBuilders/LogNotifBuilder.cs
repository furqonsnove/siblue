using HR_Service.Models.Enitty;
using HR_Service.Models.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR_Service.Models.EntityBuilders;

public class LogNotifBuilder : IEntityTypeConfiguration<LogNotification>
{
    public void Configure(EntityTypeBuilder<LogNotification> builder)
    {
        throw new NotImplementedException();
    }
}