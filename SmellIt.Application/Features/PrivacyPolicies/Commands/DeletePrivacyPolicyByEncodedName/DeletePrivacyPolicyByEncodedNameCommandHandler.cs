using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.PrivacyPolicies.Commands.DeletePrivacyPolicyByEncodedName
{
    public class DeletePrivacyPolicyByEncodedNameCommandHandler : IRequestHandler<DeletePrivacyPolicyByEncodedNameCommand>
    {
        private readonly IPrivacyPolicyRepository _privacyPolicyRepository;

        public DeletePrivacyPolicyByEncodedNameCommandHandler(IPrivacyPolicyRepository privacyPolicyRepository)
        {
            _privacyPolicyRepository = privacyPolicyRepository;
        }

        public async Task<Unit> Handle(DeletePrivacyPolicyByEncodedNameCommand request, CancellationToken cancellationToken)
        {
            await _privacyPolicyRepository.DeleteByEncodedNameAsync(request.EncodedName);
            return Unit.Value;
        }
    }
}
