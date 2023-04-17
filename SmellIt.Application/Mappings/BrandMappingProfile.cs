using AutoMapper;
using SmellIt.Application.SmellIt.Brands;
using SmellIt.Application.SmellIt.Brands.Commands.EditBrand;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings;
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
                    opt.MapFrom(src =>
                        src.BrandTranslations!.First(bt =>
                            bt.Language.Code == "pl-PL" && bt.BrandId == src.Id).Description))
            .ForMember(dto => dto.DescriptionEN,
                opt =>
                    opt.MapFrom(src =>
                        src.BrandTranslations!.First(bt =>
                            bt.Language.Code == "en-GB" && bt.BrandId == src.Id).Description));

        CreateMap<BrandDto, EditBrandCommand>();
    }
}