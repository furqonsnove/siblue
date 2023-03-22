using Microsoft.EntityFrameworkCore;
using HR_Service.Models;

namespace HR_Service.Data
{
    public class ApiDBContext : DbContext
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("users");
            });
        }


    }
}
