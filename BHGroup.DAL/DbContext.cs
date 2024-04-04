using BHGroup.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BHGroup.DAL
{
    public class DBContext : DbContext
    {

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=DESKTOP-28NL6SO\\SQLEXPRESS;Database=school_db;User Id=sa;Password=password;TrustServerCertificate=true");
                optionsBuilder.UseSqlServer("Server=DESKTOP-B1FCSS6\\TEW_SQLEXPRESS;Database=school_db;User Id=sa;Password=password;TrustServerCertificate=true");
            }
        }
    }
}
