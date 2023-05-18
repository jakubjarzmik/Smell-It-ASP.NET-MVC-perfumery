using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmellIt.Application.Helpers;
using SmellIt.Application.Helpers.Images;
using System.Reflection;

namespace SmellIt.Application.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddMediatR(typeof(CreateBrandCommand));
        //services.AddMediatR(typeof(CreateFragranceCategoryCommand));
        //services.AddMediatR(typeof(CreateWebsiteTextCommand));
        //services.AddMediatR(typeof(CreateHomeBannerCommand));
        //services.AddMediatR(typeof(CreatePrivacyPolicyCommand));
        //services.AddMediatR(typeof(CreateProductCommand));
        //services.AddMediatR(typeof(CreateProductCategoryCommand));
        //services.AddMediatR(typeof(CreateSocialSiteCommand));
        services.AddMediatR(Assembly.GetExecutingAssembly());


        //services.AddAutoMapper(typeof(BrandMappingProfile));
        //services.AddAutoMapper(typeof(FragranceCategoryMappingProfile));
        //services.AddAutoMapper(typeof(HomeBannerMappingProfile));
        //services.AddAutoMapper(typeof(LanguageMappingProfile));
        //services.AddAutoMapper(typeof(PrivacyPolicyMappingProfile));
        //services.AddAutoMapper(typeof(GenderMappingProfile));
        //services.AddAutoMapper(typeof(ProductMappingProfile));
        //services.AddAutoMapper(typeof(ProductPriceMappingProfile));
        //services.AddAutoMapper(typeof(ProductCategoryMappingProfile));
        //services.AddAutoMapper(typeof(SocialSiteMappingProfile));
        //services.AddAutoMapper(typeof(WebsiteTextMappingProfile));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //services.AddValidatorsFromAssemblyContaining<CreateBrandCommandValidator>()
        //    .AddValidatorsFromAssemblyContaining<CreateFragranceCategoryCommandValidator>()
        //    .AddValidatorsFromAssemblyContaining<EditFragranceCategoryCommandValidator>()
        //    .AddValidatorsFromAssemblyContaining<CreateHomeBannerCommandValidator>()
        //    .AddValidatorsFromAssemblyContaining<EditHomeBannerCommandValidator>()
        //    .AddValidatorsFromAssemblyContaining<CreateSocialSiteCommandValidator>()
        //    .AddValidatorsFromAssemblyContaining<EditSocialSiteCommandValidator>()
        //    .AddValidatorsFromAssemblyContaining<CreateProductCategoryCommandValidator>()
        //    .AddValidatorsFromAssemblyContaining<EditProductCategoryCommandValidator>()
        //    .AddValidatorsFromAssemblyContaining<CreateProductCommandValidator>()
        //    .AddValidatorsFromAssemblyContaining<EditProductCommandValidator>()
        //    .AddValidatorsFromAssemblyContaining<CreateWebsiteTextCommandValidator>()
        //    .AddValidatorsFromAssemblyContaining<EditWebsiteTextCommandValidator>()
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

        services.Configure<DropboxSettings>(configuration.GetSection("Dropbox"));
        services.AddScoped<IImageUploader, DropboxImageUploader>();
    }
}
