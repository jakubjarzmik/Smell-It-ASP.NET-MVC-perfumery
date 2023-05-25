using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.PrivacyPolicies.Commands.CreatePrivacyPolicy
{
    public class CreatePrivacyPolicyCommandHandler : IRequestHandler<CreatePrivacyPolicyCommand>
    {
        private readonly IPrivacyPolicyRepository _privacyPolicyRepository;
        private readonly IMapper _mapper;
        public CreatePrivacyPolicyCommandHandler(IPrivacyPolicyRepository privacyPolicyRepository, IMapper mapper)
        {
            _privacyPolicyRepository = privacyPolicyRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreatePrivacyPolicyCommand request, CancellationToken cancellationToken)
        {
            var privacyPolicy = _mapper.Map<PrivacyPolicy>(request);
            await _privacyPolicyRepository.CreateAsync(privacyPolicy);
            return Unit.Value;
        }
    }
}
