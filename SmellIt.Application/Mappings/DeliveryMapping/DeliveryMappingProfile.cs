using AutoMapper;
using SmellIt.Application.Features.Deliveries.Commands.EditDelivery;
using SmellIt.Application.Features.Deliveries.DTOs;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.DeliveryMapping;
public class DeliveryMappingProfile : Profile
{
    public DeliveryMappingProfile()
    {
        CreateMap<DeliveryDto, Delivery>();

        CreateMap<Delivery, DeliveryDto>()
            .ForMember(dto => dto.NamePl,
                opt => opt.MapFrom(src=>src.DeliveryTranslations.First(fct=>fct.Language.Code == "pl-PL").Name))
            .ForMember(dto => dto.NameEn,
                opt => opt.MapFrom(src => src.DeliveryTranslations.First(fct => fct.Language.Code == "en-GB").Name))
            .ForMember(dto => dto.DescriptionPl,
                opt => opt.MapFrom(src => src.DeliveryTranslations.First(fct => fct.Language.Code == "pl-PL").Description))
            .ForMember(dto => dto.DescriptionEn,
                opt => opt.MapFrom(src => src.DeliveryTranslations.First(fct => fct.Language.Code == "en-GB").Description));

        CreateMap<DeliveryDto, EditDeliveryCommand>();

        CreateMap<Delivery, WebsiteDeliveryDto>()
            .ForMember(dto => dto.Name,
                opt => opt.Ignore())
            .ForMember(dto => dto.Description,
                opt => opt.Ignore())
            .AfterMap((src, dest, ctx) =>
            {
                var languageCode = ctx.Items["LanguageCode"].ToString();
                dest.Name = src.DeliveryTranslations.First(fct => fct.Language.Code == languageCode).Name;
                dest.Description = src.DeliveryTranslations.First(fct => fct.Language.Code == languageCode).Description;
            });
    }
}