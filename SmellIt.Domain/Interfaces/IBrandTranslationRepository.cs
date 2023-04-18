using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface IBrandTranslationRepository
{
    Task Create(BrandTranslation brandTranslation);
    Task<IEnumerable<BrandTranslation>> GetByBrandId(int id);
    Task<BrandTranslation?> GetByEncodedName(string encodedName);
    Task<IEnumerable<BrandTranslation>> GetAll();
    Task Commit();
}
