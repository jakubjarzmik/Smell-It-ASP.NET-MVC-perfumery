using MediatR;
using SmellIt.Application.Features.CartItems.DTOs.Website;

namespace SmellIt.Application.Features.CartItems.Commands.RemoveCartItem;

public class RemoveCartItemCommand : CartItemDtoForAdd, IRequest
{
}