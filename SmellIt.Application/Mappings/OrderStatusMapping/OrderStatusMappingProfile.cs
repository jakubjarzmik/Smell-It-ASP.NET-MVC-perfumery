using AutoMapper;
using SmellIt.Application.Features.OrderStatuses.DTOs;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.OrderStatusMapping;
public class OrderStatusMappingProfile : Profile
{
    public OrderStatusMappingProfile()
    {
        CreateMap<OrderStatus, OrderStatusDto>()
            .AfterMap((src, dest, ctx) =>
            {
                var languageCode = ctx.Items["LanguageCode"].ToString();
                dest.Name = src.OrderStatusTranslations.First(fct => fct.Language.Code == languageCode).Name;
                dest.Description = src.OrderStatusTranslations.First(fct => fct.Language.Code == languageCode).Description;
            });
    }
}