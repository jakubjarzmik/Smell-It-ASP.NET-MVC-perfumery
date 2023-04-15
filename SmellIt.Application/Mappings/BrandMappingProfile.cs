using AutoMapper;
using SmellIt.Application.Extensions;
using SmellIt.Application.SmellIt.Brands;
using SmellIt.Application.SmellIt.Brands.Commands.EditBrand;
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
                opt => opt.MapFrom(
                    src => string.IsNullOrWhiteSpace(src.DescriptionPL) ? null : src.NameEN.ConvertNameToKey() + "Desc"));

        CreateMap<Brand, BrandDto>()
            .ForMember(dto => dto.NamePL,
                opt => opt.MapFrom(src => src.NameKey))
            .ForMember(dto => dto.NameEN,
                opt => opt.MapFrom(src => src.NameKey))
            .ForMember(dto => dto.DescriptionPL,
                opt => opt.MapFrom(src => src.DescriptionKey))
            .ForMember(dto => dto.DescriptionEN,
                opt => opt.MapFrom(src => src.DescriptionKey));

        CreateMap<BrandDto, EditBrandCommand>();
    }
}