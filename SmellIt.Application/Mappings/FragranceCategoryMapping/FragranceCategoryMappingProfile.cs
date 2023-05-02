﻿using AutoMapper;
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
            .ForMember(dto => dto.NamePl,
                opt => opt.MapFrom(src=>src.FragranceCategoryTranslations.First(fct=>fct.Language.Code == "pl-PL").Name))
            .ForMember(dto => dto.NameEn,
                opt => opt.MapFrom(src => src.FragranceCategoryTranslations.First(fct => fct.Language.Code == "en-GB").Name))
            .ForMember(dto => dto.DescriptionPl,
                opt => opt.MapFrom(src => src.FragranceCategoryTranslations.First(fct => fct.Language.Code == "pl-PL").Description))
            .ForMember(dto => dto.DescriptionEn,
                opt => opt.MapFrom(src => src.FragranceCategoryTranslations.First(fct => fct.Language.Code == "en-GB").Description));

        CreateMap<FragranceCategoryDto, EditFragranceCategoryCommand>();
    }
}