using BHGroup.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.BL
{
    public class BLStudent : IStudent
    {
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
            throw new NotImplementedException();
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
