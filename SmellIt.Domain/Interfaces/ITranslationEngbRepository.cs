using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface ITranslationEngbRepository
{
    Task Create(TranslationEngb translationEngb);
    Task<TranslationEngb?> GetByKey(string key);
}
