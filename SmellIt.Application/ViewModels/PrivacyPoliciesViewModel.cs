using SmellIt.Application.SmellIt.Languages;
using SmellIt.Application.SmellIt.PrivacyPolicies;

namespace SmellIt.Application.ViewModels
{
    public class PrivacyPoliciesViewModel
    {
        public IEnumerable<PrivacyPolicyDto>? PrivacyPolicies { get; set; }
        public IEnumerable<LanguageDto>? Languages { get; set; }
    }
}
