using MediatR;

namespace SmellIt.Application.SmellIt.PrivacyPolicies.Queries.GetAllPrivacyPolicies
{
    public class GetAllPrivacyPoliciesQuery : IRequest<IEnumerable<PrivacyPolicyDto>>
    {
    }
}
