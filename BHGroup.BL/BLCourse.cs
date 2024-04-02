using BHGroup.App.Public.Core;
using BHGroup.DAL;
using BHGroup.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BHGroup.BL
{

    public class BLCourse : ICourse
    {
        private readonly DBContext _dbContext;
        public BLCourse()
        {
            _dbContext = DIHelper.Get().Services.GetRequiredService<DBContext>();
        }
        public void Add(Course course)
        {
             _dbContext.Courses.Add(course); // if course not existed, add course
            _dbContext.SaveChanges();
            _dbContext.Entry(course).State = EntityState.Detached;
        }

        public void Delete(int courseID)
        {
            var courseToRemove = _dbContext.Courses.Find(courseID);
            if (courseToRemove != null)
            {
                _dbContext.Courses.Remove(courseToRemove);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Course> GetAll()
        {
            return _dbContext.Courses.AsNoTracking()
                .Include(c => c.Lecturer).AsNoTracking()
                .ToList();
        }

        public Course GetById(int id)
        {
            return _dbContext.Courses.AsNoTracking()
                .Include(c => c.Lecturer)
                .AsNoTracking()
                .FirstOrDefault(c => c.CourseID == id);
        }

        public void Update(Course course)
        {
            _dbContext.Update(course);
            _dbContext.SaveChanges();
            _dbContext.Entry(course).State = EntityState.Detached;
        }

        IEnumerable<Course> ICourse.GetByName(string name)
        {
            var result = _dbContext.Courses
                .AsNoTracking()
                .Where(s => s.Coursename.Contains(name));
            return result;
        }
    }
}
