using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.CartItems.Commands.AddCartItem;
public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public AddCartItemCommandHandler(ICartItemRepository cartItemRepository, IMapper mapper, IUserContext userContext)
    {
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
        _userContext = userContext;
    }
    public async Task<Unit> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();


        var foundCarItem = await _cartItemRepository.GetBySessionAndProductEncodedNameAsync(request.Session, request.ProductEncodedName);
        if (foundCarItem != null)
        {
            foundCarItem.ModifiedAt = DateTime.Now;
            foundCarItem.ModifiedById = currentUser?.Id;
            foundCarItem.Quantity += request.Quantity;
            await _cartItemRepository.CommitAsync();
        }
        else
        {
            var cartItem = _mapper.Map<CartItem>(request);
            await _cartItemRepository.CreateAsync(cartItem);
        }
        return Unit.Value;
    }
}