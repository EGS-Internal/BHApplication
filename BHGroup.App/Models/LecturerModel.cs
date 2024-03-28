using BHGroup.App.Public.Core;
using BHGroup.DAL.Entities;

namespace BHGroup.App.Models
{
    public class LecturerModel : ObservableObject
    {
        private int staffCode;
        public int StaffCode
        {
            get
            {
                return staffCode;
            }
            set
            {
                staffCode = value;
                OnPropertyChanged();
            }
        }
        private string lastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }
        public string LastName { get; set; }
        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged();

            }
        }
        private DAL.Entities.Person.EGender gender;
        public DAL.Entities.Person.EGender Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
                OnPropertyChanged();
            }
        }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged();
            }
        }
        private DateTime joinDate;
        public DateTime JoinDate
        {
            get
            {
                return joinDate;
            }
            set
            {
                joinDate = value;
                OnPropertyChanged();
            }
        }
        private DAL.Entities.Person.EStatus status;
        public DAL.Entities.Person.EStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public LecturerModel()
        {

        }
        public LecturerModel(Lecturer lecturer)
        {
            this.StaffCode = lecturer.StaffCode;
            this.FirstName = lecturer.FirstName;
            this.LastName = lecturer.LastName;
            this.DateOfBirth = lecturer.DateOfBirth;
            this.Gender = lecturer.Gender;
            this.JoinDate = lecturer.JoinDate;
            this.Status = lecturer.Status;
        }


    }
}
