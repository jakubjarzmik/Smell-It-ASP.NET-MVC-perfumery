using AutoMapper;
using SmellIt.Application.Dtos;
using SmellIt.Application.Extensions;
using SmellIt.Domain.Entities;


namespace SmellIt.Application.Mappings;
public class BrandMappingProfile : Profile
{
    public BrandMappingProfile()
    {
        CreateMap<BrandDto, Brand>()
            .ForMember(b => b.NameKey,
                opt => opt.MapFrom(src => src.NameEN.ConvertNameToKey()))
            .ForMember(b => b.DescriptionKey,
                opt => opt.MapFrom(src =>
                    string.IsNullOrWhiteSpace(src.DescriptionPL) ? null : src.NameEN.ConvertNameToKey() + "Desc"));
    }
}