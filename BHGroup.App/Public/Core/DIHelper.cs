﻿using BHGroup.App.ViewModels;
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
            services.AddTransient<HomeViewModel, HomeViewModel>();
            services.AddTransient<StudentViewModel, StudentViewModel>();
            services.AddTransient<LecturerViewModel, LecturerViewModel>();
            services.AddTransient<CourseViewModel, CourseViewModel>();
            services.AddTransient<ClassViewModel, ClassViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
