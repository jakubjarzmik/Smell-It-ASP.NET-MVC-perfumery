using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmellIt.Application.Helpers;
using SmellIt.Application.Helpers.Images;
using SmellIt.Application.Helpers.Images.Imgur;
using System.Reflection;

namespace SmellIt.Application.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddMediatR(typeof(CreateBrandCommand));
        //services.AddMediatR(typeof(CreateFragranceCategoryCommand));
        services.AddMediatR(Assembly.GetExecutingAssembly());


        //services.AddAutoMapper(typeof(BrandMappingProfile));
        //services.AddAutoMapper(typeof(FragranceCategoryMappingProfile));
        //services.AddAutoMapper(typeof(HomeBannerMappingProfile));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //services.AddValidatorsFromAssemblyContaining<CreateBrandCommandValidator>()
        //    .AddValidatorsFromAssemblyContaining<CreateFragranceCategoryCommandValidator>()
        //    .AddFluentValidationAutoValidation()
        //    .AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();

        //services.AddScoped<IProductCategorySorter, ProductCategorySorter>();
        //services.AddScoped<IProductCategoryPrefixGenerator, ProductCategoryPrefixGenerator>();
        services.Scan(scan => scan
            .FromAssemblyOf<ProductCategorySorter>()
            .AddClasses(classes => classes.AssignableTo<IHelper>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        //services.Configure<DropboxSettings>(configuration.GetSection("Dropbox"));
        //services.AddScoped<IImageUploader, DropboxImageUploader>();
        services.Configure<ImgurSettings>(configuration.GetSection("ImgurSettings"));
        services.AddScoped<IImageUploader, ImgurImageUploader>();
    }
}
