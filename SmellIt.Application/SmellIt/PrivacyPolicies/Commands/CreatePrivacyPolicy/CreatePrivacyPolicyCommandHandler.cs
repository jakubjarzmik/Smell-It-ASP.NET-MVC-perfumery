using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.PrivacyPolicies.Commands.CreatePrivacyPolicy
{
    public class CreatePrivacyPolicyCommandHandler : IRequestHandler<CreatePrivacyPolicyCommand>
    {
        private readonly IPrivacyPolicyRepository _privacyPolicyRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        public CreatePrivacyPolicyCommandHandler(IPrivacyPolicyRepository privacyPolicyRepository, ILanguageRepository languageRepository , IMapper mapper)
        {
            _privacyPolicyRepository = privacyPolicyRepository;
            _languageRepository = languageRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreatePrivacyPolicyCommand request, CancellationToken cancellationToken)
        {
            var privacyPolicy = _mapper.Map<PrivacyPolicy>(request);
            privacyPolicy.Language = (await _languageRepository.GetByCode(request.LanguageCode!))!;
            privacyPolicy.EncodeName();

            await _privacyPolicyRepository.Create(privacyPolicy);

            return Unit.Value;
        }
    }
}
