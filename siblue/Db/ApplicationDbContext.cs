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

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Position)
            .WithMany(p => p.Employees)
            .HasForeignKey(e => e.PositionId);


        modelBuilder.Entity<Employee>()
            .HasOne(e => e.User)
            .WithMany(u => u.Employees)
            .HasForeignKey(e => e.UserId);

        modelBuilder.Entity<LogNotif>()
            .HasOne(n => n.Employee)
            .WithMany(e => e.Notifications)
            .HasForeignKey(n => n.EmployeeId);

       modelBuilder.Entity<User>()
          .HasMany(u => u.Employees)
        .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);

        modelBuilder.Entity<Position>()
            .HasMany(p => p.Employees)
            .WithOne(e => e.Position)
            .HasForeignKey(e => e.PositionId);

    }*/

}