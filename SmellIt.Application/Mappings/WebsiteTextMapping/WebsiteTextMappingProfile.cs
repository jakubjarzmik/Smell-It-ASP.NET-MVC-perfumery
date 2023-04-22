using AutoMapper;
using SmellIt.Application.SmellIt.WebsiteTexts;
using SmellIt.Application.SmellIt.WebsiteTexts.Commands.EditWebsiteText;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.WebsiteTextMapping;
public class WebsiteTextMappingProfile : Profile
{
    public WebsiteTextMappingProfile()
    {
        CreateMap<WebsiteTextDto, WebsiteText>()
            .ForMember(websiteTexts => websiteTexts.LayoutTextTranslations,
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