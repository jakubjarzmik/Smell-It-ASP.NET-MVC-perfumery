using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.PrivacyPolicies.Commands.EditPrivacyPolicy
{
    public class EditPrivacyPolicyCommandHandler : IRequestHandler<EditPrivacyPolicyCommand>
    {
        private readonly IPrivacyPolicyRepository _privacyPolicyRepository;

        public EditPrivacyPolicyCommandHandler(IPrivacyPolicyRepository privacyPolicyRepository)
        {
            _privacyPolicyRepository = privacyPolicyRepository;
        }
        public async Task<Unit> Handle(EditPrivacyPolicyCommand request, CancellationToken cancellationToken)
        {
            var websiteText = (await _privacyPolicyRepository.GetByEncodedNameAsync(request.EncodedName))!;
            websiteText.ModifiedAt = DateTime.Now;
            websiteText.Text = request.Text;

            await _privacyPolicyRepository.CommitAsync();
            
            return Unit.Value;
        }
    }
}