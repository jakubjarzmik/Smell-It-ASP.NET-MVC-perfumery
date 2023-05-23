using MediatR;
using SmellIt.Application.Features.PrivacyPolicies.DTOs;

namespace SmellIt.Application.Features.PrivacyPolicies.Queries.GetAllPrivacyPolicies
{
    public class GetAllPrivacyPoliciesQuery : IRequest<IEnumerable<PrivacyPolicyDto>>
    {
    }
}
