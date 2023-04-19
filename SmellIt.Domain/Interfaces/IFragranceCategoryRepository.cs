using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface IFragranceCategoryRepository
{
    Task Create(FragranceCategory fragranceCategory);
    Task<FragranceCategory?> GetByEncodedName(string encodedName);
    Task<IEnumerable<FragranceCategory>> GetAll();
    Task Commit();
}
