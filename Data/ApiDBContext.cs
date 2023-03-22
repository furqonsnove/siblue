
﻿using Microsoft.EntityFrameworkCore;
using HR_Service.Models;
using HR_Service.models;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
            modelBuilder.Entity<Backup>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("list_backup");
            });
            modelBuilder.Entity<PaidLeaveApplication>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("paid_leave_application");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public virtual DbSet<LogAudit> log_audit { get; set; }

        public virtual DbSet<Backup> backup { get; set; }

        public virtual DbSet<PaidLeaveApplication> paid_leave_application { get; set; }
    }
}
