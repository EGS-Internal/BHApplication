using BHGroup.App.Models;
using BHGroup.App.Public.Core;
using BHGroup.App.Views.StudentWindow;
using BHGroup.BL;
using BHGroup.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BHGroup.DAL.Entities.Person;
using System.Windows;

namespace BHGroup.App.ViewModels.CourseViewModel
{
    class CourseAddEditViewModel : ObservableObject
    {
        #region Data context & repositories
        private ICourse _courseContext;
        private ILecturer _lecturerContext;
        #endregion

        #region Binding
        private CourseModel _courseInputObject { get; set; }
        public CourseModel CourseInputObject
        {
            get
            {
                return _courseInputObject;
            }
            set
            {
                _courseInputObject = value;
                OnPropertyChanged();
            }
        }
        private bool addVisibility { get; set; }
        public bool AddVisibility
        {
            get
            {
                return addVisibility;
            }
            set
            {
                addVisibility = value;
                OnPropertyChanged();
            }
        }
        private List<Lecturer> _lecturerOptionSource { get; set; }
        public List<Lecturer> LecturerOptionSource
        {
            get
            {
                return _lecturerOptionSource;
            }
            set
            {
                _lecturerOptionSource = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Command
        public RelayCommand AddCourseCommand { get; private set; }
        public RelayCommand EditCourseCommand { get; private set; }

        #endregion

        private void InitCommandAndContext()
        {
            _courseContext = DIHelper.Get().Services.GetRequiredService<ICourse>();
            _lecturerContext = DIHelper.Get().Services.GetRequiredService<ILecturer>();
            AddCourseCommand = new RelayCommand(ExecuteAddCourseCommand, CanExecuteAddCourseCommand);
            EditCourseCommand = new RelayCommand(ExecuteEditCourseCommand, CanExecuteEditCourseCommand);
        }
        //constructor
        public CourseAddEditViewModel()
        {
            InitCommandAndContext();
            CourseInputObject = new CourseModel();
            AddVisibility = true;

        }
        public CourseAddEditViewModel(int courseCode)
        {
            InitCommandAndContext();
            var editCourse = _courseContext.GetById(courseCode);
            CourseInputObject = new CourseModel()
            {
                CourseID = editCourse.CourseID,
                CourseCode = editCourse.CourseCode,
                CourseName = editCourse.Coursename,
                Description = editCourse.Description,
                Lecturer = editCourse.Lecturer,
            };
            AddVisibility = false;
        }

        #region Command events
        private bool CanExecuteAddCourseCommand(object parameters)
        {
            return true;
        }
        private void ExecuteAddCourseCommand(object parameters)
        {
            //var view = (AddEditStudentView)parameters;
            //var inputFirstName = CourseInputObject.FirstName;
            //var inputLastName = CourseInputObject.LastName;
            //var inputDOB = CourseInputObject.DateOfBirth;
            //var inputJoinDate = CourseInputObject.JoinDate;
            //var inputGender = CourseInputObject.Gender;
            //var inputStatus = CourseInputObject.Status;

            //if (string.IsNullOrWhiteSpace(inputFirstName) || string.IsNullOrWhiteSpace(inputLastName))
            //{
            //    MessageBox.Show("Please fill in every required field", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
            //else
            //{
            //    _courseContext.Add(new Student()
            //    {
            //        FirstName = inputFirstName,
            //        LastName = inputLastName,
            //        DateOfBirth = inputDOB,
            //        Gender = inputGender,
            //        JoinDate = inputJoinDate,
            //        Status = inputStatus,
            //    });
            //    view.DialogResult = true;
            //    view.Close();
            //}
        }
        private bool CanExecuteEditCourseCommand(object parameters)
        {
            return true;
        }
        private void ExecuteEditCourseCommand(object parameters)
        {
            //var view = (AddEditStudentView)parameters;
            //var inputFirstName = CourseInputObject.FirstName;
            //var inputLastName = CourseInputObject.LastName;
            //var inputDOB = CourseInputObject.DateOfBirth;
            //var inputJoinDate = CourseInputObject.JoinDate;
            //var inputGender = CourseInputObject.Gender;
            //var inputStatus = CourseInputObject.Status;

            //if (string.IsNullOrWhiteSpace(inputFirstName) || string.IsNullOrWhiteSpace(inputLastName))
            //{
            //    MessageBox.Show("Please fill in every required field", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
            //else
            //{
            //    var result = MessageBox.Show("You sure?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Information);
            //    if (result == MessageBoxResult.Yes)
            //    {
            //        _courseContext.Update(new Student()
            //        {
            //            StudentCode = CourseInputObject.StudentCode,
            //            FirstName = inputFirstName,
            //            LastName = inputLastName,
            //            DateOfBirth = inputDOB,
            //            Gender = inputGender,
            //            JoinDate = inputJoinDate,
            //            Status = inputStatus,
            //        });
            //        view.DialogResult = true;
            //        view.Close();
            //    }
            //}
        }
        #endregion
    }
}
