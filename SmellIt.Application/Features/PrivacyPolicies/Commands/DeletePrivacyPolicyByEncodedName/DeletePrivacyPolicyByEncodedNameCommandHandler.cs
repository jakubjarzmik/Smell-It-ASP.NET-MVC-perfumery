using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.PrivacyPolicies.Commands.DeletePrivacyPolicyByEncodedName;

public class DeletePrivacyPolicyByEncodedNameCommandHandler : IRequestHandler<DeletePrivacyPolicyByEncodedNameCommand>
{
    private readonly IUserContext _userContext;
    private readonly IPrivacyPolicyRepository _privacyPolicyRepository;

    public DeletePrivacyPolicyByEncodedNameCommandHandler(IUserContext userContext, IPrivacyPolicyRepository privacyPolicyRepository)
    {
        _userContext = userContext;
        _privacyPolicyRepository = privacyPolicyRepository;
    }

    public async Task<Unit> Handle(DeletePrivacyPolicyByEncodedNameCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        await _privacyPolicyRepository.DeleteAsync(request.EncodedName);
        return Unit.Value;
    }
}