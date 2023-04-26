using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface IPrivacyPolicyRepository
{
    Task Create(PrivacyPolicy privacyPolicy);
    Task<IEnumerable<PrivacyPolicy>> GetAll();
    Task<PrivacyPolicy?> GetTranslation(string languageCode);
    Task<PrivacyPolicy?> GetByEncodedName(string encodedName);
    Task<PrivacyPolicy?> GetByLanguageCode(string languageCode);
    Task Commit();
}
