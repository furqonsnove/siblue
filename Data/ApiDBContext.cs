using HR_Service.Models.Masters;
using HR_Service.Models.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace HR_Service.Data
{
    public class ApiDBContext : DbContext
    {
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Position>? Positions { get; set; }
        public DbSet<LogNotification>? LogNotifications { get; set; }

        protected readonly IConfiguration Configuration;

        public ApiDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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

            modelBuilder.Entity<LogNotification>()
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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Configuration.GetConnectionString("HRServiceDB"));
            }
        }
    }
}
