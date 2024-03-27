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

namespace BHGroup.App.ViewModels
{
    class LecturerVM : ObservableObject
    {
        private readonly ILecturer lecturer;
        //public LecturerViewModel(ILecturer lecturer)
        //{
        //    this.lecturer = lecturer;
        //}
    }
}
