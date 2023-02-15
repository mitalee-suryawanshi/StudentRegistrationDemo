using Microsoft.EntityFrameworkCore;
using StudentRegistration.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Infra.Domain
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(new List<Course>
            {
                new Course(1,"BCA"),
                new Course(2,"MCA"),
                new Course(3,"BE"),
                new Course(4,"ME")
            });
        }
    }
}