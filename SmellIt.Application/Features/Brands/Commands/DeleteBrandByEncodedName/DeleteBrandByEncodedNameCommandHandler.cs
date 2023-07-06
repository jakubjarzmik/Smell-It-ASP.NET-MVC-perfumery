using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Brands.Commands.DeleteBrandByEncodedName;

public class DeleteBrandByEncodedNameCommandHandler : IRequestHandler<DeleteBrandByEncodedNameCommand>
{
    private readonly IUserContext _userContext;
    private readonly IBrandRepository _brandRepository;

    public DeleteBrandByEncodedNameCommandHandler(IUserContext userContext, IBrandRepository brandRepository)
    {
        _userContext = userContext;
        _brandRepository = brandRepository;
    }

    public async Task<Unit> Handle(DeleteBrandByEncodedNameCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        await _brandRepository.DeleteAsync(request.EncodedName);

        return Unit.Value;
    }
}