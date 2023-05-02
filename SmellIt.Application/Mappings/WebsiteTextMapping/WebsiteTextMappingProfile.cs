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
            .ForMember(websiteTexts => websiteTexts.WebsiteTextTranslations,
                opt => opt.MapFrom<WebsiteTextTranslationsResolver>());

        CreateMap<WebsiteText, WebsiteTextDto>()
            .ForMember(dto => dto.TextPl,
                opt => opt.MapFrom(src=>src.WebsiteTextTranslations.First(wtt=>wtt.Language.Code == "pl-PL").Text))
            .ForMember(dto => dto.TextEn,
                opt => opt.MapFrom(src => src.WebsiteTextTranslations.First(wtt => wtt.Language.Code == "en-GB").Text));

        CreateMap<WebsiteTextDto, EditWebsiteTextCommand>();
    }
}