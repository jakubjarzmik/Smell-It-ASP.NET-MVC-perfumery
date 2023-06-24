using MediatR;
using SmellIt.Application.Features.Orders.DTOs;

namespace SmellIt.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommand : OrderCreateDto, IRequest
{
}