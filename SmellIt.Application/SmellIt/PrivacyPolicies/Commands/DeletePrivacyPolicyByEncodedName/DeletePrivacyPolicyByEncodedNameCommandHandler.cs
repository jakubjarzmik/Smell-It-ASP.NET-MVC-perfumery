using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.PrivacyPolicies.Commands.DeletePrivacyPolicyByEncodedName
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
            var privacyPolicy = (await _privacyPolicyRepository.GetByEncodedName(request.EncodedName))!;
            privacyPolicy.IsActive = false;
            privacyPolicy.DeletedAt = DateTime.UtcNow;

            await _privacyPolicyRepository.Commit();
            return Unit.Value;
        }
    }
}
