using BHGroup.App.Public.Core;
using BHGroup.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.App.Models
{
    internal class CourseModel : ObservableObject, IDataErrorInfo
    {
        public CourseModel()
        {
        }  
        public CourseModel(Course course)
        {
            this.CourseID = course.CourseID;
            this.CourseCode = course.CourseCode;
            this.CourseName = course.Coursename;
            this.Description = course.Description;
            this.LecturerID = course.LecturerID;
            this.Lecturer = course.Lecturer;
            this.LecturerNameID = $"{course.Lecturer.FirstName} {course.Lecturer.LastName} ({course.Lecturer.StaffCode})";
        }
        #region Properties
        public int CourseID { get; set; }

        private string _courseName;
        public string CourseName
        {
            get
            {
                return _courseName;
            }
            set
            {
                _courseName = value;
                OnPropertyChanged();
            }
        }

        private string _courseCode;
        public string CourseCode
        {
            get
            {
                return _courseCode;
            }
            set
            {
                _courseCode = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private int _lecturerID;
        public int LecturerID
        {
            get
            {
                return _lecturerID;
            }
            set
            {
                _lecturerID = value;
                OnPropertyChanged();
            }
        }

        private Lecturer _lecturer;
        public Lecturer Lecturer
        {
            get
            {
                return _lecturer;
            }
            set
            {
                _lecturer = value;
                OnPropertyChanged();
            }
        }

        private string _lecturerNameID;
        public string LecturerNameID
        {
            get
            {
                return _lecturerNameID;
            }
            set
            {
                _lecturerNameID = value;
                OnPropertyChanged();
            }
        }

        public string LecturerName => $"{Lecturer.FirstName} {Lecturer.LastName}" ;

        #endregion

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
                    case "CourseCode":
                        if (string.IsNullOrWhiteSpace(CourseCode))
                            error = "Course code cannot be empty.";
                        break;

                    case "CourseName":
                        if (string.IsNullOrWhiteSpace(CourseName))
                            error = "Course name cannot be empty.";
                        break;

                    case "Description":
                        if (string.IsNullOrWhiteSpace(Description))
                            error = "Course description cannot be empty.";
                        break;

                    case "LecturerID":
                        if (LecturerID == 0)
                            error = "Lecturer cannot be empty";
                        break;

                    case "LecturerNameID":
                        if (string.IsNullOrWhiteSpace(LecturerNameID))
                            error = "Lecturer cannot be empty";
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
