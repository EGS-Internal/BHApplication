﻿
using BHGroup.BL;
using BHGroup.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            services.AddScoped<DBContext, DBContext>();
            return services.BuildServiceProvider();
        }
    }
}
