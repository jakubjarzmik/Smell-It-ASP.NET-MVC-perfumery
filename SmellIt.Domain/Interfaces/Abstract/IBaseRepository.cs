using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Interfaces.Abstract
{
    public interface IBaseRepository<T> : IRepository 
        where T : BaseEntity
    {
        Task Create(T entity);
        Task Delete(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        Task Commit();
    }
}
