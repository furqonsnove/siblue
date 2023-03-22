
using Microsoft.EntityFrameworkCore;
using HR_Service.Models;
using HR_Service.Models.Enitty;
using HR_Service.Models.EntityBuilders;

namespace HR_Service.Data
{
  public partial class ApiDBContext : DbContext
  {
    protected readonly IConfiguration Configuration;

    public ApiDBContext(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      // connect to postgres with connection string from app settings
      options.UseNpgsql(Configuration.GetConnectionString("HRServiceDB"));
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Position> positions => Set<Position>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      new PositionBuilder().Configure(modelBuilder.Entity<Position>());
      modelBuilder.Entity<LogAudit>(entity =>
      {
        entity.HasKey(e => e.id);

        entity.ToTable("log_audit");
      });
      modelBuilder.Entity<User>(entity =>
      {
        entity.HasKey(e => e.id);

        entity.ToTable("users");
      });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public virtual DbSet<LogAudit> log_audit { get; set; }
  }
}
