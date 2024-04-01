﻿using BHGroup.App.Public.Core;
using BHGroup.BL;
using Microsoft.Extensions.DependencyInjection;
using System;
using BHGroup.App.ViewModels;
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
