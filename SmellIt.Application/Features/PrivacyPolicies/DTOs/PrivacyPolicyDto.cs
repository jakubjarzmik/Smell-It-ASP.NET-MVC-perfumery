namespace SmellIt.Application.Features.PrivacyPolicies.DTOs;
public class PrivacyPolicyDto
{
    public string EncodedName { get; set; } = default!;
    public string Text { get; set; } = default!;
    public string LanguageCode { get; set; } = default!;
}
