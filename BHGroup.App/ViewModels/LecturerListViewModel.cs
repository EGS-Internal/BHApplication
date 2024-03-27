using BHGroup.App.Public.Core;
using BHGroup.BL;
using BHGroup.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BHGroup.App.Models;

namespace BHGroup.App.ViewModels
{
    class LecturerListViewModel : ObservableObject
    {
        private readonly ILecturer _lecturerContext;
        private List<LecturerModel> _lecturer { get; set; }

        public List<LecturerModel> Lecturers
        {
            get { return _lecturer; }
            set
            {
                _lecturer = value;
                OnPropertyChanged();
            }
        }
        public LecturerListViewModel()
        {
            _lecturerContext = DIHelper.Get().Services.GetRequiredService<ILecturer>();
            Lecturers = _lecturerContext.GetAll().Select(s => new LecturerModel(s)).ToList();
            //OpenAddStudentViewCommand = new RelayCommand(ExecuteOpenAddStudentWindowCommand, CanExecuteOpenAddStudentWindowCommand);
            //DeleteStudentCommand = new RelayCommand(ExecuteDeleteStudentCommand, CanExecuteDeleteStudentCommand);
            //EditStudentCommand = new RelayCommand(ExecuteEditStudentCommand, CanExecuteEditStudentCommand);
            //AddStudentCommand = new RelayCommand(ExecuteAddStudentCommand, CanExecuteAddStudentCommand);
            //StudentToAdd = new StudentInputModel();
        }
    }
}
