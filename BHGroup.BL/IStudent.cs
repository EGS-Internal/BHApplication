using BHGroup.DAL.Entities;
namespace BHGroup.BL
{
    public interface IStudent
    {
        //protected readonly DbContext _context;
        Student GetById(int id);
        IEnumerable<Student> GetAll();
        IEnumerable<Student> GetByName(string name);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
    }
}
