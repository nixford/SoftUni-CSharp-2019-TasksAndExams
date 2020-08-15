namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;
    using TeisterMask.Data.Models;

    public class TeisterMaskContext : DbContext
    {
        public TeisterMaskContext() 
        {
            
        }

        public TeisterMaskContext(DbContextOptions options)
            : base(options) 
        { 
        
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> EmployeesTasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<Project>(entity =>
                {
                    entity
                        .HasKey(p => p.Id);

                    entity
                        .HasMany(p => p.Tasks)
                        .WithOne(p => p.Project)
                        .HasForeignKey(t => t.ProjectId);

                });


            modelBuilder
                .Entity<EmployeeTask>(entity => 
                {
                    entity
                        .HasKey(et => new { et.EmployeeId, et.TaskId });

                    entity
                        .HasOne(et => et.Employee)
                        .WithMany(et => et.EmployeesTasks)
                        .HasForeignKey(et => et.EmployeeId);

                    entity
                        .HasOne(et => et.Task)
                        .WithMany(et => et.EmployeesTasks)
                        .HasForeignKey(et => et.TaskId);

                });
        }
    }
}