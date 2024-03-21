using BHGroup.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace BHGroup.DAL
{
    internal class DBContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; } 
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(p => p.Id);
            modelBuilder.Entity<Student>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Lecturer>().HasKey(p => p.Id);
            modelBuilder.Entity<Lecturer>().Property(p => p.Id).ValueGeneratedOnAdd();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-28NL6SO\\SQLEXPRESS;Database=SchoolDB;User Id=sa;Password=password;TrustServerCertificate=true");
            }
        }
    }
}
