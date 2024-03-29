using BHGroup.App.Models;
using BHGroup.App.Public.Core;
using BHGroup.BL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Windows;
using System.Windows;
using BHGroup.App.Views.LecturerWindow;

namespace BHGroup.App.ViewModels
{
    class LecturerListViewModel : ObservableObject
    {
        //context field
        private readonly ILecturer _lecturerContext;
        //private AddLecturerView _addLecturerWindow { get; set; }
        //
        private List<LecturerModel> _lecturer { get; set; }

        private LecturerModel _selectedItem;
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

        public LecturerModel SelectedItem
        {
            get
            { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                DeleteLecturerCommand.OnCanExecuteChanged();
                EditLecturerCommand.OnCanExecuteChanged();
            }
        }


        public List<LecturerModel> Lecturers
        {
            get
            {
                return _lecturer;
            }
            set
            {
                _lecturer = value;
                OnPropertyChanged();
                
            }
        }
        public LecturerListViewModel()
        {
            _lecturerContext = DIHelper.Get().Services.GetRequiredService<ILecturer>();
            Lecturers = _lecturerContext.GetAll().Select(s => new LecturerModel(s)).ToList();
            //OpenAddLecturerViewCommand = new RelayCommand(ExecuteAddLecturerWindowCommand, CanExecuteAddLecturerWindowCommand);
            DeleteLecturerCommand = new RelayCommand(ExecuteDeleteLecturerCommand, CanExecuteLecturerCommand);
            EditLecturerCommand = new RelayCommand(ExecuteEditLecturerCommand, CanExecuteLecturerCommand);
            //AddLecturerCommand = new RelayCommand(ExecuteAddLecturerCommand, CanExecuteAddLecturerCommand);
            //StudentToAdd = new StudentInputModel();
        }
        private bool CanExecuteOpenAddStudentWindowCommand(object parameters)
        {
            return true;
        }
        //private void ExecuteOpenAddLecturerWindowCommand(object parameters)
        //{
        //    _addLecturerWindow = new AddLecturerView();
        //    var result = _addLecturerWindow.ShowDialog();
        //    if (_addLecturerWindow.StudentToAdd != null)
        //    {
        //        _studentContext.Add(new Student()
        //        {
        //            FirstName = _addLecturerWindow.StudentToAdd.FirstName,
        //            LastName = _addLecturerWindow.StudentToAdd.LastName,
        //            DateOfBirth = _addLecturerWindow.StudentToAdd.DateOfBirth,
        //            Gender = _addLecturerWindow.StudentToAdd.Gender,
        //            JoinDate = _addLecturerWindow.StudentToAdd.JoinDate,
        //            Status = _addLecturerWindow.StudentToAdd.Status
        //        });
        //        StudentList = _studentContext.GetAll().Select(s =>
        //        {
        //            return new StudentModel()
        //            {
        //                FirstName = s.FirstName,
        //                LastName = s.LastName,
        //                StudentCode = s.StudentCode,
        //                DateOfBirth = s.DateOfBirth,
        //                Gender = s.Gender,
        //                JoinDate = s.JoinDate,
        //                Status = s.Status
        //            };
        //        }).ToList();
        //    }
        //}
        

        private bool CanExecuteDeleteLecturerCommand(object parameters)
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
        private void ExecuteDeleteLecturerCommand(object parameters)
        {
            MessageBoxResult result = MessageBox.Show("You sure'bout that?", "Delete Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _lecturerContext.Delete(SelectedItem.StaffCode);
                Lecturers = _lecturerContext.GetAll().Select(s => new LecturerModel(s)).ToList();
                SelectedItem = null;
            }
        }

        private bool CanExecuteLecturerCommand(object parameters)
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
        public RelayCommand OpenAddLecturerViewCommand { get; private set; }
        public RelayCommand DeleteLecturerCommand { get; private set; }
        public RelayCommand EditLecturerCommand { get; private set; }
        public RelayCommand AddLecturerCommand { get; private set; }

        private void ExecuteEditLecturerCommand(object parameters)
        {

        }

        private bool CanExecuteAddStudentCommand(object parameters)
        {
            return true;
        }
    }
}
