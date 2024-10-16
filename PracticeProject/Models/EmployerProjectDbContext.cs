using Microsoft.EntityFrameworkCore;

namespace PracticeProject.Models
{
    public class EmployerProjectDbContext:DbContext
    {
        public EmployerProjectDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Employer> Employers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployerProject> EmployerProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployerProject>()
                .HasKey(ep => new { ep.EmployerId, ep.ProjectId }); // Composite key

            modelBuilder.Entity<EmployerProject>()
                .HasOne(ep => ep.Employer)
                .WithMany(e => e.EmployerProjects)
                .HasForeignKey(ep => ep.EmployerId);

            modelBuilder.Entity<EmployerProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployerProjects)
                .HasForeignKey(ep => ep.ProjectId);
        }

    }
}
