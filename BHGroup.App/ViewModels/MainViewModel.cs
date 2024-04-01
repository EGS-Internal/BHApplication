using BHGroup.App.Public.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BHGroup.App.ViewModels
{
    class MainViewModel : ObservableObject
    {
        private object _currentView;
        private string _modeButton;
        private Style _buttonStyle;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public string ModeButton
        {
            get { return _modeButton; }
            set { _modeButton = value; OnPropertyChanged(); }
        }
        public Style MyButtonStyle
        {
            get { return _buttonStyle; }
            set { _buttonStyle = value; OnPropertyChanged(); }
        }
        public RelayCommand HomeCommand { get; private set; }
        public RelayCommand StudentCommand { get; private set; }
        public RelayCommand LecturerCommand { get; private set; }
        public RelayCommand ClassCommand { get; private set; }
        public RelayCommand CourseCommand { get; private set; }
        public RelayCommand ThemeCommand { get; private set; }
        private HomeViewModel HomeVM { get; set; }
        private StudentListViewModel StudentVM { get; set; }
        private LecturerListViewModel LecturerVM { get; set; }
        private ClassListViewModel ClassVM { get; set; }
        private CourseListViewModel CourseVM { get; set; }

        private bool flag = true;
        public MainViewModel()
        {
            ModeButton = "./Public/Image/sun.png";
            MyButtonStyle = (Style)Application.Current.FindResource("MenuButtonTheme");
            InitRequredBM();
            InitCommand();
            CurrentView = HomeVM;

        }
        private void InitRequredBM()
        {
            var services = DIHelper.Get().Services;
            HomeVM = services.GetRequiredService<HomeViewModel>();
            StudentVM = services.GetRequiredService<StudentListViewModel>();
            LecturerVM = services.GetRequiredService<LecturerListViewModel>();
            ClassVM = services.GetRequiredService<ClassListViewModel>();
            CourseVM = services.GetRequiredService<CourseListViewModel>();
        }
        private void InitCommand()
        {
            HomeCommand = new RelayCommand(ExecuteHomeCommand, CanExecuteHomeCommand);
            StudentCommand = new RelayCommand(ExecuteStudentCommand, CanExecuteStudentCommand);
            LecturerCommand = new RelayCommand(ExecuteLecturerCommand, CanExecuteLecturerCommand);
            ClassCommand = new RelayCommand(ExecuteClassCommand, CanExecuteClassCommand);
            CourseCommand = new RelayCommand(ExecuteCourseCommand, CanExecuteCourseCommand);
            ThemeCommand = new RelayCommand(ExecuteChangeTheme, CanExecuteChangeTheme);
        }
        private bool CanExecuteHomeCommand(object parameters)
        {
            return flag;
        }
        private void ExecuteHomeCommand(object parameters)
        {
            HomeNavigate();
        }
        private bool CanExecuteStudentCommand(object parameters)
        {
            return flag;
        }
        private void ExecuteStudentCommand(object parameters)
        {
            StudentNavigate();
        }
        private bool CanExecuteLecturerCommand(object parameters)
        {
            return flag;
        }
        private void ExecuteLecturerCommand(object parameters)
        {
            LecturerNavigate();
        }
        private bool CanExecuteClassCommand(object parameters)
        {
            return flag;
        }
        private void ExecuteClassCommand(object parameters)
        {
            ClassNavigate();
        }
        private bool CanExecuteCourseCommand(object parameters)
        {
            return flag;
        }
        private void ExecuteCourseCommand(object parameters)
        {
            CourseNavigate();
        }
        private bool CanExecuteChangeTheme(object parameters)
        {
            return true;
        }
        private void ExecuteChangeTheme(object parameters)
        {
            ChangeTheme();
        }
        private void HomeNavigate()
        {
            CurrentView = HomeVM;
        }
        private void StudentNavigate()
        {

            CurrentView = StudentVM;
        }
        private void LecturerNavigate()
        {
            CurrentView = LecturerVM;
        }
        private void ClassNavigate()
        {
            CurrentView = ClassVM;
        }
        private void CourseNavigate()
        {
            CurrentView = CourseVM;
        }
        private void ChangeTheme()
        {
            if (ModeButton == "./Public/Image/brightness.png")
            {
                ModeButton = "./Public/Image/sun.png";
                MyButtonStyle = (Style)Application.Current.FindResource("MenuButtonTheme");
                var DefaultDictionary = Application.Current.Resources.MergedDictionaries[3];
                DefaultDictionary["DefaultText"] = Application.Current.FindResource("DarkText");
                DefaultDictionary["DefaultTextBoxText"] = Application.Current.FindResource("DarkTextBoxText");
                DefaultDictionary["DefaultSearchBoxBackGround"] = Application.Current.FindResource("DarkSearchBoxBackGround");
                DefaultDictionary["DefaultAppBackground"] = Application.Current.FindResource("DarkAppBackground");
                DefaultDictionary["DefaultButtonBackGround"] = Application.Current.FindResource("DarkButtonBackGround");
                DefaultDictionary["DefaultCustomDataGrid"] = Application.Current.FindResource("DarkCustomDataGrid");
            }
            else
            {
                ModeButton = "./Public/Image/brightness.png";
                MyButtonStyle = (Style)Application.Current.FindResource("LightMenuButtonTheme");
                var DefaultDictionary = Application.Current.Resources.MergedDictionaries[3];
                DefaultDictionary["DefaultText"] = Application.Current.FindResource("LightText");
                DefaultDictionary["DefaultTextBoxText"] = Application.Current.FindResource("LightTextBoxText");
                DefaultDictionary["DefaultSearchBoxBackGround"] = Application.Current.FindResource("LightSearchBoxBackGround");
                DefaultDictionary["DefaultAppBackground"] = Application.Current.FindResource("LightAppBackground");
                DefaultDictionary["DefaultButtonBackGround"] = Application.Current.FindResource("LightButtonBackGround");
                DefaultDictionary["DefaultCustomDataGrid"] = Application.Current.FindResource("LightCustomDataGrid");
            }
        }
    }
}
