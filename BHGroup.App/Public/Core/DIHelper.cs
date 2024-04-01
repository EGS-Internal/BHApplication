using BHGroup.App.ViewModels;
using BHGroup.BL;
using Microsoft.Extensions.DependencyInjection;

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
        public DIHelper()
        {
            Services = ConfigureServices();
        }
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IStudent, BLStudent>();
            services.AddSingleton<ICourse, BLCourse>();
            services.AddSingleton<ILecturer, BLLecturer>();
            services.AddTransient<MainViewModel, MainViewModel>();
            services.AddTransient<HomeViewModel, HomeViewModel>();
            services.AddTransient<StudentListViewModel, StudentListViewModel>();
            services.AddTransient<LecturerListViewModel, LecturerListViewModel>();
            services.AddTransient<CourseListViewModel, CourseListViewModel>();
            services.AddTransient<ClassListViewModel, ClassListViewModel>();
            //services.AddScoped<DBContext, DBContext>();
            return services.BuildServiceProvider();
        }
    }
}
