using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface IBrandTranslationRepository
{
    Task<IEnumerable<BrandTranslation>> GetAll();
    Task<IEnumerable<BrandTranslation>> GetBrandTranslations(int brandId);
    Task<BrandTranslation?> GetTranslation(int brandId, string languageCode);
    Task Create(BrandTranslation brandTranslation);
    Task Commit();
}
