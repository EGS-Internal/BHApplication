using BHGroup.App.Models;
using System.Windows;
using System.Windows.Input;

namespace BHGroup.App.Views.StudentWindow
{
    /// <summary>
    /// Interaction logic for AddEditStudentView.xaml
    /// </summary>
    public partial class AddEditStudentView : Window
    {
        public StudentModel StudentToAdd { get; set; }
        public AddEditStudentView()
        {
            InitializeComponent();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = true;
            //this.Close();
        }
    }
}
