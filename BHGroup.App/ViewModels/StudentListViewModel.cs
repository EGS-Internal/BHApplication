using BHGroup.App.Models;
using BHGroup.App.Public.Core;
using BHGroup.App.ViewModels.StudentViewModel;
using BHGroup.App.Views.StudentWindow;
using BHGroup.BL;
using BHGroup.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
    
namespace BHGroup.App.ViewModels
{
    class StudentListViewModel : ObservableObject
    {
        #region Data context & repositories
        private readonly IStudent _studentContext;
        #endregion

        #region Binding properties
        private List<StudentModel> _students { get; set; }
        public List<StudentModel> Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value; 
                OnPropertyChanged();
            }
        }

        private StudentModel _selectedItem { get; set; }
        public StudentModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                DeleteStudentCommand.OnCanExecuteChanged();
                EditStudentCommand.OnCanExecuteChanged();
            }
        }

        private string _searchInput;
        public string SearchInput
        {
            get
            {
                return _searchInput; 
            }
            set
            {
                if(value == string.Empty)
                {
                    Students = _studentContext.GetAll().Select(s => new StudentModel(s)).ToList();
                }
                _searchInput = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public RelayCommand OpenAddStudentViewCommand { get; private set; }
        public RelayCommand DeleteStudentCommand { get; private set; }
        public RelayCommand EditStudentCommand { get; private set; }
        public RelayCommand SearchCommand { get; private set; }
        #endregion
        public StudentListViewModel()
        {
            _studentContext = DIHelper.Get().Services.GetRequiredService<IStudent>();
            Students = _studentContext.GetAll().Select(s => new StudentModel(s)).ToList();
            OpenAddStudentViewCommand = new RelayCommand(ExecuteOpenAddStudentWindowCommand, CanExecuteOpenAddStudentWindowCommand);
            DeleteStudentCommand = new RelayCommand(ExecuteDeleteStudentCommand, CanExecuteDeleteStudentCommand);
            EditStudentCommand = new RelayCommand(ExecuteEditStudentCommand, CanExecuteEditStudentCommand);
            SearchCommand = new RelayCommand(ExecuteSearchCommand, CanExecuteSearchCommand);
        }

        #region Command Events

        private bool CanExecuteOpenAddStudentWindowCommand(object parameters)
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
                Students = _studentContext.GetAll().Select(s => new StudentModel(s)).ToList();
            }  
        }

        //Check if any students are selected
        private bool CanExecuteDeleteStudentCommand(object parameters)
        {
            if (SelectedItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Run the Delete Student Command 
        private void ExecuteDeleteStudentCommand(object parameters)
        {
            MessageBoxResult result = MessageBox.Show("You sure'bout that?", "Delete Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
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
                return true;
            }
            else
            {
                return false;
            }
        }
        private void ExecuteEditStudentCommand(object parameters)
        {
            var addStudentView = new AddEditStudentView();
            var AddStudentViewModel = new StudentAddEditViewModel(SelectedItem.StudentCode);
            addStudentView.DataContext = AddStudentViewModel;
            if (addStudentView.ShowDialog() == true)
            {
                Students = _studentContext.GetAll().Select(s => new StudentModel(s)).ToList();
            }
        }

        private bool CanExecuteSearchCommand(object parameters)
        {
            return true;
        }
        private void ExecuteSearchCommand(object parameters)
        {
            if (SearchInput != null)
            {
                var result = _studentContext.GetByName(SearchInput);
                Students = result.Select(s => new StudentModel(s)).ToList();
            }
            else
            {
                Students = _studentContext.GetAll().Select(s => new StudentModel(s)).ToList();
            }
        }
        #endregion
    }
}
