using AutoMapper;
using SmellIt.Application.Features.HomeBanners;
using SmellIt.Application.Features.HomeBanners.Commands.EditHomeBanner;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.HomeBannerMapping;
public class HomeBannerMappingProfile : Profile
{
    public HomeBannerMappingProfile()
    {
        CreateMap<HomeBannerDto, HomeBanner>()
            .ForMember(websiteTexts => websiteTexts.HomeBannerTranslations,
                opt => opt.MapFrom<HomeBannerTranslationsResolver>());

        CreateMap<HomeBanner, HomeBannerDto>()
            .ForMember(dto => dto.TextPl,
                opt => opt.MapFrom(src=>src.HomeBannerTranslations.First(hbt=>hbt.Language.Code == "pl-PL").Text))
            .ForMember(dto => dto.TextEn,
                opt => opt.MapFrom(src => src.HomeBannerTranslations.First(hbt => hbt.Language.Code == "en-GB").Text));

        CreateMap<HomeBannerDto, EditHomeBannerCommand>();

        CreateMap<HomeBanner, WebsiteHomeBannerDto>()
            .ForMember(dto => dto.Text,
                opt => opt.Ignore())
            .AfterMap((src, dest, ctx) =>
            {
                var languageCode = ctx.Items["LanguageCode"].ToString();
                dest.Text = src.HomeBannerTranslations.First(fct => fct.Language.Code == languageCode).Text;
            });
    }
}