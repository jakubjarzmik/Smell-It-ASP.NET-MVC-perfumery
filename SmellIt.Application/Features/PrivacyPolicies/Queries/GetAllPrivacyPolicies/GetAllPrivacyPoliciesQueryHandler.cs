using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.PrivacyPolicies.Queries.GetAllPrivacyPolicies;
public class GetAllPrivacyPoliciesQueryHandler : IRequestHandler<GetAllPrivacyPoliciesQuery, IEnumerable<PrivacyPolicyDto>>
{
    private readonly IPrivacyPolicyRepository _privacyPolicyRepository;
    private readonly IMapper _mapper;

    public GetAllPrivacyPoliciesQueryHandler(IPrivacyPolicyRepository privacyPolicyRepository, IMapper mapper)
    {
        _privacyPolicyRepository = privacyPolicyRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<PrivacyPolicyDto>> Handle(GetAllPrivacyPoliciesQuery request, CancellationToken cancellationToken)
    {
        var privacyPolicies = await _privacyPolicyRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<PrivacyPolicyDto>>(privacyPolicies);
        return dtos;
    }
}
