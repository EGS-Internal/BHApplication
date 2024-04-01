using BHGroup.App.Public.Core;
using BHGroup.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace BHGroup.App.Views
{
    /// <summary>
    /// Interaction logic for CourseListUserControl.xaml
    /// </summary>
    public partial class LecturerListUserControl : UserControl
    {
        public LecturerListUserControl()
        {
            InitializeComponent();
            DataContext = DIHelper.Get().Services.GetRequiredService<LecturerListViewModel>();
        }
        //private void DataGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    // Get the clicked item
        //    var clickedItem = (sender as DataGrid).SelectedItem;

        //    // Check if the clicked item is already selected
        //    if (clickedItem != null && clickedItem.Equals(dataGrid.SelectedItem))
        //    {
        //        // Unselect the item
        //        dataGrid.SelectedItem = null;
        //    }
        //}
    }
}
