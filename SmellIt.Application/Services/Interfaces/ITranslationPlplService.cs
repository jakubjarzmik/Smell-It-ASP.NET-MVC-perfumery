using SmellIt.Domain.Entities;

namespace SmellIt.Application.Services.Interfaces;
public interface ITranslationPlplService
{
    Task Create(TranslationPlpl translationPlpl);
    Task<TranslationPlpl?> GetByKey(string key);
}
