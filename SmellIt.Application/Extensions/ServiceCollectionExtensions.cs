using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmellIt.Application.Mappings.BrandMapping;
using SmellIt.Application.SmellIt.Brands.Commands.CreateBrand;
using SmellIt.Application.SmellIt.Brands.Commands.EditBrand;

namespace SmellIt.Application.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateBrandCommand));

        services.AddAutoMapper(typeof(BrandMappingProfile));

        services.AddValidatorsFromAssemblyContaining<CreateBrandCommandValidator>()
            .AddValidatorsFromAssemblyContaining<EditBrandCommandValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }
}
