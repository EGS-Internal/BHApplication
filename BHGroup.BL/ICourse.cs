using BHGroup.DAL.Entities;

namespace BHGroup.BL
{
    public interface ICourse
    {
        public Course GetById(int id);
        public IEnumerable<Course> GetAll();
        public void Add(Course course);
        public void Update(Course course);
        public void Delete(int courseID);
        IEnumerable<Course> GetByName(string name);
    }
}
