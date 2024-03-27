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

        private StudentModel _studentToAdd { get; set; }
        public StudentModel StudentToAdd {
            get { return _studentToAdd; }
            set { _studentToAdd = value; OnPropertyChanged(); }
        }

        private bool _isButtonEnabled;
        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set
            {
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
            StudentToAdd = new StudentModel();
        }

        private bool CanExecuteOpenAddStudentWindowCommand(object parameters)
        {
            return true;
        }
        private void ExecuteOpenAddStudentWindowCommand(object parameters)
        {
            _addStudentWindow = new AddStudentView();
            var result = _addStudentWindow.ShowDialog();
            Students = _studentContext.GetAll().Select(s =>
            {
                return new StudentModel()
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    StudentCode = s.StudentCode,
                    DateOfBirth = s.DateOfBirth,
                    Gender = s.Gender,
                    JoinDate = s.JoinDate,
                    Status = s.Status
                };
            }).ToList();

        }

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
        private void ExecuteDeleteStudentCommand(object parameters)
        {
            MessageBoxResult result = MessageBox.Show("You sure'bout that?", "Delete Confirm",MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                _studentContext.Delete(SelectedItem.StudentCode);
                Students = _studentContext.GetAll().Select(s => new StudentModel(s)).ToList();
                SelectedItem = null;
            }
        }

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
            var inputFirstName = StudentToAdd.InputFirstName;
            var inputLastName = StudentToAdd.InputLastName;
            var inputDOB = StudentToAdd.InputDOB;
            var inputJoinDate = StudentToAdd.InputJoinDate;
            var inputGender = StudentToAdd._inputGender;
            var inputStatus = StudentToAdd.InputStatus;

            if (inputFirstName == null || inputLastName == null || inputDOB == null ||
                inputJoinDate == null || inputGender == null || inputStatus == null)
            {
                MessageBox.Show("Please fill in every required field", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var dob = inputDOB.Split("/").Select(d => int.Parse(d)).ToArray();
                var joinDate = inputJoinDate.Split("/").Select(d => int.Parse(d)).ToArray();
                _studentContext.Add(new Student()
                {
                    FirstName = inputFirstName,
                    LastName = inputLastName,
                    DateOfBirth = new DateTime(dob[2], dob[1], dob[0]),
                    Gender = inputGender == "Male" ? Person.EGender.Male : Person.EGender.Female,
                    JoinDate = new DateTime(joinDate[2], joinDate[1], joinDate[0]),
                    Status = inputStatus == "Active" ? Person.EStatus.Active : Person.EStatus.Inactive,
                });
            }
        }
    }
}
