using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Interfaces.Abstract;

public interface IBaseRepository<T> : IRepository 
    where T : BaseEntity
{
    Task CreateAsync(T cartItem);
    Task DeleteAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetAsync(int id);
    Task<int> CountAsync();
    Task<IEnumerable<T>> GetPaginatedAsync(int pageNumber, int pageSize);
    Task<IEnumerable<T>> GetLatestListAsync(int quantity);
}