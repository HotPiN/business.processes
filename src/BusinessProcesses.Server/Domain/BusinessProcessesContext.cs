using BusinessProcesses.Server.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessProcesses.Server.Domain
{
    public class BusinessProcessesContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobInstance> JobInstances { get; set; }
        public DbSet<JobInstanceProperty> JobInstanceProperty { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=business_processes.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsRequired();

                entity.HasOne(e => e.CreatedByUser)
                    .WithMany(e => e.CreatedJobs)
                    .HasForeignKey(e => e.CreatedBy);
                
                entity.HasOne(e => e.UpdatedByUser)
                    .WithMany(e => e.UpdatedJobs)
                    .HasForeignKey(e => e.UpdatedBy);
            });

            modelBuilder.Entity<JobInstance>(entity =>
            {
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.JobId).IsRequired();
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Code).IsRequired();
                entity.Property(e => e._Type).IsRequired();

            });

            modelBuilder.Entity<JobInstanceProperty>(entity =>
            {
                entity.Property(e => e.PropertyId).IsRequired();
                entity.Property(e => e.JobId).IsRequired();
                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.Code).IsRequired();
                entity.Property(e => e.JobId).IsRequired();

                entity.HasOne(e => e.Next);
                entity.HasOne(e => e.Parent);
            });           
            
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.PasswordHash).IsRequired();
            });
        }
    }
}