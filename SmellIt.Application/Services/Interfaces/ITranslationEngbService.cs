using SmellIt.Domain.Entities;

namespace SmellIt.Application.Services.Interfaces;
public interface ITranslationEngbService
{
    Task Create(TranslationEngb translationEngb);
    Task<TranslationEngb?> GetByKey(string key);
}
