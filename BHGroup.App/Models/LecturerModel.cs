using BHGroup.App.Public.Core;
using BHGroup.DAL.Entities;

namespace BHGroup.App.Models
{
    public class LecturerModel : ObservableObject
    {
        #region Properties
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
        #endregion
        #region Constructor
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
        #endregion
        #region Input Validation
        public Dictionary<string, string> ErrorsCollection { get; private set; } = new Dictionary<string, string>();

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
                if (ErrorsCollection.ContainsKey(columnName))
                {
                    ErrorsCollection[columnName] = error;
                }
                else if (error != string.Empty)
                {
                    ErrorsCollection.Add(columnName, error);
                }
                OnPropertyChanged("ErrorsCollection");
                return error;
            }
        }
        #endregion
    }
}
