using BHGroup.App.Public.Core;
using System.Windows;

namespace BHGroup.App.ViewModels
{
    class MainViewModel : ObservableObject
    {
        private object _currentView;
        private string _modeButton;
        private string _theme;
        private string _textColor;
        private Style _buttonStyle;
        public object CurrentView
        {
            get { return _currentView; }
            set { 
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public string ModeButton
        {
            get { return _modeButton; }
            set { _modeButton = value; OnPropertyChanged();}
        }
        public string Theme
        {
            get { return _theme; }
            set { _theme = value; OnPropertyChanged(); }
        }
        public string TextColor
        {
            get { return _textColor; }
            set { _textColor = value; OnPropertyChanged(); }
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
        private HomeVM HomeVM { get; set; }
        private StudentVM StudentVM { get; set; }
        private LecturerVM LecturerVM { get; set; }
        private ClassVM ClassVM { get; set; }
        private CourseVM CourseVM { get; set; }

        private bool flag = true;
        public MainViewModel()
        {
            ModeButton = "./Public/Image/sun.png";
            Theme = "#272537";
            TextColor = "White";
            MyButtonStyle = (Style)Application.Current.FindResource("MenuButtonTheme");

            HomeVM = new HomeVM();
            StudentVM = new StudentVM();
            LecturerVM = new LecturerVM();
            ClassVM = new ClassVM();
            CourseVM = new CourseVM();
            CurrentView = HomeVM;
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
        private bool CanExecuteChangeTheme(object parameters) {
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
        private void ChangeTheme() {
            if(ModeButton == "./Public/Image/brightness.png")
            {
                ModeButton = "./Public/Image/sun.png";
                Theme = "#272537";
                TextColor = "White";
                MyButtonStyle = (Style)Application.Current.FindResource("MenuButtonTheme");
            }

            else
            {
                ModeButton = "./Public/Image/brightness.png";
                Theme = "White";
                TextColor = "Black";
                MyButtonStyle = (Style)Application.Current.FindResource("LightMenuButtonTheme");
            }
                
        }
    }
}
