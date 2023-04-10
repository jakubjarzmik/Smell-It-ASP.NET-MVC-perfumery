using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SmellIt.Application.Mappings;
using SmellIt.Application.Services;
using SmellIt.Application.Services.Interfaces;
using SmellIt.Application.Validators;

namespace SmellIt.Application.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ITranslationEngbService, TranslationEngbService>();
        services.AddScoped<ITranslationPlplService, TranslationPlplService>();

        services.AddScoped<IBrandService, BrandService>();
        services.AddAutoMapper(typeof(BrandMappingProfile));
        
        services.AddScoped<IProductService, ProductService>();

        services.AddValidatorsFromAssemblyContaining<BrandDtoValidator>()
            .AddValidatorsFromAssemblyContaining<TranslationEngbValidator>()
            .AddValidatorsFromAssemblyContaining<TranslationPlplValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }
}
