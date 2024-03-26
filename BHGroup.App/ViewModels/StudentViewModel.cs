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
        private readonly IStudent studentContext;
        private ObservableCollection<CustomStudent> students { get; set; }
        private CustomStudent selectedItem { get; set; }
        private bool editVisibility {  get; set; }
        private bool deleteVisibility { get; set; }
        private AddStudentWindow addStudentWindow { get; set; }
        public ObservableCollection<CustomStudent> Students
        {
            get { return students; }
            set { students = value; OnPropertyChanged(); }
        }
        public CustomStudent SelectedItem
        {
            get => selectedItem;
            set { 
                selectedItem = value; 
                OnPropertyChanged(); 
                if(value != null)
                {
                    EditVisibility = true;
                    DeleteVisibility = true;
                }
                else
                {
                    EditVisibility = false;
                    DeleteVisibility = false;
                }
            }
        }
        public bool EditVisibility
        {
            get { return editVisibility; }
            set {  editVisibility = value; OnPropertyChanged(); }
        }
        public bool DeleteVisibility
        {
            get { return deleteVisibility; }
            set { deleteVisibility = value; OnPropertyChanged(); }
        }
        public RelayCommand AddStudent {  get; private set; }
        public RelayCommand DeleteStudent {  get; private set; }
        public RelayCommand EditStudent { get; private set; }
        public StudentViewModel()
        {
            studentContext = DIHelper.Get().Services.GetRequiredService<IStudent>();
            Students = new ObservableCollection<CustomStudent>() { 
                new CustomStudent() { 
                    LastName = "Binh",FirstName = "Vu",DateOfBirth = DateTime.Now,Gender = Person.EGender.male,JoinDate = DateTime.Now,Status = Person.EStatus.active,StudentCode = 123,
                },
                new CustomStudent() {
                    LastName = "Binh 2",FirstName = "Vu 2",DateOfBirth = DateTime.Now,Gender = Person.EGender.male,JoinDate = DateTime.Now,Status = Person.EStatus.inactive,StudentCode = 456,
                },
            };
            AddStudent = new RelayCommand(ExecuteAddStudentCommand, CanExecuteAddStudentCommand);
            DeleteStudent = new RelayCommand(ExecuteDeleteStudentCommand, CanExecuteDeleteStudentCommand);
            EditStudent = new RelayCommand(ExecuteEditStudentCommand, CanExecuteEditStudentCommand);
        }
        private bool CanExecuteAddStudentCommand(object parameters)
        {
            return true;
        }
        private void ExecuteAddStudentCommand(object parameters)
        {
            addStudentWindow = new AddStudentWindow();
            addStudentWindow.ShowDialog();
            Students.Add(addStudentWindow.StudentToAdd);
        }
        private bool CanExecuteDeleteStudentCommand(object parameters)
        {
            return true;
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
