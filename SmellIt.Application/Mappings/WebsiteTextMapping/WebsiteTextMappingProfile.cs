using AutoMapper;
using SmellIt.Application.SmellIt.HomeBanners;
using SmellIt.Application.SmellIt.HomeBanners.Commands.EditWebsiteText;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.HomeBannerMapping;
public class WebsiteTextMappingProfile : Profile
{
    public WebsiteTextMappingProfile()
    {
        CreateMap<WebsiteTextDto, WebsiteText>()
            .ForMember(websiteTexts => websiteTexts.WebsiteTextTranslations,
                opt => opt.MapFrom<WebsiteTextTranslationsResolver>());

        CreateMap<WebsiteText, WebsiteTextDto>()
            .ForMember(dto => dto.TextPL,
                opt =>
                    opt.MapFrom<TextPlResolver>())
            .ForMember(dto => dto.TextEN,
                opt =>
                    opt.MapFrom<TextEnResolver>());

        CreateMap<WebsiteTextDto, EditWebsiteTextCommand>();
    }
}