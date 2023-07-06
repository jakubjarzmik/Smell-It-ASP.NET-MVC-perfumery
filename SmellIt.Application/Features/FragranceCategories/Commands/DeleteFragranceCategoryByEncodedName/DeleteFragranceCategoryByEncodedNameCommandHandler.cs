using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.FragranceCategories.Commands.DeleteFragranceCategoryByEncodedName;

public class DeleteFragranceCategoryByEncodedNameCommandHandler : IRequestHandler<DeleteFragranceCategoryByEncodedNameCommand>
{
    private readonly IUserContext _userContext;
    private readonly IFragranceCategoryRepository _fragranceCategoryRepository;

    public DeleteFragranceCategoryByEncodedNameCommandHandler(IUserContext userContext, IFragranceCategoryRepository fragranceCategoryRepository)
    {
        _userContext = userContext;
        _fragranceCategoryRepository = fragranceCategoryRepository;
    }

    public async Task<Unit> Handle(DeleteFragranceCategoryByEncodedNameCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        await _fragranceCategoryRepository.DeleteAsync(request.EncodedName);
        return Unit.Value;
    }
}