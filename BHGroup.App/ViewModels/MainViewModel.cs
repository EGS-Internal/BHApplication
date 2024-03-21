using BHGroup.App.Public.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BHGroup.App.ViewModels
{
    class MainViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { 
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand HomeCommand { get; private set; }
        public RelayCommand StudentCommand { get; private set; }
        public RelayCommand LecturerCommand { get; private set; }
        public RelayCommand ClassCommand { get; private set; }
        public RelayCommand CourseCommand { get; private set; }
        private HomeVM HomeVM { get; set; }
        private StudentVM StudentVM { get; set; }
        private LecturerVM LecturerVM { get; set; }
        private ClassVM ClassVM { get; set; }
        private CourseVM CourseVM { get; set; }

        private bool flag = true;
        public MainViewModel()
        {
            HomeVM = new HomeVM();
            StudentVM = new StudentVM();
            LecturerVM = new LecturerVM();
            ClassVM = new ClassVM();
            CourseVM = new CourseVM();

            CurrentView = HomeVM;

            HomeCommand = new RelayCommand(ExecuteHomeCommand, CanExecuteHomeCommand);
            StudentCommand = new RelayCommand(ExecuteStudentCommand, CanExecuteStudentCommand);
            LecturerCommand = new RelayCommand(ExecuteLecturerCommand, CanExecuteLecturerCommand);
            ClassCommand = new RelayCommand(ExecuteClassCommand, CanExecuteClassCommand);
            CourseCommand = new RelayCommand(ExecuteCourseCommand, CanExecuteCourseCommand);

        }
        private bool CanExecuteHomeCommand(object parameters)
        {
            return flag;
        }
        private void ExecuteHomeCommand(object parameters)
        {
            HomeNavigate();
        }
        private bool CanExecuteStudentCommand(object parameters)
        {
            return flag;
        }
        private void ExecuteStudentCommand(object parameters)
        {
            StudentNavigate();
        }
        private bool CanExecuteLecturerCommand(object parameters)
        {
            return flag;
        }
        private void ExecuteLecturerCommand(object parameters)
        {
           LecturerNavigate();
        }
        private bool CanExecuteClassCommand(object parameters)
        {
            return flag;
        }
        private void ExecuteClassCommand(object parameters)
        {
            ClassNavigate();
        }
        private bool CanExecuteCourseCommand(object parameters)
        {
            return flag;
        }
        private void ExecuteCourseCommand(object parameters)
        {
            CourseNavigate();
        }
        private void HomeNavigate()
        {
            CurrentView = HomeVM;
        }
        private void StudentNavigate()
        {
            
            CurrentView = StudentVM;
        }
        private void LecturerNavigate()
        {
            CurrentView = LecturerVM;
        }
        private void ClassNavigate()
        {
            CurrentView = ClassVM;
        }
        private void CourseNavigate()
        {
            CurrentView = CourseVM;
        }
    }
}
