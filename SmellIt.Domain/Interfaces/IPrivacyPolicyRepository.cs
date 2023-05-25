using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IPrivacyPolicyRepository : IBaseRepositoryWithEncodedName<PrivacyPolicy>
{
    Task<PrivacyPolicy?> GetTranslationAsync(string languageCode);
    Task<PrivacyPolicy?> GetByLanguageCodeAsync(string languageCode);
}
