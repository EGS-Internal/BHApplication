using BHGroup.App.Public.Core;
using BHGroup.BL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.App.ViewModels
{
    class StudentVM : ObservableObject
    {
        private readonly IStudent studentContext;
        public StudentVM()
        {
            studentContext = DIHelper.Get().Services.GetRequiredService<IStudent>();
        }

    }
}
