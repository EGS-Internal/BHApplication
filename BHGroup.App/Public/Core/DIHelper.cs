using BHGroup.App.ViewModels;
using BHGroup.BL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.App.Public.Core
{
    class DIHelper
    {
        public IServiceProvider Services { get; }
        private static DIHelper dIHelper;
        public static DIHelper Get()
        {
            dIHelper ??= new DIHelper();
            return dIHelper;
        }
        public DIHelper() {
            Services = ConfigureServices();
        }
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IStudent, BLStudent>();
            services.AddSingleton<ICourse, BLCourse>();
            services.AddSingleton<ILecturer, BLLecturer>();

            services.AddTransient<MainViewModel, MainViewModel>();
            services.AddTransient<HomeVM, HomeVM>();
            services.AddTransient<StudentVM, StudentVM>();
            services.AddTransient<LecturerVM, LecturerVM>();
            services.AddTransient<CourseVM, CourseVM>();
            services.AddTransient<ClassVM, ClassVM>();

            return services.BuildServiceProvider();
        }
    }
}
