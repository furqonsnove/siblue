using Microsoft.EntityFrameworkCore;
using siblue.Model;
using EFCore.NamingConventions;

namespace siblue.Db;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql().UseSnakeCaseNamingConvention();
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<PaidLeaveApplication> PaidLeaveApplications { get; set; }
    public DbSet<ListBackup> ListBackups { get; set; }
    public DbSet<LogNotif> LogNotifs { get; set; }
    public DbSet<LogAudit> LogAudits { get; set; }
}