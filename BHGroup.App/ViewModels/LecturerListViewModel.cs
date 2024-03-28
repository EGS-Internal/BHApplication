using BHGroup.App.Models;
using BHGroup.App.Public.Core;
using BHGroup.App.ViewModels.LecturerViewModel;
using BHGroup.App.ViewModels.StudentViewModel;
using BHGroup.App.Views.LecturerWindow;
using BHGroup.App.Views.StudentWindow;
using BHGroup.BL;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BHGroup.App.ViewModels
{
    class LecturerListViewModel : ObservableObject
    {
        //context field
        private readonly ILecturer _lecturerContext;
        //private AddLecturerView _addLecturerWindow { get; set; }
        //
        private List<LecturerModel> lecturers { get; set; }
        public List<LecturerModel> Lecturers
        {
            get
            {
                return lecturers;
            }
            set
            {
                lecturers = value;
                OnPropertyChanged();
            }
        }

        private LecturerModel selectedItem;
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
            { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
                DeleteLecturerCommand.OnCanExecuteChanged();
                EditLecturerCommand.OnCanExecuteChanged();

            }
        }
        public LecturerListViewModel()
        {
            _lecturerContext = DIHelper.Get().Services.GetRequiredService<ILecturer>();
            Lecturers = _lecturerContext.GetAll().Select(s => new LecturerModel(s)).ToList();
            //OpenAddLecturerViewCommand = new RelayCommand(ExecuteAddLecturerWindowCommand, CanExecuteAddLecturerWindowCommand);
            DeleteLecturerCommand = new RelayCommand(ExecuteDeleteLecturerCommand, CanExecuteDeleteLecturerCommand);
            EditLecturerCommand = new RelayCommand(ExecuteEditLecturerCommand, CanExecuteEditLecturerCommand);
        }
        private bool CanExecuteOpenAddLecturerWindowCommand(object parameters)
        {
            return true;
        }
        private void ExecuteOpenAddStudentWindowCommand(object parameters)
        {
            var addStudentView = new AddEditStudentView();
            var AddStudentViewModel = new StudentAddEditViewModel();
            addStudentView.DataContext = AddStudentViewModel;
            if (addStudentView.ShowDialog() == true)
            {
                Lecturers = _lecturerContext.GetAll().Select(s => new LecturerModel(s)).ToList();
            }
        }


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
            MessageBoxResult result = MessageBox.Show("okay?", "Delete Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _lecturerContext.Delete(SelectedItem.StaffCode);
                Lecturers = _lecturerContext.GetAll().Select(s => new LecturerModel(s)).ToList();
                SelectedItem = null;
            }
        }

        private bool CanExecuteEditLecturerCommand(object parameters)
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

        private void ExecuteEditLecturerCommand(object parameters)
        {
            var addLecturerView = new AddEditLecturerView();
            var addLecturerViewModel = new LecturerAddEditViewModel(SelectedItem.StaffCode);
        }

        private bool CanExecuteAddLecturerCommand(object parameters)
        {
            return true;
        }
    }
}
