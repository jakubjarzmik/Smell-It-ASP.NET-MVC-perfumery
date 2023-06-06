using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface ICartItemRepository : IBaseRepository<CartItem>
{
    Task<IEnumerable<CartItem>> GetBySessionAsync(string session);
    Task<CartItem?> GetBySessionAndProductEncodedNameAsync(string session, string productEncodedName);
}
