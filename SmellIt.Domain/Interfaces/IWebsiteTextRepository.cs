using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface IWebsiteTextRepository
{
    Task Create(WebsiteText websiteText);
    Task<WebsiteText?> GetByKey(string key);
    Task<WebsiteText?> GetByEncodedName(string encodedName);
    Task<IEnumerable<WebsiteText>> GetAll();
    Task Commit();
}
