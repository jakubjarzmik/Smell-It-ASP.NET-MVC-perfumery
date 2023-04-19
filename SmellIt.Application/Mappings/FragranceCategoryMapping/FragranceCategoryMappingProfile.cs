using AutoMapper;
using SmellIt.Application.SmellIt.Brands;
using SmellIt.Application.SmellIt.Brands.Commands.EditBrand;
using SmellIt.Application.SmellIt.FragranceCategories;
using SmellIt.Application.SmellIt.FragranceCategories.Commands.EditFragranceCategory;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.FragranceCategoryMapping;
public class FragranceCategoryMappingProfile : Profile
{
    public FragranceCategoryMappingProfile()
    {
        CreateMap<FragranceCategoryDto, FragranceCategory>()
            .ForMember(brand => brand.FragranceCategoryTranslations,
                opt => opt.MapFrom<FragranceCategoryTranslationsResolver>());

        CreateMap<FragranceCategory, FragranceCategoryDto>()
            .ForMember(dto => dto.NamePL,
                opt => opt.MapFrom<NamePlResolver>())
            .ForMember(dto => dto.NameEN,
                opt => opt.MapFrom<NameEnResolver>())
            .ForMember(dto => dto.DescriptionPL,
                opt => opt.MapFrom<DescriptionPlResolver>())
            .ForMember(dto => dto.DescriptionEN,
                opt => opt.MapFrom<DescriptionEnResolver>());

        CreateMap<FragranceCategoryDto, EditFragranceCategoryCommand>();
    }
}