using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IOrderStatusRepository : IBaseRepository<OrderStatus>
{
    Task<OrderStatus?> GetByName(string name);
}
