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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BHGroup.App.Public.Core;
using BHGroup.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;
namespace BHGroup.App.Views
{
    /// <summary>
    /// Interaction logic for LecturerView.xaml
    /// </summary>
    public partial class LecturerView : UserControl
    {
        public LecturerView()
        {
            InitializeComponent();
            DataContext = DIHelper.Get().Services.GetRequiredService<LecturerViewModel>;
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
