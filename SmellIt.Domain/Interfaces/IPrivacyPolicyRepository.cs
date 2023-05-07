using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IPrivacyPolicyRepository : IBaseRepositoryWithEncodedName<PrivacyPolicy>
{
    Task<PrivacyPolicy?> GetTranslation(string languageCode);
    Task<PrivacyPolicy?> GetByLanguageCode(string languageCode);
}
