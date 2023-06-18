using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.PrivacyPolicies.Commands.EditPrivacyPolicy;

public class EditPrivacyPolicyCommandHandler : IRequestHandler<EditPrivacyPolicyCommand>
{
    private readonly IPrivacyPolicyRepository _privacyPolicyRepository;
    private readonly IUserContext _userContext;

    public EditPrivacyPolicyCommandHandler(IPrivacyPolicyRepository privacyPolicyRepository, IUserContext userContext)
    {
        _privacyPolicyRepository = privacyPolicyRepository;
        _userContext = userContext;
    }
    public async Task<Unit> Handle(EditPrivacyPolicyCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        var websiteText = (await _privacyPolicyRepository.GetByEncodedNameAsync(request.EncodedName))!;
        websiteText.ModifiedAt = DateTime.Now;
        websiteText.ModifiedById = currentUser.Id;

        websiteText.Text = request.Text;

        await _privacyPolicyRepository.CommitAsync();
            
        return Unit.Value;
    }
}