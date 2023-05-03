﻿using Microsoft.EntityFrameworkCore;
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
            services.AddDbContext<SmellItDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SmellIt")).UseLazyLoadingProxies());

            services.AddScoped<Seeder>();

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IFragranceCategoryRepository, FragranceCategoryRepository>();
            services.AddScoped<IHomeBannerRepository, HomeBannerRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IPrivacyPolicyRepository, PrivacyPolicyRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISocialSiteRepository, SocialSiteRepository>();
            services.AddScoped<IWebsiteTextRepository, WebsiteTextRepository>();
        }
    }
}
