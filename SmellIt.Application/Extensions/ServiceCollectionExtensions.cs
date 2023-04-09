using Microsoft.Extensions.DependencyInjection;
using SmellIt.Application.Services;

namespace SmellIt.Application.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IBrandService, BrandService>();
    }
}
