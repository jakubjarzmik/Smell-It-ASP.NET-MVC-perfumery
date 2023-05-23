using AutoMapper;
using SmellIt.Application.Features.WebsiteTexts.Commands.EditWebsiteText;
using SmellIt.Application.Features.WebsiteTexts.DTOs;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.WebsiteTextMapping;
public class WebsiteTextMappingProfile : Profile
{
    public WebsiteTextMappingProfile()
    {
        CreateMap<WebsiteTextForAdminDto, WebsiteText>()
            .ForMember(websiteTexts => websiteTexts.WebsiteTextTranslations,
                opt => opt.MapFrom<WebsiteTextTranslationsResolver>());

        CreateMap<WebsiteText, WebsiteTextForAdminDto>()
            .ForMember(dto => dto.TextPl,
                opt => opt.MapFrom(src=>src.WebsiteTextTranslations.First(wtt=>wtt.Language.Code == "pl-PL").Text))
            .ForMember(dto => dto.TextEn,
                opt => opt.MapFrom(src => src.WebsiteTextTranslations.First(wtt => wtt.Language.Code == "en-GB").Text));

        CreateMap<WebsiteTextForAdminDto, EditWebsiteTextCommand>();

        CreateMap<WebsiteText, WebsiteTextDto>()
            .ForMember(dto => dto.Text,
                opt => opt.Ignore())
            .AfterMap((src, dest, ctx) =>
            {
                var languageCode = ctx.Items["LanguageCode"].ToString();
                dest.Text = src.WebsiteTextTranslations.First(fct => fct.Language.Code == languageCode).Text;
            });
    }
}