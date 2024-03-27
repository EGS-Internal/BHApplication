using BHGroup.App.Models;
using BHGroup.App.Public.Core;
using BHGroup.App.Views.StudentWindow;
using BHGroup.BL;
using BHGroup.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace BHGroup.App.ViewModels
{
    class StudentListViewModel : ObservableObject
    {
        private readonly IStudent _studentContext;
        private AddStudentView _addStudentWindow { get; set; }

        private List<StudentModel> _students { get; set; }
        public List<StudentModel> Students
        {
            get { return _students; }
            set { _students = value; OnPropertyChanged(); }
        }

        private StudentModel _selectedItem { get; set; }
        public StudentModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set {
                _selectedItem = value;
                OnPropertyChanged();
                DeleteStudentCommand.OnCanExecuteChanged();
                EditStudentCommand.OnCanExecuteChanged();
            }
        }

        //private StudentInputModel _studentToAdd { get; set; }
        //public StudentInputModel StudentToAdd {
        //    get { return _studentToAdd; }
        //    set { _studentToAdd = value; OnPropertyChanged(); }
        //}

        
        private string _inputFirstName {  get; set; }
        public string InputFirstName
        {
            get { return _inputFirstName; }
            set { _inputFirstName = value; OnPropertyChanged(); }
        }

        private string _inputLastName { get; set; }
        public string InputLastName
        {
            get { return _inputLastName; }
            set { _inputLastName = value; OnPropertyChanged();  }
        }

        private string _inputDOB {  get; set; }
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

        public string _inputStatus {  get; set; }   
        public string InputStatus
        {
            get { return _inputStatus; }
            set { _inputStatus = value; OnPropertyChanged(); } 
        }


        private bool _isButtonEnabled;
        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set
            {
                //if it has already set, keep the original value and not notice on change
                if (_isButtonEnabled != value)
                {
                    _isButtonEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand OpenAddStudentViewCommand {  get; private set; }
        public RelayCommand DeleteStudentCommand {  get; private set; }
        public RelayCommand EditStudentCommand { get; private set; }
        public RelayCommand AddStudentCommand { get; private set; }

        public StudentListViewModel()
        {
            _studentContext = DIHelper.Get().Services.GetRequiredService<IStudent>();
            Students = _studentContext.GetAll().Select(s => new StudentModel(s)).ToList();
            OpenAddStudentViewCommand = new RelayCommand(ExecuteOpenAddStudentWindowCommand, CanExecuteOpenAddStudentWindowCommand);
            DeleteStudentCommand = new RelayCommand(ExecuteDeleteStudentCommand, CanExecuteDeleteStudentCommand);
            EditStudentCommand = new RelayCommand(ExecuteEditStudentCommand, CanExecuteEditStudentCommand);
            AddStudentCommand = new RelayCommand(ExecuteAddStudentCommand, CanExecuteAddStudentCommand);
            //StudentToAdd = new StudentInputModel();
        }

        private bool CanExecuteOpenAddStudentWindowCommand(object parameters)
        {
            return true;
        }
        private void ExecuteOpenAddStudentWindowCommand(object parameters)
        {
            _addStudentWindow = new AddStudentView();
            var result = _addStudentWindow.ShowDialog();
            //if(_addStudentWindow.StudentToAdd != null)
            //{
            //    _studentContext.Add(new Student()
            //    {
            //        FirstName = _addStudentWindow.StudentToAdd.FirstName,
            //        LastName = _addStudentWindow.StudentToAdd.LastName,
            //        DateOfBirth = _addStudentWindow.StudentToAdd.DateOfBirth,
            //        Gender = _addStudentWindow.StudentToAdd.Gender,
            //        JoinDate = _addStudentWindow.StudentToAdd.JoinDate,
            //        Status = _addStudentWindow.StudentToAdd.Status
            //    });
            //    Students = _studentContext.GetAll().Select(s =>
            //    {
            //        return new StudentModel()
            //        {
            //            FirstName = s.FirstName,
            //            LastName = s.LastName,
            //            StudentCode = s.StudentCode,
            //            DateOfBirth = s.DateOfBirth,
            //            Gender = s.Gender,
            //            JoinDate = s.JoinDate,
            //            Status = s.Status
            //        };
            //    }).ToList();
            //}
            
        }
        //Check if any students are selected
        private bool CanExecuteDeleteStudentCommand(object parameters)
        {
            if (SelectedItem != null)
            {
                IsButtonEnabled = true;
                return true;
            }
            else
            {
                IsButtonEnabled = false;
                return false; 
            }
        }
        //Run the Delete Student Command 
        private void ExecuteDeleteStudentCommand(object parameters)
        {
            //MessageBoxResult result = MessageBox.Show("You sure'bout that?", "Delete Confirm",MessageBoxButton.YesNo, MessageBoxImage.Question);
            //if(result == MessageBoxResult.Yes)
            //{
            //    _studentContext.Delete(SelectedItem);
            //    Students = _studentContext.GetAll().Select(s => new StudentModel(s)).ToList();
            //    SelectedItem = null;
            //}
        }
        //
        private bool CanExecuteEditStudentCommand(object parameters)
        {
            if (SelectedItem != null)
            {
                IsButtonEnabled = true;
                return true;
            }
            else
            {
                IsButtonEnabled = false;
                return false;
            }
        }
        private void ExecuteEditStudentCommand(object parameters)
        {

        }

        private bool CanExecuteAddStudentCommand(object parameters) {
            return true;
        }
        private void ExecuteAddStudentCommand(object parameters)
        {
            var test1 = InputFirstName;
            var test2 = InputLastName;
            var test3 = InputDOB;
            var test4 = InputJoinDate;
            var test5 = InputStatus;
            var test6 = InputGender;
            //var test7 = StudentToAdd;
        }
    }
}
