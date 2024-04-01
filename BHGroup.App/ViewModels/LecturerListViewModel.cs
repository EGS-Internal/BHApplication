using BHGroup.App.Models;
using BHGroup.App.Public.Core;
using BHGroup.App.ViewModels.LecturerViewModel;
using BHGroup.App.Views.LecturerWindow;
using BHGroup.BL;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BHGroup.App.ViewModels
{
    class LecturerListViewModel : ObservableObject
    {
        #region Datacontext
        private readonly ILecturer _lecturerContext;
        #endregion
        #region Properties Binding
        private List<LecturerModel> _lecturerList { get; set; }
        public List<LecturerModel> LecturerList
        {
            get
            {
                return _lecturerList;
            }
            set
            {
                _lecturerList = value;
                OnPropertyChanged();
            }
        }
        private List<LecturerModel> _lecturerListDisplay { get; set; }
        public List<LecturerModel> LecturerListDisplay
        {
            get
            {
                return _lecturerListDisplay;
            }
            set
            {
                _lecturerListDisplay = value;
                OnPropertyChanged();
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
                    LecturerListDisplay = LecturerList;
                }
                else
                {
                    LecturerListDisplay = LecturerList.Where(s => s.FullName.Contains(value, StringComparison.OrdinalIgnoreCase) || s.StaffCode.ToString().Contains(value)).ToList();
                }
                _searchInput = value;
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
                //if (selectedItem != value)
                //{
                    selectedItem = value;
                    OnPropertyChanged();
                    DeleteLecturerCommand.OnCanExecuteChanged();
                    EditLecturerCommand.OnCanExecuteChanged();
                //}
                //else selectedItem = null;
            }
        }
        #endregion
        #region Relay Commands
        public RelayCommand OpenAddLecturerViewCommand { get; private set; }
        public RelayCommand DeleteLecturerCommand { get; private set; }
        public RelayCommand EditLecturerCommand { get; private set; }
        public RelayCommand SearchCommand { get; private set; }
        #endregion
        #region Command Events
        public LecturerListViewModel()
        {
            _lecturerContext = DIHelper.Get().Services.GetRequiredService<ILecturer>();
            LecturerList = _lecturerContext.GetAll().Select(s => new LecturerModel(s)).ToList();
            LecturerListDisplay = LecturerList;
            //SearchInput = string.Empty;
            OpenAddLecturerViewCommand = new RelayCommand(ExecuteOpenAddLecturerWindowCommand, CanExecuteOpenAddLecturerWindowCommand);
            DeleteLecturerCommand = new RelayCommand(ExecuteDeleteLecturerCommand, CanExecuteDeleteLecturerCommand);
            EditLecturerCommand = new RelayCommand(ExecuteEditLecturerCommand, CanExecuteEditLecturerCommand);
            SearchCommand = new RelayCommand(ExecuteSearchCommand, CanExecuteSearchCommand);
        }
        private bool CanExecuteOpenAddLecturerWindowCommand(object parameters)
        {
            return true;
        }
        private void ExecuteOpenAddLecturerWindowCommand(object parameters)
        {
            var addLecturerView = new AddEditLecturerView();
            var AddLecturerViewModel = new LecturerAddEditViewModel();
            addLecturerView.DataContext = AddLecturerViewModel;
            if (addLecturerView.ShowDialog() == true)
            {
                LecturerList = _lecturerContext.GetAll().Select(s => new LecturerModel(s)).ToList();
                LecturerListDisplay = LecturerList;
                SearchInput = string.Empty;
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
                var result = _lecturerContext.GetByName(SearchInput);
                LecturerList = result.Select(s => new LecturerModel(s)).ToList();
            }
            else
            {
                LecturerList = _lecturerContext.GetAll().Select(s => new LecturerModel(s)).ToList();
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
            MessageBoxResult result = MessageBox.Show("You sure'bout that?", "Delete Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _lecturerContext.Delete(SelectedItem.StaffCode);
                LecturerList = _lecturerContext.GetAll().Select(s => new LecturerModel(s)).ToList();
                LecturerListDisplay = LecturerList.Where(s => s.FullName.Contains(SearchInput, StringComparison.OrdinalIgnoreCase) || s.StaffCode.ToString().Contains(SearchInput)).ToList();
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

        


        private void ExecuteEditLecturerCommand(object parameters)
        {
            var addLecturerView = new AddEditLecturerView();
            var AddLecturerViewModel = new LecturerAddEditViewModel(SelectedItem.StaffCode);
            addLecturerView.DataContext = AddLecturerViewModel;
            if (addLecturerView.ShowDialog() == true)
            {
                LecturerList = _lecturerContext.GetAll().Select(s => new LecturerModel(s)).ToList();
            }
        }
        #endregion
    }
}
