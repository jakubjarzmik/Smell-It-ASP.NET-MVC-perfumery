using MediatR;

namespace SmellIt.Application.SmellIt.PrivacyPolicies.Commands.DeletePrivacyPolicyByEncodedName
{
    public class DeletePrivacyPolicyByEncodedNameCommand : IRequest
    {
        public string EncodedName { get; set; }

        public DeletePrivacyPolicyByEncodedNameCommand(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
