using BHGroup.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.BL
{
    public interface IEnrollment
    {
        public Enrollment GetById(int id);
        public Enrollment GetByCourse(Course course);
        public IList<Enrollment> GetByStudent(Student student);
        public IList<Enrollment> GetAllByCourse(Course course);
        public Enrollment GetBySemester(string semester);
        public void Add(Student student, Course course);
        public void Delete(int id);
    }
}
