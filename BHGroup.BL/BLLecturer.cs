using BHGroup.App.Public.Core;
using BHGroup.DAL;
using BHGroup.DAL.Entities;
using Microsoft.EntityFrameworkCore;
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
            _dbContext.Entry(lecturer).State = EntityState.Detached;
        }

        void ILecturer.Delete(int id)
        {
            var lecturerToRemove = _dbContext.Lecturers.Find(id);
            if (lecturerToRemove != null)
            {
                _dbContext.Lecturers.Remove(lecturerToRemove);
                _dbContext.SaveChanges();
            }
        }

        

        IEnumerable<Lecturer> ILecturer.GetAll()
        {
            return _dbContext.Lecturers.AsNoTracking().ToList();
        }

        Lecturer ILecturer.GetById(int id)
        {
            var result = _dbContext.Lecturers.AsNoTracking().FirstOrDefault(s => s.StaffCode == id);
            if (result != null)
                return result;
            return null;
        }
        IEnumerable<Lecturer> ILecturer.GetByName(string name)
        {
            var result = _dbContext.Lecturers
                .AsNoTracking()
                .Where(s => s.FirstName.Contains(name)
                         || s.LastName.Contains(name));
            return result;
        }
        void ILecturer.Update(Lecturer lecturer)
        {
            _dbContext.Update(lecturer);
            _dbContext.SaveChanges();
            _dbContext.Entry(lecturer).State = EntityState.Detached;
        }
    }
}
