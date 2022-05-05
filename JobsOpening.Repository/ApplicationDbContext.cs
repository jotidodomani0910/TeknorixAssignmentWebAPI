using JobsOpening.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsOpening.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Job>(entity =>
           entity.Property(e => e.PostedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())"));

            modelBuilder.Entity<Job>()
            .Property(p => p.JobCode)
             .HasComputedColumnSql("'JOB -'  + CAST(([Id]) AS varchar(max))");
        }
    }
}
