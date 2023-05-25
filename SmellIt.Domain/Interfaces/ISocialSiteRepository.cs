using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface ISocialSiteRepository : IBaseRepositoryWithEncodedName<SocialSite>
{
    Task<SocialSite?> GetByType(string type);
}
