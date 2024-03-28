using BHGroup.App.Models;
using BHGroup.App.Public.Core;
using BHGroup.App.Views.LecturerWindow;
using BHGroup.App.Views.LecturerWindow;
using BHGroup.BL;
using BHGroup.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BHGroup.App.ViewModels.LecturerViewModel
{
    public class LecturerAddEditViewModel : ObservableObject
    {
        private ILecturer _lecturerContext;

        private LecturerModel _lecturerInputObject;
        public LecturerModel LecturerInputObject
        {
            get
            {
                return _lecturerInputObject;
            }
            set
            {
                _lecturerInputObject = value;
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

        public RelayCommand AddLecturerCommand { get; private set; }
        public RelayCommand EditLecturerCommand { get; private set; }

        private void InitCommandAndContext()
        {
            _lecturerContext = DIHelper.Get().Services.GetRequiredService<ILecturer>();
            AddLecturerCommand = new RelayCommand(ExecuteAddLecturerCommand, CanExecuteAddLecturerCommand);
            EditLecturerCommand = new RelayCommand(ExecuteEditLecturerCommand, CanExecuteEditLecturerCommand);
        }
        private bool CanExecuteAddLecturerCommand(object parameters)
        {
            return true;
        }
        private void ExecuteAddLecturerCommand(object parameters)
        {
            var view = (AddEditLecturerView)parameters;
            var inputFirstName = LecturerInputObject.InputFirstName;
            var inputLastName = LecturerInputObject.InputLastName;
            var inputDOB = LecturerInputObject.InputDOB;
            var inputJoinDate = LecturerInputObject.InputJoinDate;
            var inputGender = LecturerInputObject.InputGender;
            var inputStatus = LecturerInputObject.InputStatus;

            if (inputFirstName == null || inputLastName == null || inputDOB == null ||
                inputJoinDate == null || inputGender == null || inputStatus == null)
            {
                MessageBox.Show("Please fill in every required field", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var dob = inputDOB.Split("/").Select(d => int.Parse(d)).ToArray();
                var joinDate = inputJoinDate.Split("/").Select(d => int.Parse(d)).ToArray();
                _lecturerContext.Add(new Lecturer()
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
        public LecturerAddEditViewModel(int Staffcode)
        {
            InitCommandAndContext();
            var editLecturer = _lecturerContext.GetById(Staffcode);
            LecturerInputObject = new LecturerModel()
            {
                StaffCode = editLecturer.StaffCode,
                InputFirstName = editLecturer.FirstName,
                InputLastName = editLecturer.LastName,
                InputDOB = editLecturer.DateOfBirth.ToString(),
                InputJoinDate = editLecturer.JoinDate.ToString(),
                InputGender = editLecturer.Gender.ToString(),
                InputStatus = editLecturer.Status.ToString(),
            };
        }
        private bool CanExecuteEditLecturerCommand(object parameter)
        {
            return true;
        }
        private void ExecuteEditLecturerCommand(object parameters)
        {
            var view = (AddEditLecturerView)parameters;
            var inputFirstName = LecturerInputObject.InputFirstName;
            var inputLastName = LecturerInputObject.InputLastName;
            var inputDOB = LecturerInputObject.InputDOB;
            var inputJoinDate = LecturerInputObject.InputJoinDate;
            var inputGender = LecturerInputObject.InputGender;
            var inputStatus = LecturerInputObject.InputStatus;

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
                    _lecturerContext.Update(new Lecturer()
                    {
                        StaffCode = LecturerInputObject.StaffCode,
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

    }
}
