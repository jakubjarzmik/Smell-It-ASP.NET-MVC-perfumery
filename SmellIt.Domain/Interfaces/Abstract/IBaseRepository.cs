using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Interfaces.Abstract
{
    public interface IBaseRepository<T> where T : BaseEntityWithEncodedName
    {
        Task Create(T entity);
        Task<T?> GetByEncodedName(string encodedName);
        Task<IEnumerable<T>> GetAll();
        Task Commit();
    }
}
