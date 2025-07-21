using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
             .HasOne(u => u.Employee)
             .WithOne(e => e.User)
             .HasForeignKey<User>(u => u.EmployeeId);

            modelBuilder.Entity<User>()
                .HasKey(u => u.EmployeeId); // Set EmployeeId as primary key for User
        }
    }
}
