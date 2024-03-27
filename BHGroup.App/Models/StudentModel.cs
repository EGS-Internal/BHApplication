using BHGroup.App.Public.Core;
using BHGroup.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.App.Models
{
    public class StudentModel : Student
    {
        public StudentModel()
        {

        }
        public StudentModel(Student student)
        {
            this.FirstName = student.FirstName;
            this.LastName = student.LastName;
            this.DateOfBirth = student.DateOfBirth;
            this.Gender = student.Gender;
            this.JoinDate = student.JoinDate;
            this.Status = student.Status;
        }
        public string FullName { get { return $"{FirstName} {LastName}"; } }

    }
}
