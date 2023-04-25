using SmellIt.Domain.Entities;

namespace SmellIt.Application.SmellIt.PrivacyPolicies;
public class PrivacyPolicyDto
{
    public string EncodedName { get; set; } = default!;
    public string Text { get; set; } = default!;
}
