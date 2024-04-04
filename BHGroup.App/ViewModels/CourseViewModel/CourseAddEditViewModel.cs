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
using System.Collections.ObjectModel;
using BHGroup.App.Views.CourseWindow;
using log4net;

namespace BHGroup.App.ViewModels.CourseViewModel
{
    class CourseAddEditViewModel : ObservableObject
    {
        #region Data context & repositories
        private ICourse _courseContext;
        private ILecturer _lecturerContext;
        private ILog _log;
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

        //private ObservableCollection<Lecturer> _lecturerOptionSource { get; set; }
        //public ObservableCollection<Lecturer> LecturerOptionSource
        //{
        //    get
        //    {
        //        return _lecturerOptionSource;
        //    }
        //    set
        //    {
        //        _lecturerOptionSource = value;
        //        OnPropertyChanged();
        //    }
        //}

        private ObservableCollection<string> _lecturerOptionSource { get; set; }
        public ObservableCollection<string> LecturerOptionSource
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
            _log = DIHelper.Get().Services.GetRequiredService<ILog>();
        }
        //constructor
        public CourseAddEditViewModel()
        {
            InitCommandAndContext();
            CourseInputObject = new CourseModel();
            AddVisibility = true;
            _lecturerContext = DIHelper.Get().Services.GetRequiredService<ILecturer>();
            //LecturerOptionSource = new(_lecturerContext.GetAll());
            LecturerOptionSource = new(_lecturerContext.GetAll().Select(s => $"{s.FirstName} {s.LastName} ({s.StaffCode})"));
        }
        public CourseAddEditViewModel(int courseCode)
        {
            InitCommandAndContext();
            var editCourse = _courseContext.GetById(courseCode);
            CourseInputObject = new CourseModel(editCourse);
            AddVisibility = false;
            _lecturerContext = DIHelper.Get().Services.GetRequiredService<ILecturer>();
            //LecturerOptionSource = new(_lecturerContext.GetAll());
            LecturerOptionSource = new(_lecturerContext.GetAll().Select(s => $"{s.FirstName} {s.LastName} ({s.StaffCode})"));
        }

        #region Command events
        private bool CanExecuteAddCourseCommand(object parameters)
        {
            return true;
        }
        private void ExecuteAddCourseCommand(object parameters)
        {
            var view = (AddEditCourseView)parameters;
            var inputCourseCode = CourseInputObject.CourseCode;
            var inputCourseName = CourseInputObject.CourseName;
            var inputDescription = CourseInputObject.Description;
            var inputLecturer = CourseInputObject.LecturerNameID;

            if (string.IsNullOrWhiteSpace(inputCourseCode)
                || string.IsNullOrWhiteSpace(inputCourseCode)
                || string.IsNullOrWhiteSpace(inputCourseName)
                || string.IsNullOrWhiteSpace(inputLecturer))
            {
                MessageBox.Show("Please fill in every required field", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (inputCourseCode.Length > 6)
            {
                MessageBox.Show("Please enter correct course code format", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    _courseContext.Add(new Course()
                    {
                        CourseCode = inputCourseCode,
                        Coursename = inputCourseName,
                        Description = inputDescription,
                        LecturerID = int.Parse(inputLecturer.Split(" ")[2][1].ToString()),
                    });
                    view.DialogResult = true;
                    view.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ops,somthin bruh happens ", "Damn", MessageBoxButton.OK, MessageBoxImage.Information);
                    _log.Error(ex);
                }
            }
           
        }
        private bool CanExecuteEditCourseCommand(object parameters)
        {
            return true;
        }
        private void ExecuteEditCourseCommand(object parameters)
        {
            var view = (AddEditCourseView)parameters;
            var inputCourseCode = CourseInputObject.CourseCode;
            var inputCourseName = CourseInputObject.CourseName;
            var inputDescription = CourseInputObject.Description;
            var inputLecturer = CourseInputObject.LecturerNameID;

            if (string.IsNullOrWhiteSpace(inputCourseCode)
                || string.IsNullOrWhiteSpace(inputCourseCode)
                || string.IsNullOrWhiteSpace(inputCourseName)
                || string.IsNullOrWhiteSpace(inputLecturer))
            {
                MessageBox.Show("Please fill in every required field", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    _courseContext.Update(new Course()
                    {
                        CourseID = CourseInputObject.CourseID,
                        CourseCode = inputCourseCode,
                        Coursename = inputCourseName,
                        Description = inputDescription,
                        LecturerID = int.Parse(inputLecturer.Split(" ")[2][1].ToString()),
                    });
                    view.DialogResult = true;
                    view.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ops,somthin bruh happens ", "Damn", MessageBoxButton.OK, MessageBoxImage.Information);
                    _log.Error(ex);
                }
            }
        }
        #endregion
    }
}
