using BHGroup.App.Public.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.App.Models
{
    class StudentInputModel : ObservableObject
    {
        private string _inputFirstName { get; set; }
        public string InputFirstName
        {
            get { return _inputFirstName; }
            set { _inputFirstName = value; OnPropertyChanged(); }
        }

        private string _inputLastName { get; set; }
        public string InputLastName
        {
            get { return _inputLastName; }
            set { _inputLastName = value; OnPropertyChanged(); }
        }

        private string _inputDOB { get; set; }
        public string InputDOB
        {
            get { return _inputDOB; }
            set { _inputDOB = value; OnPropertyChanged(); }
        }

        private string _inputJoinDate { get; set; }
        public string InputJoinDate
        {
            get { return _inputJoinDate; }
            set { _inputJoinDate = value; OnPropertyChanged(); }
        }

        public string _inputGender { get; set; }
        public string InputGender
        {
            get { return _inputGender; }
            set { _inputGender = value; OnPropertyChanged(); }
        }

        public string _inputStatus { get; set; }
        public string InputStatus
        {
            get { return _inputStatus; }
            set { _inputStatus = value; OnPropertyChanged(); }
        }
    }
}
