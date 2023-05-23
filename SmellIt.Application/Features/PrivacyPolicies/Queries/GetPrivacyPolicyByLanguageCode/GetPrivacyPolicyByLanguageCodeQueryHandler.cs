using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.PrivacyPolicies.Queries.GetPrivacyPolicyByLanguageCode
{
    public class GetPrivacyPolicyByLanguageCodeQueryHandler : IRequestHandler<GetPrivacyPolicyByLanguageCodeQuery, PrivacyPolicyDto>
    {
        private readonly IPrivacyPolicyRepository _privacyPolicyRepository;
        private readonly IMapper _mapper;

        public GetPrivacyPolicyByLanguageCodeQueryHandler(IPrivacyPolicyRepository privacyPolicyRepository, IMapper mapper)
        {
            _privacyPolicyRepository = privacyPolicyRepository;
            _mapper = mapper;
        }
        public async Task<PrivacyPolicyDto> Handle(GetPrivacyPolicyByLanguageCodeQuery request, CancellationToken cancellationToken)
        {
            var privacyPolicy = await _privacyPolicyRepository.GetByLanguageCode(request.LanguageCode);
            var dto = _mapper.Map<PrivacyPolicyDto>(privacyPolicy);
            return dto;
        }
    }
}
