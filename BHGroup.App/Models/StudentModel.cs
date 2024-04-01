﻿using BHGroup.App.Public.Core;
using BHGroup.DAL.Entities;
using System.ComponentModel;
using System.Globalization;

namespace BHGroup.App.Models
{
    public class StudentModel : ObservableObject, IDataErrorInfo
    {
        public StudentModel()
        {
            DateOfBirth = DateTime.Today;
            JoinDate = DateTime.Today;
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

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        private DAL.Entities.Person.EGender _gender;
        public DAL.Entities.Person.EGender Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }

        private DAL.Entities.Person.EStatus _status;
        public DAL.Entities.Person.EStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        private DateTime _joinDate;
        public DateTime JoinDate
        {
            get
            {
                return _joinDate;
            }
            set
            {
                _joinDate = value;
                OnPropertyChanged();
            }
        }

        public string DisplayDateOfBirth => DateOfBirth.ToString(CultureInfo.CurrentCulture).Split(" ")[0];
        public string DisplayJoinDate => JoinDate.ToString(CultureInfo.CurrentCulture).Split(" ")[0];
        public string FullName { get { return $"{FirstName} {LastName}"; } }


        #region Validation
        public Dictionary<string, string> ErrorsColection { get; private set; } = new Dictionary<string, string>();

        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case "FirstName":
                        if (string.IsNullOrWhiteSpace(FirstName))
                            error = "First name cannot be empty.";
                        break;

                    case "LastName":
                        if (string.IsNullOrWhiteSpace(LastName))
                            error = "Last name cannot be empty.";
                        break;

                }
                if (ErrorsColection.ContainsKey(columnName))
                {
                    ErrorsColection[columnName] = error;
                }
                else if (error != string.Empty)
                {
                    ErrorsColection.Add(columnName, error);
                }
                OnPropertyChanged("ErrorsColection");
                return error;
            }
        }
        #endregion
    }
}
