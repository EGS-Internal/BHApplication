using BHGroup.App.Models;
using BHGroup.App.ViewModels;
using BHGroup.DAL.Entities;
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
            this.Close();
        }
    }
}
