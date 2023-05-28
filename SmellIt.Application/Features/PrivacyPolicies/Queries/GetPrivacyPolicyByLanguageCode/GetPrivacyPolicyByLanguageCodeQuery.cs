using MediatR;
using SmellIt.Application.Features.PrivacyPolicies.DTOs;

namespace SmellIt.Application.Features.PrivacyPolicies.Queries.GetPrivacyPolicyByLanguageCode;

public class GetPrivacyPolicyByLanguageCodeQuery : IRequest<PrivacyPolicyDto>
{
    public string LanguageCode { get; set; }

    public GetPrivacyPolicyByLanguageCodeQuery(string languageCode)
    {
        LanguageCode = languageCode;
    }
}