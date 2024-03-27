using BHGroup.App.Public.Core;
using BHGroup.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.App.Models
{
    public class StudentModel : ObservableObject
    {
        public StudentModel()
        {

        }
        public StudentModel(Student student)
        {
            //this.FullName = student.FirstName + " " + student.LastName;

        }
        //public string FullName { get { return $"{FirstName} {LastName}"; } }

    }
}
