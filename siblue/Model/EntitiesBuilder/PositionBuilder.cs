using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace siblue.Model.EntitiesBuilder
{
    public class PositionBuilder : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.HasIndex(p => p.Code).IsUnique();
        }
    }
}
