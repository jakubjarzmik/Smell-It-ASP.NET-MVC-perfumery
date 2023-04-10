using Microsoft.Extensions.DependencyInjection;
using SmellIt.Application.Mappings;
using SmellIt.Application.Services;
using SmellIt.Application.Services.Interfaces;

namespace SmellIt.Application.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<ITranslationEngbService, TranslationEngbService>();
        services.AddScoped<ITranslationPlplService, TranslationPlplService>();
        services.AddAutoMapper(typeof(BrandMappingProfile));

        services.AddScoped<IProductService, ProductService>();

        
    }
}
