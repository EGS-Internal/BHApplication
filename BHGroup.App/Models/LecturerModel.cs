using BHGroup.App.Public.Core;
using BHGroup.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.App.Models
{
    public class LecturerModel : ObservableObject
    {
        private int staffcode;
        private string fullname;
        private DateTime dateofbirth;
        private BHGroup.DAL.Entities.Person.EGender gender;
        private DateTime joindate;
        private  BHGroup.DAL.Entities.Person.EStatus status;
        public int StaffCode
        {
            get { return staffcode; }
            set { staffcode = value; }
        }
        public string Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }
        public DateTime DateOfBirth
        {
            get { return dateofbirth; }
            set { dateofbirth = value; }
        }
        public  BHGroup.DAL.Entities.Person.EGender Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public BHGroup.DAL.Entities.Person.EStatus Status
        {
            get { return status; }
            set { status = value; }
        }
        public DateTime JoinDate
        {
            get { return joindate; } 
            set { joindate = value; }
        }
        public LecturerModel()
        {

        }
        public LecturerModel(Lecturer lecturer)
        {
            this.StaffCode = lecturer.StaffCode;
            this.Fullname = lecturer.FirstName + " " + lecturer.LastName;
            this.DateOfBirth = lecturer.DateOfBirth;
            this.Gender = lecturer.Gender;
            this.JoinDate = lecturer.JoinDate;
            this.Status = lecturer.Status;
        }

    }
}
