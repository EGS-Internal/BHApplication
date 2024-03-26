﻿using System;
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
            DataContext = DIHelper.Get().Services.GetRequiredService<Data>
        }
    }
}
