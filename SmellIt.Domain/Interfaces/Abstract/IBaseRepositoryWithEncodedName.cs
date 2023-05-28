using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Interfaces.Abstract;

public interface IBaseRepositoryWithEncodedName<T> : IBaseRepository<T> where T : BaseEntityWithEncodedName
{
    Task<T?> GetByEncodedNameAsync(string encodedName);
    Task DeleteByEncodedNameAsync(string encodedName);
}