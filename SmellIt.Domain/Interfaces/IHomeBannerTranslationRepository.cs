using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface IHomeBannerTranslationRepository
{
    Task<IEnumerable<HomeBannerTranslation>> GetAll();
    Task<IEnumerable<HomeBannerTranslation>> GetHomeBannerTranslations(int homeBannerId);
    Task<HomeBannerTranslation?> GetTranslation(int homeBannerId, string languageCode);
    Task<HomeBannerTranslation?> GetByEncodedName(string encodedName);
    Task Create(HomeBannerTranslation homeBannerTranslation);
    Task Commit();
}
