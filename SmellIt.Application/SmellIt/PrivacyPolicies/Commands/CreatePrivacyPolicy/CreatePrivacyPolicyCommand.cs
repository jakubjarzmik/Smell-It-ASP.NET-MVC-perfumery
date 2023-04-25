using MediatR;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.SmellIt.PrivacyPolicies.Commands.CreatePrivacyPolicy
{
    public class CreatePrivacyPolicyCommand : PrivacyPolicyDto, IRequest
    {
        public string? LanguageCode { get; set; }
    }
}
