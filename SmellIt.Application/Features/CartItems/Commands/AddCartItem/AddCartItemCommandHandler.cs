using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.CartItems.Commands.AddCartItem;
public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public AddCartItemCommandHandler(ICartItemRepository cartItemRepository, IProductRepository productRepository, IMapper mapper, IUserContext userContext)
    {
        _cartItemRepository = cartItemRepository;
        _productRepository = productRepository;
        _mapper = mapper;
        _userContext = userContext;
    }
    public async Task<Unit> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();
        CartItem? foundCartItem;
        if (request.IsAuthenticated)
        {
            foundCartItem = await _cartItemRepository.GetBySessionOrUserAndProductEncodedNameAsync(request.Session, currentUser!.Id , request.ProductEncodedName);
        }
        else
        {
            foundCartItem = await _cartItemRepository.GetBySessionAndProductEncodedNameAsync(request.Session, request.ProductEncodedName);
        }
        
        if (foundCartItem != null)
        {
            foundCartItem.ModifiedAt = DateTime.Now;
            foundCartItem.ModifiedById = currentUser?.Id;
            foundCartItem.Quantity += request.Quantity;
            await _cartItemRepository.CommitAsync();
        }
        else
        {
            var cartItem = _mapper.Map<CartItem>(request);
            cartItem.Product = (await _productRepository.GetAsync(request.ProductEncodedName))!;
            await _cartItemRepository.CreateAsync(cartItem);
        }
        return Unit.Value;
    }
}