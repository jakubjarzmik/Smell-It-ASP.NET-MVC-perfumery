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
            services.AddScoped<IBrandTranslationRepository, BrandTranslationRepository>();
            services.AddScoped<IFragranceCategoryRepository, FragranceCategoryRepository>();
            services.AddScoped<IFragranceCategoryTranslationRepository, FragranceCategoryTranslationRepository>();
            services.AddScoped<ILayoutTextRepository, LayoutTextRepository>();
            services.AddScoped<ILayoutTextTranslationRepository, LayoutTextTranslationRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
        }
    }
}
