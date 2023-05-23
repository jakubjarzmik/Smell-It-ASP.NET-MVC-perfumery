using MediatR;

namespace SmellIt.Application.Features.PrivacyPolicies.Queries.GetAllPrivacyPolicies
{
    public class GetAllPrivacyPoliciesQuery : IRequest<IEnumerable<PrivacyPolicyDto>>
    {
    }
}
