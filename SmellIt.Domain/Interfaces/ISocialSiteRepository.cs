using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface ISocialSiteRepository : IBaseRepository<SocialSite>
{
    Task<SocialSite?> GetByType(string type);
}
