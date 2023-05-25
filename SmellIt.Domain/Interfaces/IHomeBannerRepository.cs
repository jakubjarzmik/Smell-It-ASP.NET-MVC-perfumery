using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IHomeBannerRepository : IBaseRepositoryWithEncodedName<HomeBanner>
{
    Task<HomeBanner?> GetByKeyAsync(string key);
}
