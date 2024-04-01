using BHGroup.DAL.Entities;
using System.Security.Cryptography;
namespace BHGroup.BL
{
    public interface ILecturer
    {
        Lecturer GetById(int id);
        IEnumerable<Lecturer> GetAll();
        IEnumerable<Lecturer> GetByName(string name);
        void Add(Lecturer lecturer);
        void Update(Lecturer lecturer);
        
        void Delete(int id);
    }
}
