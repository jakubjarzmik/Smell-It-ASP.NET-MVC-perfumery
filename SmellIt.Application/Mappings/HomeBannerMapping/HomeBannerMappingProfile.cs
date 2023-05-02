using AutoMapper;
using SmellIt.Application.SmellIt.HomeBanners;
using SmellIt.Application.SmellIt.HomeBanners.Commands.EditHomeBanner;
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
    }
}