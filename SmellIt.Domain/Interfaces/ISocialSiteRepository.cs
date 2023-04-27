using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface ISocialSiteRepository
{
    Task Create(SocialSite socialSite);
    Task<SocialSite?> GetByType(string type);
    Task<SocialSite?> GetByEncodedName(string encodedName);
    Task<IEnumerable<SocialSite>> GetAll();
    Task Commit();
}
