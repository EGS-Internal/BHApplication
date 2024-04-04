using BHGroup.App.Public.Core;
using BHGroup.DAL;
using BHGroup.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BHGroup.BL
{
    public class BLStudent : IStudent
    {

        private readonly DBContext _dbContext;
        public BLStudent()
        {
            _dbContext = DIHelper.Get().Services.GetRequiredService<DBContext>();
        }
        public BLStudent(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        void IStudent.Add(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
            if (_dbContext.Entry(student) != null)
            {
                _dbContext.Entry(student).State = EntityState.Detached;
            }
        }

        void IStudent.Delete(int id)
        {
            var studentToRemove = _dbContext.Students.FirstOrDefault(s => s.StudentCode == id);
            if (studentToRemove != null)
            {
                _dbContext.Students.Remove(studentToRemove);
                _dbContext.SaveChanges();
            }
        }

        IEnumerable<Student> IStudent.GetAll()
        {
            return _dbContext.Students.AsNoTracking().ToList();
        }

        Student IStudent.GetById(int id)
        {
            var result = _dbContext.Students.AsNoTracking().FirstOrDefault(s => s.StudentCode == id);
            if (result != null)
                return result;
            return null;
        }

        IEnumerable<Student> IStudent.GetByName(string name)
        {
            var result = _dbContext.Students
                .AsNoTracking()
                .Where(s => s.FirstName.Contains(name)
                         || s.LastName.Contains(name));
            return result;
        }

        void IStudent.Update(Student student)
        {
            _dbContext.Students.Update(student);
            _dbContext.SaveChanges();
            if (_dbContext.Entry(student) != null)
            {
                _dbContext.Entry(student).State = EntityState.Detached;
            }
        }
    }
}
