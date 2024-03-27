using BHGroup.App.Public.Core;
using BHGroup.DAL;
using BHGroup.DAL.Entities;
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

        public void Delete(Course course)
        {
            if (_dbContext.Courses.Find(course.CourseID) != null)
            {
                _dbContext.Courses.Remove(GetById(course.CourseID));
            }
            else
            {
                throw new Exception("Delete failed: record not found!");
            }
        }

        public IEnumerable<Course> GetAll()
        {
            return _dbContext.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _dbContext.Courses.Find(id);
        }

        public void Update(Course course)
        {
            _dbContext.SaveChanges();
        }
    }
}
