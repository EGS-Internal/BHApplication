using BHGroup.App.Public.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.App.ViewModels
{
    class MainViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { 
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public HomeVM HomeVM { get; set; }

        public MainViewModel()
        {
            HomeVM = new HomeVM();
            CurrentView = HomeVM;
        }
    }
}
