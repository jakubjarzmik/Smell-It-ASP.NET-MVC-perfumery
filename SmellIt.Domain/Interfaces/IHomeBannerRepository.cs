using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface IHomeBannerRepository
{
    Task Create(HomeBanner homeBanner);
    Task<HomeBanner?> GetByKey(string key);
    Task<HomeBanner?> GetByEncodedName(string encodedName);
    Task<IEnumerable<HomeBanner>> GetAll();
    Task Commit();
}
