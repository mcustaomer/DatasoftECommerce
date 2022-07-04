﻿using BusinessLayer.Generic;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class DI_Business
    {
        public static IServiceCollection AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();

            return services;
        }
    }
}
