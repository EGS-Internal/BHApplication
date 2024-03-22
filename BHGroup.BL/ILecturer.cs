using BHGroup.DAL.Entities;
namespace BHGroup.BL
{
    internal interface ILecturer
    {
        Lecturer GetById(int id);
        IEnumerable<Lecturer> GetAll();
        void Add(Lecturer lecturer);
        void Update(Lecturer lecturer);
        void Delete(int id);
    }
}
