using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmellIt.Application.Mappings;
using SmellIt.Application.Services;
using SmellIt.Application.Services.Interfaces;
using SmellIt.Application.SmellIt.Brands.Commands.CreateBrand;
using SmellIt.Application.SmellIt.Brands.Commands.EditBrand;
using SmellIt.Application.Validators;

namespace SmellIt.Application.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ITranslationEngbService, TranslationEngbService>();
        services.AddScoped<ITranslationPlplService, TranslationPlplService>();

        services.AddMediatR(typeof(CreateBrandCommand));
        services.AddAutoMapper(typeof(BrandMappingProfile));
        services.AddAutoMapper(typeof(TranslationEngbProfile));
        services.AddAutoMapper(typeof(TranslationPlplProfile));
        
        services.AddScoped<IProductService, ProductService>();

        services.AddValidatorsFromAssemblyContaining<CreateBrandCommandValidator>()
            .AddValidatorsFromAssemblyContaining<EditBrandCommandValidator>()
            .AddValidatorsFromAssemblyContaining<TranslationEngbValidator>()
            .AddValidatorsFromAssemblyContaining<TranslationPlplValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }
}
