using MediatR;
using SmellIt.Application.Features.CartItems.DTOs;

namespace SmellIt.Application.Features.CartItems.Commands.AddCartItem;

public class AddCartItemCommand : CartItemDto, IRequest
{
}