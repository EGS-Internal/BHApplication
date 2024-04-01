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
        private List<StudentModel> _studentsList { get; set; }
        public List<StudentModel> StudentList
        {
            get
            {
                return _studentsList;
            }
            set
            {
                _studentsList = value; 
                OnPropertyChanged();
            }
        }

        private List<StudentModel> _studentsListDisplay { get; set; }
        public List<StudentModel> StudentListDisplay
        {
            get
            {
                return _studentsListDisplay;
            }
            set
            {
                _studentsListDisplay = value;
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
                    StudentListDisplay = StudentList;
                }
                else
                {
                    StudentListDisplay = StudentList.Where(s => s.FullName.Contains(value,StringComparison.OrdinalIgnoreCase) || s.StudentCode.ToString().Contains(value)).ToList();
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
            StudentList = _studentContext.GetAll().Select(s => new StudentModel(s)).ToList();
            StudentListDisplay = StudentList;
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
                StudentList = _studentContext.GetAll().Select(s => new StudentModel(s)).ToList();
                StudentListDisplay = StudentList;
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
                StudentList = _studentContext.GetAll().Select(s => new StudentModel(s)).ToList();
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
                StudentList = _studentContext.GetAll().Select(s => new StudentModel(s)).ToList();
                StudentListDisplay = StudentList.Where(s => s.FullName.Contains(SearchInput, StringComparison.OrdinalIgnoreCase) || s.StudentCode.ToString().Contains(SearchInput)).ToList();
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
                StudentList = result.Select(s => new StudentModel(s)).ToList();
            }
            else
            {
                StudentList = _studentContext.GetAll().Select(s => new StudentModel(s)).ToList();
            }
        }
        #endregion
    }
}
