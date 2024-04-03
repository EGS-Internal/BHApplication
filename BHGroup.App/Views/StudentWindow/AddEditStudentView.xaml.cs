using BHGroup.App.Models;
using System.Windows;
using System.Windows.Data;
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

        private void Gender_KeyUp(object sender, KeyEventArgs e)
        {
            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(Gender.ItemsSource);

            itemsViewOriginal.Filter = ((option) =>
            {
                if (String.IsNullOrEmpty(Gender.Text)) return true;
                else
                {
                    if (option.ToString().Contains(Gender.Text, StringComparison.CurrentCultureIgnoreCase)) return true;
                    else return false;
                }
            });

            itemsViewOriginal.Refresh();
        }
        private void Status_KeyUp(object sender, KeyEventArgs e)
        {
            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(Status.ItemsSource);

            itemsViewOriginal.Filter = ((option) =>
            {
                if (String.IsNullOrEmpty(Status.Text)) return true;
                else
                {
                    if (option.ToString().Contains(Status.Text, StringComparison.CurrentCultureIgnoreCase)) return true;
                    else return false;
                }
            });

            itemsViewOriginal.Refresh();
        }
        private void Gender_GotFocus(object sender, RoutedEventArgs e)
        {
            Gender.IsDropDownOpen = true;
        }
        private void Status_GotFocus(object sender, RoutedEventArgs e)
        {
            Status.IsDropDownOpen = true;
        }
    }
}
