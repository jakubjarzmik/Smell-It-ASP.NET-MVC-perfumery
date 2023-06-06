using SmellIt.Application.Features.Languages.DTOs;
using SmellIt.Application.Features.PrivacyPolicies.DTOs;

namespace SmellIt.Application.ViewModels.Admin;

public class PrivacyPoliciesViewModel
{
    public IEnumerable<PrivacyPolicyDto>? PrivacyPolicies { get; set; }
    public IEnumerable<LanguageDto>? Languages { get; set; }
}