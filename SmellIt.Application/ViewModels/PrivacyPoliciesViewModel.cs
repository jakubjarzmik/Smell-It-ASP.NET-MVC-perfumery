using SmellIt.Application.Features.Languages;
using SmellIt.Application.Features.PrivacyPolicies;

namespace SmellIt.Application.ViewModels
{
    public class PrivacyPoliciesViewModel
    {
        public IEnumerable<PrivacyPolicyDto>? PrivacyPolicies { get; set; }
        public IEnumerable<LanguageDto>? Languages { get; set; }
    }
}
