using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BHGroup.App.Views.CourseWindow
{
    /// <summary>
    /// Interaction logic for AddEditCourseView.xaml
    /// </summary>
    public partial class AddEditCourseView : Window
    {
        public AddEditCourseView()
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

   
        private void Lecturer_KeyUp(object sender, KeyEventArgs e)
        {
                CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(Lecturer.ItemsSource);

                itemsViewOriginal.Filter = ((option) =>
                {
                    if (String.IsNullOrEmpty(Lecturer.Text)) return true;
                    else
                    {
                        if (option.ToString().Contains(Lecturer.Text)) return true;
                        else return false;
                    }
                });

                itemsViewOriginal.Refresh();
        }
        private void Lecturer_GotFocus(object sender, RoutedEventArgs e)
        {
            Lecturer.IsDropDownOpen = true;
        }
    }
}
