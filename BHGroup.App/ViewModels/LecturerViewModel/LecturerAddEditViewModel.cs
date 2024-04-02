using BHGroup.App.Models;
using BHGroup.App.Public.Core;
using BHGroup.App.Views.LecturerWindow;
using BHGroup.BL;
using BHGroup.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows;
using System.Xml.Serialization;
using static BHGroup.DAL.Entities.Person;

namespace BHGroup.App.ViewModels.LecturerViewModel
{
    public class LecturerAddEditViewModel : ObservableObject,IDataErrorInfo
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
        public List<EStatus> StatusOptionSource { get; set; } = new List<EStatus>() {
            EStatus.Active,
            EStatus.Inactive,
        };
        public List<EGender> GenderOptionSource { get; set; } = new List<EGender>()
        {
            EGender.Male,
            EGender.Female,
        };

        public RelayCommand AddLecturerCommand { get; private set; }
        public RelayCommand EditLecturerCommand { get; private set; }

        string IDataErrorInfo.Error => throw new NotImplementedException();

        string IDataErrorInfo.this[string columnName] => throw new NotImplementedException();

        private void InitCommandAndContext()
        {
            _lecturerContext = DIHelper.Get().Services.GetRequiredService<ILecturer>();
            AddLecturerCommand = new RelayCommand(ExecuteAddLecturerCommand, CanExecuteAddLecturerCommand);
            EditLecturerCommand = new RelayCommand(ExecuteEditLecturerCommand, CanExecuteEditLecturerCommand);
        }
        //private bool dataValidate(LecturerAddEditViewModel viewmodel)
        //{
        //    Lecturer temp = viewmodel._lecturerInputObject();
        //}
        private bool CanExecuteAddLecturerCommand(object parameters)
        {
            return true;
        }
        private void ExecuteAddLecturerCommand(object parameters)
        {
            var view = (AddEditLecturerView)parameters;
            var inputFirstName = LecturerInputObject.FirstName;
            var inputLastName = LecturerInputObject.LastName;
            var inputDOB = LecturerInputObject.DateOfBirth;
            var inputJoinDate = LecturerInputObject.JoinDate;
            var inputGender = LecturerInputObject.Gender;
            //var inputStatus = LecturerInputObject.Status;

            if (inputFirstName == null || inputLastName == null || inputDOB == null ||
                inputJoinDate == null || inputGender == null)
            {
                MessageBox.Show("Please fill in every required field", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                //var dob = inputDOB.Split("/").Select(d => int.Parse(d)).ToArray();
                //var joinDate = inputJoinDate.Split("/").Select(d => int.Parse(d)).ToArray();
                _lecturerContext.Add(new Lecturer()
                {
                    FirstName = inputFirstName,
                    LastName = inputLastName,
                    DateOfBirth = inputDOB,
                    Gender = inputGender.ToString() == "Male" ? Person.EGender.Male : Person.EGender.Female,
                    JoinDate = inputJoinDate,
                    Status = BHGroup.DAL.Entities.Person.EStatus.Active
                });
                view.DialogResult = true;
                view.Close();
            }
        }

        public LecturerAddEditViewModel()
        {
            InitCommandAndContext();
            LecturerInputObject = new LecturerModel();
            LecturerInputObject.DateOfBirth = DateTime.Now;
            LecturerInputObject.JoinDate = DateTime.Now;
            AddVisibility = true;
        }
        public LecturerAddEditViewModel(int Staffcode)
        {
            InitCommandAndContext();
            var editLecturer = _lecturerContext.GetById(Staffcode);
            LecturerInputObject = new LecturerModel()
            {
                StaffCode = editLecturer.StaffCode,
                FirstName = editLecturer.FirstName,
                LastName = editLecturer.LastName,
                DateOfBirth = editLecturer.DateOfBirth,
                JoinDate = editLecturer.JoinDate,
                Gender = editLecturer.Gender,
                Status = editLecturer.Status,
            };
            AddVisibility = false;
        }

        private bool CanExecuteEditLecturerCommand(object parameter)
        {
            return true;
        }
        private void ExecuteEditLecturerCommand(object parameters)
        {
            var view = (AddEditLecturerView)parameters;
            var inputFirstName = LecturerInputObject.FirstName;
            var inputLastName = LecturerInputObject.LastName;
            var inputDOB = LecturerInputObject.DateOfBirth;
            var inputJoinDate = LecturerInputObject.JoinDate;
            var inputGender = LecturerInputObject.Gender;
            var inputStatus = LecturerInputObject.Status;

            if (inputFirstName == null || inputLastName == null || inputDOB == null ||
                inputJoinDate == null || inputGender == null || inputStatus == null)
            {
                MessageBox.Show("Please fill in every required field", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var result = MessageBox.Show("Confirm?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    //var dob = inputDOB.Split("/").Select(d => int.Parse(d)).ToArray();
                    //var joinDate = inputJoinDate.Split("/").Select(d => int.Parse(d)).ToArray();
                    _lecturerContext.Update(new Lecturer()
                    {
                        StaffCode = LecturerInputObject.StaffCode,
                        FirstName = inputFirstName,
                        LastName = inputLastName,
                        DateOfBirth = inputDOB,
                        Gender = inputGender == DAL.Entities.Person.EGender.Male ? Person.EGender.Male : DAL.Entities.Person.EGender.Female,
                        JoinDate = inputJoinDate,
                        Status = inputStatus == DAL.Entities.Person.EStatus.Active ? Person.EStatus.Active : DAL.Entities.Person.EStatus.Inactive,
                    });
                    view.DialogResult = true;
                    view.Close();
                }
            }
        }


    }
}
