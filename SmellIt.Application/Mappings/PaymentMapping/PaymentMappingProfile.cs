using AutoMapper;
using SmellIt.Application.Features.Payments.Commands.EditPayment;
using SmellIt.Application.Features.Payments.DTOs;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.PaymentMapping;
public class PaymentMappingProfile : Profile
{
    public PaymentMappingProfile()
    {
        CreateMap<PaymentDto, Payment>();

        CreateMap<Payment, PaymentDto>()
            .ForMember(dto => dto.NamePl,
                opt => opt.MapFrom(src=>src.PaymentTranslations.First(fct=>fct.Language.Code == "pl-PL").Name))
            .ForMember(dto => dto.NameEn,
                opt => opt.MapFrom(src => src.PaymentTranslations.First(fct => fct.Language.Code == "en-GB").Name))
            .ForMember(dto => dto.DescriptionPl,
                opt => opt.MapFrom(src => src.PaymentTranslations.First(fct => fct.Language.Code == "pl-PL").Description))
            .ForMember(dto => dto.DescriptionEn,
                opt => opt.MapFrom(src => src.PaymentTranslations.First(fct => fct.Language.Code == "en-GB").Description));

        CreateMap<PaymentDto, EditPaymentCommand>();

        CreateMap<Payment, WebsitePaymentDto>()
            .ForMember(dto => dto.Name,
                opt => opt.Ignore())
            .ForMember(dto => dto.Description,
                opt => opt.Ignore())
            .AfterMap((src, dest, ctx) =>
            {
                var languageCode = ctx.Items["LanguageCode"].ToString();
                dest.Name = src.PaymentTranslations.First(fct => fct.Language.Code == languageCode).Name;
                dest.Description = src.PaymentTranslations.First(fct => fct.Language.Code == languageCode).Description;
            });
    }
}