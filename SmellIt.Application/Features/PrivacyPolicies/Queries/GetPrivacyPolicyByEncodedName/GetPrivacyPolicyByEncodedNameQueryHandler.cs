using AutoMapper;
using MediatR;
using SmellIt.Application.Features.PrivacyPolicies.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.PrivacyPolicies.Queries.GetPrivacyPolicyByEncodedName;

public class GetPrivacyPolicyByEncodedNameQueryHandler : IRequestHandler<GetPrivacyPolicyByEncodedNameQuery, PrivacyPolicyDto>
{
    private readonly IPrivacyPolicyRepository _privacyPolicyRepository;
    private readonly IMapper _mapper;

    public GetPrivacyPolicyByEncodedNameQueryHandler(IPrivacyPolicyRepository privacyPolicyRepository, IMapper mapper)
    {
        _privacyPolicyRepository = privacyPolicyRepository;
        _mapper = mapper;
    }
    public async Task<PrivacyPolicyDto> Handle(GetPrivacyPolicyByEncodedNameQuery request, CancellationToken cancellationToken)
    {
        var websiteText = await _privacyPolicyRepository.GetByEncodedNameAsync(request.EncodedName);
        var dto = _mapper.Map<PrivacyPolicyDto>(websiteText);
        return dto;
    }
}