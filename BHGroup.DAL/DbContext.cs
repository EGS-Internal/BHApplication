using BHGroup.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BHGroup.DAL
{
    public class DBContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-28NL6SO\\SQLEXPRESS;Database=school_db;User Id=sa;Password=password;TrustServerCertificate=true");
            }
        }
    }
}
