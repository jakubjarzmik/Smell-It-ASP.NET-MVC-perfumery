using AutoMapper;
using SmellIt.Application.SmellIt.Languages;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.LanguageMapping;
public class LanguageMappingProfile : Profile
{
    public LanguageMappingProfile()
    {
        CreateMap<LanguageDto, Language>();
        CreateMap<Language, LanguageDto>();
    }
}