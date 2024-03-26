using BHGroup.App.Public.Core;
using BHGroup.App.Views.StudentWindow;
using BHGroup.BL;
using BHGroup.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BHGroup.App.ViewModels
{
    public class CustomStudent : Student
    {
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
    class StudentViewModel : ObservableObject
    {
        private readonly IStudent _studentContext;
        private AddStudentWindow _addStudentWindow { get; set; }
        private ObservableCollection<CustomStudent> _students { get; set; }
        public ObservableCollection<CustomStudent> Students
        {
            get { return _students; }
            set { _students = value; OnPropertyChanged(); }
        }
        private CustomStudent _selectedItem { get; set; }
        public CustomStudent SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set { 
                _selectedItem = value; 
                OnPropertyChanged(); 
                DeleteStudentCommand.OnCanExecuteChanged();
            }
        }
        public RelayCommand AddStudentCommand {  get; private set; }
        public RelayCommand DeleteStudentCommand {  get; private set; }
        public RelayCommand EditStudentCommand { get; private set; }
        public StudentViewModel()
        {
            _studentContext = DIHelper.Get().Services.GetRequiredService<IStudent>();
            Students = new ObservableCollection<CustomStudent>() { 
                new CustomStudent() { 
                    LastName = "Binh",FirstName = "Vu",DateOfBirth = DateTime.Now,Gender = Person.EGender.male,JoinDate = DateTime.Now,Status = Person.EStatus.active,StudentCode = 123,
                },
                new CustomStudent() {
                    LastName = "Binh 2",FirstName = "Vu 2",DateOfBirth = DateTime.Now,Gender = Person.EGender.male,JoinDate = DateTime.Now,Status = Person.EStatus.inactive,StudentCode = 456,
                },
            };
            AddStudentCommand = new RelayCommand(ExecuteAddStudentCommand, CanExecuteAddStudentCommand);
            DeleteStudentCommand = new RelayCommand(ExecuteDeleteStudentCommand, CanExecuteDeleteStudentCommand);
            EditStudentCommand = new RelayCommand(ExecuteEditStudentCommand, CanExecuteEditStudentCommand);
        }
        private bool CanExecuteAddStudentCommand(object parameters)
        {
            return true;
        }
        private void ExecuteAddStudentCommand(object parameters)
        {
            _addStudentWindow = new AddStudentWindow();
            _addStudentWindow.ShowDialog();
            if(_addStudentWindow.StudentToAdd != null)
            {
                Students.Add(_addStudentWindow.StudentToAdd);
            }
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
            MessageBoxResult result = MessageBox.Show("You sure'bout that?", "Delete Confirm",MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                Students.Remove(SelectedItem);
                SelectedItem = null;
            }
        }
        private bool CanExecuteEditStudentCommand(object parameters)
        {
            return true;
        }
        private void ExecuteEditStudentCommand(object parameters)
        {

        }
    }
}
