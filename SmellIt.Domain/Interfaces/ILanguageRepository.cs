using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface ILanguageRepository
{
    Task Create(Language language);
    Task<Language?> GetByCode(string code);
    Task<IEnumerable<Language>> GetAll();
}
