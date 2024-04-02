using BHGroup.App.Models;
using BHGroup.App.Public.Core;
using BHGroup.App.ViewModels.CourseViewModel;
using BHGroup.App.ViewModels.StudentViewModel;
using BHGroup.App.Views.CourseWindow;
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
                DeleteCourseCommand.OnCanExecuteChanged();
                EditCourseCommand.OnCanExecuteChanged();
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
        public RelayCommand OpenAddCourseViewCommand { get; private set; }
        public RelayCommand DeleteCourseCommand { get; private set; }
        public RelayCommand EditCourseCommand { get; private set; }
        public RelayCommand SearchCommand { get; private set; }

        public CourseListViewModel()
        {
            _courseContext = DIHelper.Get().Services.GetRequiredService<ICourse>();
            CourseList = _courseContext.GetAll().Select(s => new CourseModel(s)).ToList();
            CourseListDisplay = CourseList;
            SearchInput = string.Empty;
            _log = DIHelper.Get().Services.GetRequiredService<ILog>();
            OpenAddCourseViewCommand = new RelayCommand(ExecuteOpenAddCourseWindowCommand, CanExecuteOpenAddCourseWindowCommand);
            DeleteCourseCommand = new RelayCommand(ExecuteDeleteCourseCommand, CanExecuteDeleteCourseCommand);
            EditCourseCommand = new RelayCommand(ExecuteEditCourseCommand, CanExecuteEditCourseCommand);
            SearchCommand = new RelayCommand(ExecuteSearchCommand, CanExecuteSearchCommand);
        }
        #endregion
        #region Command Events
        private bool CanExecuteOpenAddCourseWindowCommand(object parameters)
        {
            return true;
        }
        private void ExecuteOpenAddCourseWindowCommand(object parameters)
        {
            var addCourseView = new AddEditCourseView();
            var AddCourseViewModel = new CourseAddEditViewModel();
            addCourseView.DataContext = AddCourseViewModel;
            if (addCourseView.ShowDialog() == true)
            {
                CourseList = _courseContext.GetAll().Select(s => new CourseModel(s)).ToList();
                CourseListDisplay = CourseList;
                SearchInput = string.Empty;
            }
        }


        private bool CanExecuteDeleteCourseCommand(object parameters)
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

        private void ExecuteDeleteCourseCommand(object parameters)
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

        private bool CanExecuteEditCourseCommand(object parameters)
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
        private void ExecuteEditCourseCommand(object parameters)
        {
            var addCourseView = new AddEditCourseView();
            var AddCourseViewModel = new CourseAddEditViewModel(SelectedItem.CourseID);
            addCourseView.DataContext = AddCourseViewModel;
            if (addCourseView.ShowDialog() == true)
            {
                CourseList = _courseContext.GetAll().Select(s => new CourseModel(s)).ToList();
                CourseListDisplay = CourseList.Where(s => s.CourseName.Contains(SearchInput, StringComparison.OrdinalIgnoreCase) || s.CourseCode.ToString().Contains(SearchInput)).ToList();
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
