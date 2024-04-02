using BHGroup.App.Models;
using BHGroup.App.Public.Core;
using BHGroup.App.Views.StudentWindow;
using BHGroup.BL;
using BHGroup.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using static BHGroup.DAL.Entities.Person;

namespace BHGroup.App.ViewModels.StudentViewModel
{
    class StudentAddEditViewModel : ObservableObject
    {
        #region Data context & repositories
        private IStudent _studentContext;
        #endregion

        #region Binding
        private StudentModel _studentInputObject { get; set; }
        public StudentModel StudentInputObject
        {
            get
            {
                return _studentInputObject;
            }
            set
            {
                _studentInputObject = value;
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
        public List<EStatus> StatusOptionSource { get; set; } = new List<EStatus>() {
            EStatus.Active,
            EStatus.Inactive,
        };
        public List<EGender> GenderOptionSource { get; set; } = new List<EGender>()
        {
            EGender.Male,
            EGender.Female,
        };
        #endregion

        #region Command
        public RelayCommand AddStudentCommand { get; private set; }
        public RelayCommand EditStudentCommand { get; private set; }

        #endregion

        private void InitCommandAndContext()
        {
            _studentContext = DIHelper.Get().Services.GetRequiredService<IStudent>();
            AddStudentCommand = new RelayCommand(ExecuteAddStudentCommand, CanExecuteAddStudentCommand);
            EditStudentCommand = new RelayCommand(ExecuteEditStudentCommand, CanExecuteEditStudentCommand);
        }
        //constructor
        public StudentAddEditViewModel()
        {
            InitCommandAndContext();
            StudentInputObject = new StudentModel();
            AddVisibility = true;

        }
        public StudentAddEditViewModel(int studentCode)
        {
            InitCommandAndContext();
            var editStudent = _studentContext.GetById(studentCode);
            StudentInputObject = new StudentModel()
            {
                StudentCode = editStudent.StudentCode,
                FirstName = editStudent.FirstName,
                LastName = editStudent.LastName,
                DateOfBirth = editStudent.DateOfBirth,
                JoinDate = editStudent.JoinDate,
                Gender = editStudent.Gender,
                Status = editStudent.Status,
            };
            AddVisibility = false;
        }

        #region Command events
        private bool CanExecuteAddStudentCommand(object parameters)
        {
            return true;
        }
        private void ExecuteAddStudentCommand(object parameters)
        {
            var view = (AddEditStudentView)parameters;
            var inputFirstName = StudentInputObject.FirstName;
            var inputLastName = StudentInputObject.LastName;
            var inputDOB = StudentInputObject.DateOfBirth;
            var inputJoinDate = StudentInputObject.JoinDate;
            var inputGender = StudentInputObject.Gender;
            var inputStatus = StudentInputObject.Status;

            if (string.IsNullOrWhiteSpace(inputFirstName) || string.IsNullOrWhiteSpace(inputLastName))
            {
                MessageBox.Show("Please fill in every required field", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                _studentContext.Add(new Student()
                {
                    FirstName = inputFirstName,
                    LastName = inputLastName,
                    DateOfBirth = inputDOB,
                    Gender = inputGender,
                    JoinDate = inputJoinDate,
                    Status = inputStatus,
                });
                view.DialogResult = true;
                view.Close();
            }
        }
        private bool CanExecuteEditStudentCommand(object parameters)
        {
            return true;
        }
        private void ExecuteEditStudentCommand(object parameters)
        {
            var view = (AddEditStudentView)parameters;
            var inputFirstName = StudentInputObject.FirstName;
            var inputLastName = StudentInputObject.LastName;
            var inputDOB = StudentInputObject.DateOfBirth;
            var inputJoinDate = StudentInputObject.JoinDate;
            var inputGender = StudentInputObject.Gender;
            var inputStatus = StudentInputObject.Status;

            if (string.IsNullOrWhiteSpace(inputFirstName) || string.IsNullOrWhiteSpace(inputLastName))
            {
                MessageBox.Show("Please fill in every required field", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var result = MessageBox.Show("You sure?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    _studentContext.Update(new Student()
                    {
                        StudentCode = StudentInputObject.StudentCode,
                        FirstName = inputFirstName,
                        LastName = inputLastName,
                        DateOfBirth = inputDOB,
                        Gender = inputGender,
                        JoinDate = inputJoinDate,
                        Status = inputStatus,
                    });
                    view.DialogResult = true;
                    view.Close();
                }
            }
        }
        #endregion
    }
}
