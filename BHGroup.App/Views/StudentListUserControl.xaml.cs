using BHGroup.App.Public.Core;
using BHGroup.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace BHGroup.App.Views
{
    /// <summary>
    /// Interaction logic for CourseListUserControl.xaml
    /// </summary>
    public partial class StudentListUserControl : UserControl
    {
        public StudentListUserControl()
        {
            InitializeComponent();
            DataContext = DIHelper.Get().Services.GetRequiredService<StudentListViewModel>();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }


}
