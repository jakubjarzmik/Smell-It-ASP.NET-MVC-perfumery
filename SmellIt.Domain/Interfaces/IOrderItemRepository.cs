using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IOrderItemRepository : IBaseRepository<OrderItem>
{
    Task<IEnumerable<OrderItem>?> GetAsync(Order order);
    Task<IEnumerable<OrderItem>?> GetAsync(Product product);
}
