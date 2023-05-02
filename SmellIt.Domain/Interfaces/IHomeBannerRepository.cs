using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IHomeBannerRepository : IBaseRepository<HomeBanner>
{
    Task<HomeBanner?> GetByKey(string key);
}
