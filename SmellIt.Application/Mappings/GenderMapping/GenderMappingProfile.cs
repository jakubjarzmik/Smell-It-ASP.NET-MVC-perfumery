using AutoMapper;
using SmellIt.Application.Features.Genders;
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
                opt => opt.MapFrom(src => src.GenderTranslations.First(fct => fct.Language.Code == "pl-PL").Name))
            .ForMember(dto => dto.NameEn,
                opt => opt.MapFrom(src => src.GenderTranslations.First(fct => fct.Language.Code == "en-GB").Name));

        CreateMap<Gender, WebsiteGenderDto>()
            .ForMember(dto => dto.Name,
                opt => opt.Ignore())
            .AfterMap((src, dest, ctx) =>
            {
                var languageCode = ctx.Items["LanguageCode"].ToString();
                dest.Name = src.GenderTranslations.First(fct => fct.Language.Code == languageCode).Name;
            });
    }
}