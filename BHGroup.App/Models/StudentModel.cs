using BHGroup.App.Public.Core;
using BHGroup.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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
            this.StudentCode = student.StudentCode;
            this.FirstName = student.FirstName;
            this.LastName = student.LastName;
            this.DateOfBirth = student.DateOfBirth;
            this.Gender = student.Gender;
            this.JoinDate = student.JoinDate;
            this.Status = student.Status;
        }


        public int StudentCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DAL.Entities.Person.EGender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; }
        public DAL.Entities.Person.EStatus Status { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        private string _inputFirstName { get; set; }
        public string InputFirstName
        {
            get { return _inputFirstName; }
            set { _inputFirstName = value; OnPropertyChanged(); }
        }

        private string _inputLastName { get; set; }
        public string InputLastName
        {
            get { return _inputLastName; }
            set { _inputLastName = value; OnPropertyChanged(); }
        }

        private string _inputDOB { get; set; }
        public string InputDOB
        {
            get { return _inputDOB; }
            set { _inputDOB = value; OnPropertyChanged(); }
        }

        private string _inputJoinDate { get; set; }
        public string InputJoinDate
        {
            get { return _inputJoinDate; }
            set { _inputJoinDate = value; OnPropertyChanged(); }
        }

        public string _inputGender { get; set; }
        public string InputGender
        {
            get { return _inputGender; }
            set { _inputGender = value; OnPropertyChanged(); }
        }

        public string _inputStatus { get; set; }
        public string InputStatus
        {
            get { return _inputStatus; }
            set { _inputStatus = value; OnPropertyChanged(); }
        }

    }
}
