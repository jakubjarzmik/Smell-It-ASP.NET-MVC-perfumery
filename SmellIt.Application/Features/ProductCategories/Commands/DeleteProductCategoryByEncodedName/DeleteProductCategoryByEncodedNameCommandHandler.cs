using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.ProductCategories.Commands.DeleteProductCategoryByEncodedName;

public class DeleteProductCategoryByEncodedNameCommandHandler : IRequestHandler<DeleteProductCategoryByEncodedNameCommand>
{
    private readonly IUserContext _userContext;
    private readonly IProductCategoryRepository _productCategoryRepository;

    public DeleteProductCategoryByEncodedNameCommandHandler(IUserContext userContext, IProductCategoryRepository productCategoryRepository)
    {
        _userContext = userContext;
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<Unit> Handle(DeleteProductCategoryByEncodedNameCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        await _productCategoryRepository.DeleteAsync(request.EncodedName);
        return Unit.Value;
    }
}