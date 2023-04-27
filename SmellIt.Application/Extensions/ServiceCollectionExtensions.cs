﻿using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmellIt.Application.Mappings.BrandMapping;
using SmellIt.Application.Mappings.FragranceCategoryMapping;
using SmellIt.Application.Mappings.HomeBannerMapping;
using SmellIt.Application.Mappings.PrivacyPolicyMapping;
using SmellIt.Application.Mappings.SocialSiteMapping;
using SmellIt.Application.Mappings.WebsiteTextMapping;
using SmellIt.Application.SmellIt.Brands.Commands.CreateBrand;
using SmellIt.Application.SmellIt.Brands.Commands.EditBrand;
using SmellIt.Application.SmellIt.FragranceCategories.Commands.CreateFragranceCategory;
using SmellIt.Application.SmellIt.FragranceCategories.Commands.EditFragranceCategory;
using SmellIt.Application.SmellIt.HomeBanners.Commands.CreateHomeBanner;
using SmellIt.Application.SmellIt.HomeBanners.Commands.EditHomeBanner;
using SmellIt.Application.SmellIt.PrivacyPolicies.Commands.CreatePrivacyPolicy;
using SmellIt.Application.SmellIt.SocialSites.Commands.CreateSocialSite;
using SmellIt.Application.SmellIt.SocialSites.Commands.EditSocialSite;
using SmellIt.Application.SmellIt.WebsiteTexts.Commands.CreateWebsiteText;
using SmellIt.Application.SmellIt.WebsiteTexts.Commands.EditWebsiteText;

namespace SmellIt.Application.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateBrandCommand));
        services.AddMediatR(typeof(CreateFragranceCategoryCommand));
        services.AddMediatR(typeof(CreateWebsiteTextCommand));
        services.AddMediatR(typeof(CreateHomeBannerCommand));
        services.AddMediatR(typeof(CreatePrivacyPolicyCommand));
        services.AddMediatR(typeof(CreateSocialSiteCommand));

        services.AddAutoMapper(typeof(BrandMappingProfile));
        services.AddAutoMapper(typeof(FragranceCategoryMappingProfile));
        services.AddAutoMapper(typeof(WebsiteTextMappingProfile));
        services.AddAutoMapper(typeof(HomeBannerMappingProfile));
        services.AddAutoMapper(typeof(PrivacyPolicyMappingProfile));
        services.AddAutoMapper(typeof(SocialSiteMappingProfile));

        services.AddValidatorsFromAssemblyContaining<CreateBrandCommandValidator>()
            .AddValidatorsFromAssemblyContaining<EditBrandCommandValidator>()
            .AddValidatorsFromAssemblyContaining<CreateFragranceCategoryCommandValidator>()
            .AddValidatorsFromAssemblyContaining<EditFragranceCategoryCommandValidator>()
            .AddValidatorsFromAssemblyContaining<CreateWebsiteTextCommandValidator>()
            .AddValidatorsFromAssemblyContaining<EditWebsiteTextCommandValidator>()
            .AddValidatorsFromAssemblyContaining<CreateHomeBannerCommandValidator>()
            .AddValidatorsFromAssemblyContaining<EditHomeBannerCommandValidator>()
            .AddValidatorsFromAssemblyContaining<CreateSocialSiteCommandValidator>()
            .AddValidatorsFromAssemblyContaining<EditSocialSiteCommandValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }
}
