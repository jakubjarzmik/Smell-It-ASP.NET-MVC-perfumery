using AutoMapper;
using SmellIt.Application.SmellIt.Brands;
using SmellIt.Application.SmellIt.Brands.Commands.EditBrand;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.BrandMapping;
public class BrandMappingProfile : Profile
{
    public BrandMappingProfile()
    {
        CreateMap<BrandDto, Brand>()
            .ForMember(brand => brand.BrandTranslations,
                opt => opt.MapFrom<BrandTranslationsResolver>());

        CreateMap<Brand, BrandDto>()
            .ForMember(dto => dto.DescriptionPL,
                opt =>
                    opt.MapFrom<DescriptionPlResolver>())
            .ForMember(dto => dto.DescriptionEN,
                opt =>
                    opt.MapFrom<DescriptionEnResolver>());

        CreateMap<BrandDto, EditBrandCommand>();
    }
}