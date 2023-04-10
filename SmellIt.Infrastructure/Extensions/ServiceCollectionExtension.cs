﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories;
using SmellIt.Infrastructure.Seeders;

namespace SmellIt.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SmellItDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SmellIt")));

            services.AddScoped<Seeder>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ITranslationEngbRepository, TranslationEngbRepository>();
            services.AddScoped<ITranslationPlplRepository, TranslationPlplRepository>();
        }
    }
}