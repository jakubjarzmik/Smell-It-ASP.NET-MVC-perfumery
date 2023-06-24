﻿using AutoMapper;
using SmellIt.Application.Features.Orders.DTOs;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.OrderMapping;
public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(dto => dto.UserEmail,
                opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dto => dto.Address,
                opt => opt.MapFrom(src => src.Address))
            .ForMember(dto => dto.OrderItems,
                opt => opt.MapFrom(src => src.OrderItems))
            .ForMember(dto => dto.OrderStatus,
                opt => opt.MapFrom(src => src.OrderStatus))
            .AfterMap((src, dest, ctx) =>
            {
                var languageCode = ctx.Items["LanguageCode"].ToString();
                dest.Delivery = src.Delivery.DeliveryTranslations.First(fct => fct.Language.Code == languageCode).Name;
                dest.Payment = src.Payment.PaymentTranslations.First(fct => fct.Language.Code == languageCode).Name;
            });
        CreateMap<OrderCreateDto, Order>()
            .ForMember(o => o.User,
                opt => opt.MapFrom<UserResolver>())
            .ForMember(o => o.Address,
                opt => opt.MapFrom<AddressResolver>())
            .ForMember(o => o.OrderStatus,
                opt => opt.MapFrom<OrderStatusResolver>())
            .ForMember(o => o.OrderItems,
                opt => opt.MapFrom<OrderItemsResolver>());
    }
}