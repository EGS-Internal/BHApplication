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
            Course res = _dbContext.Courses.Find(keyValues: course.CourseID); //find if course existed in DB
            if (res == null)
            {
                _dbContext.Courses.Add(course); // if course not existed, add course
            }
            else
            {
                res = course;
                _dbContext.Courses.Update(res); //if course is existed, update the current value to the new value.
            }
            _dbContext.SaveChanges();
        }

        public void Delete(int courseID)
        {
            if (_dbContext.Courses.Find(courseID) != null)
            {
                _dbContext.Courses.Remove(GetById(courseID));
            }
            else
            {
                throw new Exception("Delete failed: record not found!");
            }
        }

        public IEnumerable<Course> GetAll()
        {
            return _dbContext.Courses.Include(c => c.Lecturer).ToList();
        }

        public Course GetById(int id)
        {
            return _dbContext.Courses.Find(id);
        }

        public void Update(Course course)
        {
            _dbContext.SaveChanges();
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
