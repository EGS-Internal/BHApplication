using BHGroup.App.Public.Core;
using BHGroup.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.App.Models
{
    public class LecturerModel : Lecturer
    {
        public LecturerModel()
        {

        }
        public LecturerModel(Lecturer lecturer)
        {
            this.FirstName = lecturer.FirstName;
            this.LastName = lecturer.LastName;
            this.DateOfBirth = lecturer.DateOfBirth;
            this.Gender = lecturer.Gender;
            this.JoinDate = lecturer.JoinDate;
            this.Status = lecturer.Status;
        }

    }
}
