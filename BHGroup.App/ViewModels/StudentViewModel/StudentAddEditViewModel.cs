using BHGroup.App.Models;
using BHGroup.App.Public.Core;
using BHGroup.App.Views.StudentWindow;
using BHGroup.BL;
using BHGroup.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public List<EStatus> StatusOptionSource { get; set; } = new List<EStatus>() { 
            EStatus.Active,
            EStatus.Inactive,
        };
        public List<EGender> GenderOptionSource { get; set; } = new List<EGender>() 
        {
            EGender.Male, 
            EGender.Female,
        };
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
                InputGender = editStudent.Gender,
                InputStatus = editStudent.Status,
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
            var inputGender = StudentInputObject.InputGender;
            var inputStatus = StudentInputObject.InputStatus;

            if (inputFirstName == null || inputLastName == null || 
                inputDOB == null || inputJoinDate == null)
            {
                MessageBox.Show("Please fill in every required field", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                _studentContext.Add(new Student()
                {
                    FirstName = inputFirstName,
                    LastName = inputLastName,
                    DateOfBirth = DateTime.Parse(inputDOB, CultureInfo.InvariantCulture),
                    Gender = inputGender ,
                    JoinDate = DateTime.Parse(inputJoinDate,CultureInfo.InvariantCulture),
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
            var inputFirstName = StudentInputObject.InputFirstName;
            var inputLastName = StudentInputObject.InputLastName;
            var inputDOB = StudentInputObject.InputDOB;
            var inputJoinDate = StudentInputObject.InputJoinDate;
            var inputGender = StudentInputObject.InputGender;
            var inputStatus = StudentInputObject.InputStatus;

            if (inputFirstName == null || inputLastName == null || 
                inputDOB == null || inputJoinDate == null)
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
                        DateOfBirth = DateTime.Parse(inputDOB, CultureInfo.InvariantCulture),
                        Gender = inputGender,
                        JoinDate = DateTime.Parse(inputJoinDate, CultureInfo.InvariantCulture),
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
