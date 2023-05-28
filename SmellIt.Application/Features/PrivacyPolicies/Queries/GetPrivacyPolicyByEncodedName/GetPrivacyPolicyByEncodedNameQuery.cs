using MediatR;
using SmellIt.Application.Features.PrivacyPolicies.DTOs;

namespace SmellIt.Application.Features.PrivacyPolicies.Queries.GetPrivacyPolicyByEncodedName;

public class GetPrivacyPolicyByEncodedNameQuery : IRequest<PrivacyPolicyDto>
{
    public string EncodedName { get; set; }

    public GetPrivacyPolicyByEncodedNameQuery(string encodedName)
    {
        EncodedName = encodedName;
    }
}