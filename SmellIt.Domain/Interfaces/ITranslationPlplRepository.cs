using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface ITranslationPlplRepository
{
    Task Create(TranslationPlpl translationPlpl);
    Task<TranslationPlpl?> GetByKey(string key);
    Task Commit();
}
