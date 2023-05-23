using AutoMapper;
using SmellIt.Application.Features.Brands;
using SmellIt.Application.Features.Brands.Commands.EditBrand;
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
            .ForMember(dto => dto.DescriptionPl,
                opt => opt.MapFrom(src => src.BrandTranslations.First(bt => bt.Language.Code == "pl-PL").Description))
            .ForMember(dto => dto.DescriptionEn, 
                opt => opt.MapFrom(src => src.BrandTranslations.First(bt => bt.Language.Code == "en-GB").Description));

        CreateMap<BrandDto, EditBrandCommand>();

        CreateMap<Brand, WebsiteBrandDto>()
            .ForMember(dto => dto.Description,
                opt => opt.Ignore())
            .AfterMap((src, dest, ctx) =>
            {
                var languageCode = ctx.Items["LanguageCode"].ToString();
                dest.Description = src.BrandTranslations.First(fct => fct.Language.Code == languageCode).Description;
            });
    }
}