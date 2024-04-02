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
        
    }
}
