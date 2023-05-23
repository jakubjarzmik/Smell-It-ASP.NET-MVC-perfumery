using MediatR;
using SmellIt.Application.Features.PrivacyPolicies.DTOs;

namespace SmellIt.Application.Features.PrivacyPolicies.Commands.CreatePrivacyPolicy
{
    public class CreatePrivacyPolicyCommand : PrivacyPolicyDto, IRequest
    {
    }
}
