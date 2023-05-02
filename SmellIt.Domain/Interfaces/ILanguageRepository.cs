using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface ILanguageRepository : IBaseRepository<Language>
{
    Task<Language?> GetByCode(string code);
}
