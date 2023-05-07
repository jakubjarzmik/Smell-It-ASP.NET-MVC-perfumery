using AutoMapper;
using SmellIt.Application.SmellIt.Genders;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.GenderMapping;
public class GenderMappingProfile : Profile
{
    public GenderMappingProfile()
    {
        CreateMap<GenderDto, Gender>()
            .ForMember(gender => gender.GenderTranslations,
                opt => opt.MapFrom<GenderTranslationsResolver>());

        CreateMap<Gender, GenderDto>()
            .ForMember(dto => dto.NamePl,
                opt => opt.MapFrom(src=>src.GenderTranslations.First(fct=>fct.Language.Code == "pl-PL").Name))
            .ForMember(dto => dto.NameEn,
                opt => opt.MapFrom(src => src.GenderTranslations.First(fct => fct.Language.Code == "en-GB").Name))
            .ForMember(dto => dto.DescriptionPl,
                opt => opt.MapFrom(src => src.GenderTranslations.First(fct => fct.Language.Code == "pl-PL").Description))
            .ForMember(dto => dto.DescriptionEn,
                opt => opt.MapFrom(src => src.GenderTranslations.First(fct => fct.Language.Code == "en-GB").Description));
    }
}