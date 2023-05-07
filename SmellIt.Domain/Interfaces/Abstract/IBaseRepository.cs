using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Interfaces.Abstract
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
        Task<IEnumerable<T>> GetAll();
        Task Commit();
    }
}
