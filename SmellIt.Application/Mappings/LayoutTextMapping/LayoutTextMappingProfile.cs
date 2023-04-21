using AutoMapper;
using SmellIt.Application.SmellIt.LayoutTexts;
using SmellIt.Application.SmellIt.LayoutTexts.Commands.EditLayoutText;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.LayoutTextMapping;
public class LayoutTextMappingProfile : Profile
{
    public LayoutTextMappingProfile()
    {
        CreateMap<LayoutTextDto, LayoutText>()
            .ForMember(brand => brand.LayoutTextTranslations,
                opt => opt.MapFrom<LayoutTextTranslationsResolver>());

        CreateMap<LayoutText, LayoutTextDto>()
            .ForMember(dto => dto.TextPL,
                opt =>
                    opt.MapFrom<TextPlResolver>())
            .ForMember(dto => dto.TextEN,
                opt =>
                    opt.MapFrom<TextEnResolver>());

        CreateMap<LayoutTextDto, EditLayoutTextCommand>();
    }
}