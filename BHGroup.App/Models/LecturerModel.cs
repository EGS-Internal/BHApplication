using BHGroup.App.Public.Core;
using BHGroup.DAL.Entities;

namespace BHGroup.App.Models
{
    public class LecturerModel : ObservableObject
    {
        public int StaffCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DAL.Entities.Person.EGender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; }
        public DAL.Entities.Person.EStatus Status { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        //public int StaffCode
        //{
        //    get { return staffcode; }
        //    set { staffcode = value; }
        //}
        //public string Fullname
        //{
        //    get { return fullname; }
        //    set { fullname = value; }
        //}
        //public DateTime DateOfBirth
        //{
        //    get { return dateofbirth; }
        //    set { dateofbirth = value; }
        //}
        //public BHGroup.DAL.Entities.Person.EGender Gender
        //{
        //    get { return gender; }
        //    set { gender = value; }
        //}
        //public BHGroup.DAL.Entities.Person.EStatus Status
        //{
        //    get { return status; }
        //    set { status = value; }
        //}
        //public DateTime JoinDate
        //{
        //    get { return joindate; }
        //    set { joindate = value; }
        //}
        public LecturerModel()
        {

        }
        public LecturerModel(Lecturer lecturer)
        {
            this.StaffCode = lecturer.StaffCode;
            this.FirstName = lecturer.FirstName;
            this.LastName  = lecturer.LastName;
            this.DateOfBirth = lecturer.DateOfBirth;
            this.Gender = lecturer.Gender;
            this.JoinDate = lecturer.JoinDate;
            this.Status = lecturer.Status;
        }

        private string inputFirstName;
        public string InputFirstName
        {
            get
            {
                return inputFirstName;
            }
            set
            {
                inputFirstName = value;
                OnPropertyChanged();
            }
        }

        private string inputLastName;
        public string InputLastName
        {
            get
            {
                return inputLastName;
            }
            set
            {
                inputLastName = value;
                OnPropertyChanged();
            }
        }

        public string inputDOB;
        public string InputDOB
        {
            get
            {
                return inputDOB;
            }
            set
            {
                inputDOB = value;
                OnPropertyChanged();
            }
        }

        private string inputJoinDate;
        public string InputJoinDate
        {
            get
            {
                return inputJoinDate;
            }
            set
            {
                inputJoinDate = value;
                OnPropertyChanged();
            }
        }
        private string inputGender;
        public string InputGender
        {
            get
            {
                return inputGender;
            }
            set
            {
                inputGender = value;
                OnPropertyChanged();
            }
        }

        private string inputStatus;
        public string InputStatus
        {
            get
            {
                return inputStatus;
            }
            set
            {
                inputStatus = value;
                OnPropertyChanged();
            }
        }
    }
}
