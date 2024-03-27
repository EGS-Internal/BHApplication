using BHGroup.App.Public.Core;
using BHGroup.DAL;
using BHGroup.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
namespace BHGroup.BL
{
    public class BLStudent : IStudent
    {

        public readonly DBContext _dbContext;
        public BLStudent()
        {
            _dbContext = DIHelper.Get().Services.GetRequiredService<DBContext>();
        }

        void IStudent.Add(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        void IStudent.Delete(int id)
        {
            var studentToRemove = _dbContext.Students.Find(id);
            if (studentToRemove != null)
            {
                _dbContext.Students.Remove(studentToRemove);
                _dbContext.SaveChanges();
            }
        }

        IEnumerable<Student> IStudent.GetAll()
        {
            return _dbContext.Students.ToList();
        }

        Student IStudent.GetById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Student> IStudent.GetByName()
        {
            throw new NotImplementedException();
        }

        void IStudent.Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
