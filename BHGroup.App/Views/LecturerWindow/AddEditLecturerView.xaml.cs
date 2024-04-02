using BHGroup.App.Models;
using System.Windows;
using System.Windows.Input;

namespace BHGroup.App.Views.LecturerWindow
{
    /// <summary>
    /// Interaction logic for AddEditLecturerView.xaml
    /// </summary>
    public partial class AddEditLecturerView : Window
    {
        public LecturerModel LecturerToAdd { get; set; }
        public AddEditLecturerView()
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
