using MediatR;

namespace SmellIt.Application.SmellIt.PrivacyPolicies.Queries.GetPrivacyPolicyByEncodedName
{
    public class GetPrivacyPolicyByEncodedNameQuery : IRequest<PrivacyPolicyDto>
    {
        public string EncodedName { get; set; }

        public GetPrivacyPolicyByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
