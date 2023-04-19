using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface IFragranceCategoryTranslationRepository
{
    Task Create(FragranceCategoryTranslation fragranceCategoryTranslation);
    Task<IEnumerable<FragranceCategoryTranslation>> GetByFragranceCategoryId(int id);
    Task<FragranceCategoryTranslation?> GetByEncodedName(string encodedName);
    Task<IEnumerable<FragranceCategoryTranslation>> GetAll();
    Task Commit();
}
