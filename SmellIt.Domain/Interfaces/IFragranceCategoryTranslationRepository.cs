using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface IFragranceCategoryTranslationRepository
{
    Task<IEnumerable<FragranceCategoryTranslation>> GetAll();
    Task<IEnumerable<FragranceCategoryTranslation>> GetFragranceCategoryTranslations(int fragranceCategoryId);
    Task<FragranceCategoryTranslation?> GetTranslation(int fragranceCategoryId, string languageCode);
    Task Create(FragranceCategoryTranslation fragranceCategoryTranslation);
    Task Commit();
}
