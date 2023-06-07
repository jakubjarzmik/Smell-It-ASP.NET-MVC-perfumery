using MediatR;
using SmellIt.Application.Features.CartItems.DTOs.Website;

namespace SmellIt.Application.Features.CartItems.Commands.AddCartItem;

public class AddCartItemCommand : CartItemDtoForAdd, IRequest
{
}