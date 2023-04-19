using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmellIt.Application.Mappings.BrandMapping;
using SmellIt.Application.Mappings.FragranceCategoryMapping;
using SmellIt.Application.SmellIt.Brands.Commands.CreateBrand;
using SmellIt.Application.SmellIt.Brands.Commands.EditBrand;
using SmellIt.Application.SmellIt.FragranceCategories.Commands.CreateFragranceCategory;
using SmellIt.Application.SmellIt.FragranceCategories.Commands.EditFragranceCategory;

namespace SmellIt.Application.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateBrandCommand));
        services.AddMediatR(typeof(CreateFragranceCategoryCommand));

        services.AddAutoMapper(typeof(BrandMappingProfile));
        services.AddAutoMapper(typeof(FragranceCategoryMappingProfile));

        services.AddValidatorsFromAssemblyContaining<CreateBrandCommandValidator>()
            .AddValidatorsFromAssemblyContaining<EditBrandCommandValidator>()
            .AddValidatorsFromAssemblyContaining<CreateFragranceCategoryCommandValidator>()
            .AddValidatorsFromAssemblyContaining<EditFragranceCategoryCommandValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }
}
