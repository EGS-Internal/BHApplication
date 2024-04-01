
using BHGroup.BL;
using BHGroup.DAL;
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
            services.AddScoped<DBContext, DBContext>();
            return services.BuildServiceProvider();
        }
    }
}
