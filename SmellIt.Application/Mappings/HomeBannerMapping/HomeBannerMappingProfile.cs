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
            .ForMember(dto => dto.TextPL,
                opt =>
                    opt.MapFrom<TextPlResolver>())
            .ForMember(dto => dto.TextEN,
                opt =>
                    opt.MapFrom<TextEnResolver>());

        CreateMap<HomeBannerDto, EditHomeBannerCommand>();
    }
}