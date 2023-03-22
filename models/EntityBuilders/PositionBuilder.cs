using HR_Service.Models.Enitty;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR_Service.Models.EntityBuilders;

public class PositionBuilder : IEntityTypeConfiguration<Position>
{
  public void Configure(EntityTypeBuilder<Position> builder)
  {
    builder.Property(p => p.name).HasMaxLength(100);
    builder.Property(p => p.code).HasMaxLength(5);
    builder.HasIndex(p => p.code).IsUnique();
  }
}