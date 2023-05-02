using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface IWebsiteTextTranslationRepository
{
    Task<IEnumerable<WebsiteTextTranslation>> GetAll();
    Task<IEnumerable<WebsiteTextTranslation>> GetWebsiteTextTranslations(int websiteTextId);
    Task<WebsiteTextTranslation?> GetTranslation(int websiteTextId, string languageCode);
    Task Create(WebsiteTextTranslation websiteTextTranslation);
    Task Commit();
}
