using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IWebsiteTextRepository : IBaseRepository<WebsiteText>
{
    Task<WebsiteText?> GetByKey(string key);
}
