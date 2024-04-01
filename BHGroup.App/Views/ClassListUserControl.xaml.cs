using BHGroup.App.Public.Core;
using BHGroup.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
namespace BHGroup.App.Views
{
    /// <summary>
    /// Interaction logic for ClassListUserControl.xaml
    /// </summary>
    public partial class ClassListUserControl : UserControl
    {
        public ClassListUserControl()
        {
            InitializeComponent();
            DataContext = DIHelper.Get().Services.GetRequiredService<LecturerListViewModel>;
        }

        //public void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(e.Column.Header?.ToString()))
        //    {
        //        // Set a custom header based on the column name
        //        string columnHeader = e.PropertyName; // You may need to customize this based on your requirements

        //        // For example, if the property name is "LecturerId", customize the header to "Lecturer ID"
        //        if (columnHeader == "StaffCode")
        //            columnHeader = "Lecturer ID";
        //        // Similarly, customize other headers if needed

        //        e.Column.Header = columnHeader;
        //    }

        //}
    }
}
