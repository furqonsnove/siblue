using HR_Service.Models.Masters;
using Microsoft.EntityFrameworkCore;
using HR_Service.Models;
using HR_Service.Models.Enitty;
using HR_Service.Models.EntityBuilders;

namespace HR_Service.Data
{
    public partial class ApiDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbSet<Position>? Positions { get; set; }
        public DbSet<LogNotification>? LogNotifications { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Position> positions => Set<Position>();


        public virtual DbSet<LogAudit> log_audit { get; set; }


        public ApiDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

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

            modelBuilder.Entity<ListBackup>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("list_backup");
            });


            // modelBuilder.Entity<Employee>()
            //     .HasOne(e => e.Position)
            //     .WithMany(p => p.Employees)
            //     .HasForeignKey(e => e.PositionId);

            // modelBuilder.Entity<Employee>()
            //     .HasOne(e => e.User)
            //     .WithMany(u => u.Employees)
            //     .HasForeignKey(e => e.UserId);

            // modelBuilder.Entity<LogNotification>()
            //     .HasOne(n => n.Employee)
            //     .WithMany(e => e.Notifications)
            //     .HasForeignKey(n => n.EmployeeId);

            // modelBuilder.Entity<User>()
            //     .HasMany(u => u.Employees)
            //     .WithOne(e => e.User)
            //     .HasForeignKey(e => e.UserId);

            // modelBuilder.Entity<Position>()
            //     .HasMany(p => p.Employees)
            //     .WithOne(e => e.Position)
            //     .HasForeignKey(e => e.PositionId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Configuration.GetConnectionString("HRServiceDB"));
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public virtual DbSet<ListBackup> list_backup { get; set; }

    }

}
