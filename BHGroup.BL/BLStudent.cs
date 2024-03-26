using BHGroup.App.Public.Core;
using BHGroup.DAL.Entities;
using BHGroup.DAL;
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
    
    void IStudent.Add(Student student)
    {
        throw new NotImplementedException();
    }

    void IStudent.Delete(int id)
    {
        throw new NotImplementedException();
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
