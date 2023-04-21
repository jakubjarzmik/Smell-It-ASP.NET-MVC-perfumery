using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface ILayoutTextTranslationRepository
{
    Task<IEnumerable<LayoutTextTranslation>> GetAll();
    Task<IEnumerable<LayoutTextTranslation>> GetLayoutTextTranslations(int layoutTextId);
    Task<LayoutTextTranslation?> GetTranslation(int layoutTextId, string languageCode);
    Task<LayoutTextTranslation?> GetByEncodedName(string encodedName);
    Task Create(LayoutTextTranslation layoutTextTranslation);
    Task Commit();
}
