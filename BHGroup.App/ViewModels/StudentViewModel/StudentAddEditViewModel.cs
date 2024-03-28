using BHGroup.App.Models;
using BHGroup.App.Public.Core;
using BHGroup.App.Views.StudentWindow;
using BHGroup.BL;
using BHGroup.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        private bool addVisibility {  get; set; }
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
            StudentInputObject = new StudentModel() { 
                StudentCode = editStudent.StudentCode,
                InputFirstName = editStudent.FirstName,
                InputLastName = editStudent.LastName,
                InputDOB = editStudent.DateOfBirth.ToString(),
                InputJoinDate = editStudent.JoinDate.ToString(),
                InputGender = editStudent.Gender.ToString(),
                InputStatus = editStudent.Status.ToString(),
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
            var inputFirstName = StudentInputObject.InputFirstName;
            var inputLastName = StudentInputObject.InputLastName;
            var inputDOB = StudentInputObject.InputDOB;
            var inputJoinDate = StudentInputObject.InputJoinDate;
            var inputGender = StudentInputObject._inputGender;
            var inputStatus = StudentInputObject.InputStatus;

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
            var inputFirstName = StudentInputObject.InputFirstName;
            var inputLastName = StudentInputObject.InputLastName;
            var inputDOB = StudentInputObject.InputDOB;
            var inputJoinDate = StudentInputObject.InputJoinDate;
            var inputGender = StudentInputObject._inputGender;
            var inputStatus = StudentInputObject.InputStatus;

            if (inputFirstName == null || inputLastName == null || inputDOB == null ||
                inputJoinDate == null || inputGender == null || inputStatus == null)
            {
                MessageBox.Show("Please fill in every required field", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var result = MessageBox.Show("You sure?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    var dob = inputDOB.Split("/").Select(d => int.Parse(d)).ToArray();
                    var joinDate = inputJoinDate.Split("/").Select(d => int.Parse(d)).ToArray();
                    _studentContext.Update(new Student()
                    {
                        StudentCode = StudentInputObject.StudentCode,
                        FirstName = inputFirstName,
                        LastName = inputLastName,
                        DateOfBirth = new DateTime(dob[2], dob[1], dob[0]),
                        Gender = inputGender == "Male" ? Person.EGender.Male : Person.EGender.Female,
                        JoinDate = new DateTime(joinDate[2], joinDate[1], joinDate[0]),
                        Status = inputStatus == "Active" ? Person.EStatus.Active : Person.EStatus.Inactive,
                    });
                    view.DialogResult = true;
                    view.Close();
                }
            }
        }
        #endregion
    }
}
