using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IWebsiteTextRepository : IBaseRepositoryWithEncodedName<WebsiteText>
{
    Task<WebsiteText?> GetByKeyAsync(string key);
}
