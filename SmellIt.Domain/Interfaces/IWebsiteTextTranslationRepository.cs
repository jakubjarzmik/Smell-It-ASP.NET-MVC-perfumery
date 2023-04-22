using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface IWebsiteTextTranslationRepository
{
    Task<IEnumerable<WebsiteTextTranslation>> GetAll();
    Task<IEnumerable<WebsiteTextTranslation>> GetLayoutTextTranslations(int layoutTextId);
    Task<WebsiteTextTranslation?> GetTranslation(int layoutTextId, string languageCode);
    Task<WebsiteTextTranslation?> GetByEncodedName(string encodedName);
    Task Create(WebsiteTextTranslation websiteTextTranslation);
    Task Commit();
}
