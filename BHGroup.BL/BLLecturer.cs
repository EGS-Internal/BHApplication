using BHGroup.App.Public.Core;
using BHGroup.DAL;
using BHGroup.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
namespace BHGroup.BL
{
    public class BLLecturer : ILecturer
    {
        private readonly DBContext _dbContext;
        public BLLecturer()
        {
            _dbContext = DIHelper.Get().Services.GetRequiredService<DBContext>();
        }
        void ILecturer.Add(Lecturer lecturer)
        {
            
            _dbContext.Lecturers.Add(lecturer);
            _dbContext.SaveChanges();
        }

        void ILecturer.Delete(int id)
        {
            Lecturer result = _dbContext.Lecturers.Find(id);
            if (result != null)
            {
                _dbContext.Lecturers.Remove(result);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Delete failed: record not found!");
            }
        }

        IEnumerable<Lecturer> ILecturer.GetAll()
        {
            return _dbContext.Lecturers.ToList();
        }

        Lecturer ILecturer.GetById(int id)
        {
            Lecturer res = _dbContext.Lecturers.Find(id);
            if (res != null)
            {
                return res;
            }
            else throw new Exception("Record not found");
        }

        void ILecturer.Update(Lecturer lecturer)
        {
            _dbContext.SaveChanges();
        }
    }
}
