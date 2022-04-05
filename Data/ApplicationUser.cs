using DependencyInjection_Demo.Models;
using Microsoft.EntityFrameworkCore;
namespace DependencyInjection_Demo.Data
{
    public class ApplicationUser:DbContext
    {
        public ApplicationUser(DbContextOptions<ApplicationUser> options): base(options)
        {

        }

        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Kanchan", Email = "abc@xyz.com" },
                new Student { Id = 2, Name = "Era", Email = "xyz@abc.com" }
                );
        }

        

    }
}
