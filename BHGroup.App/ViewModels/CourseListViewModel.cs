using BHGroup.App.Models;
using BHGroup.App.Public.Core;
using BHGroup.App.ViewModels.StudentViewModel;
using BHGroup.App.Views.StudentWindow;
using BHGroup.BL;
using log4net;
using Microsoft.Extensions.DependencyInjection;

using System.Windows;

namespace BHGroup.App.ViewModels
{
    class CourseListViewModel : ObservableObject
    {
        #region Data context & repositories
        private readonly ICourse _courseContext;
        private readonly ILog _log;
        #endregion

        #region Binding properties
        private List<CourseModel> _coursesList { get; set; }
        public List<CourseModel> CourseList
        {
            get
            {
                return _coursesList;
            }
            set
            {
                _coursesList = value;
                OnPropertyChanged();
            }
        }

        private List<CourseModel> _coursesListDisplay { get; set; }
        public List<CourseModel> CourseListDisplay
        {
            get
            {
                return _coursesListDisplay;
            }
            set
            {
                _coursesListDisplay = value;
                OnPropertyChanged();
            }
        }

        private CourseModel _selectedItem { get; set; }
        public CourseModel SelectedItem
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
                if (value == string.Empty)
                {
                    CourseListDisplay = CourseList;
                }
                else
                {
                    CourseListDisplay = CourseList.Where(s => s.CourseName.Contains(value, StringComparison.OrdinalIgnoreCase) || s.CourseCode.ToString().Contains(value)).ToList();
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

        public CourseListViewModel()
        {
            _courseContext = DIHelper.Get().Services.GetRequiredService<ICourse>();
            CourseList = _courseContext.GetAll().Select(s => new CourseModel(s)).ToList();
            CourseListDisplay = CourseList;
            SearchInput = string.Empty;
            _log = DIHelper.Get().Services.GetRequiredService<ILog>();
            OpenAddStudentViewCommand = new RelayCommand(ExecuteOpenAddStudentWindowCommand, CanExecuteOpenAddStudentWindowCommand);
            DeleteStudentCommand = new RelayCommand(ExecuteDeleteStudentCommand, CanExecuteDeleteStudentCommand);
            EditStudentCommand = new RelayCommand(ExecuteEditStudentCommand, CanExecuteEditStudentCommand);
            SearchCommand = new RelayCommand(ExecuteSearchCommand, CanExecuteSearchCommand);
        }
        #endregion
        #region Command Events
        private bool CanExecuteOpenAddStudentWindowCommand(object parameters)
        {
            return true;
        }
        private void ExecuteOpenAddStudentWindowCommand(object parameters)
        {
            //var addStudentView = new AddEditStudentView();
            //var AddStudentViewModel = new StudentAddEditViewModel();
            //addStudentView.DataContext = AddStudentViewModel;
            //if (addStudentView.ShowDialog() == true)
            //{
            //    CourseList = _courseContext.GetAll().Select(s => new CourseModel(s)).ToList();
            //    CourseListDisplay = CourseList;
            //    SearchInput = string.Empty;
            //}
            //_log.Info("First Log");
        }


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

        private void ExecuteDeleteStudentCommand(object parameters)
        {
            MessageBoxResult result = MessageBox.Show("You sure'bout that?", "Delete Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _courseContext.Delete(SelectedItem.CourseID);
                CourseList = _courseContext.GetAll().Select(s => new CourseModel(s)).ToList();
                CourseListDisplay = CourseList.Where(s => s.CourseName.Contains(SearchInput, StringComparison.OrdinalIgnoreCase) || s.CourseCode.ToString().Contains(SearchInput)).ToList();
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
            //var addStudentView = new AddEditStudentView();
            //var AddStudentViewModel = new StudentAddEditViewModel(SelectedItem.StudentCode);
            //addStudentView.DataContext = AddStudentViewModel;
            //if (addStudentView.ShowDialog() == true)
            //{
            //    CourseList = _courseContext.GetAll().Select(s => new CourseModel(s)).ToList();
            //    CourseListDisplay = CourseList.Where(s => s.CourseName.Contains(SearchInput, StringComparison.OrdinalIgnoreCase) || s.CourseCode.ToString().Contains(SearchInput)).ToList();
            //}
        }

        private bool CanExecuteSearchCommand(object parameters)
        {
            return true;
        }
        private void ExecuteSearchCommand(object parameters)
        {
            if (SearchInput != null)
            {
                var result = _courseContext.GetByName(SearchInput);
                CourseList = result.Select(s => new CourseModel(s)).ToList();
            }
            else
            {
                CourseList = _courseContext.GetAll().Select(s => new CourseModel(s)).ToList();
            }
        }
        #endregion
    }
}
