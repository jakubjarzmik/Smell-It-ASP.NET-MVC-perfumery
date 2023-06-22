using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }

    public async Task<IEnumerable<OrderItem>?> GetAsync(Order order)
        => await  DbContext.OrderItems.Where(oi => oi.IsActive && oi.Order == order).ToListAsync();

    public async Task<IEnumerable<OrderItem>?> GetAsync(Product product)
        => await  DbContext.OrderItems.Where(oi => oi.IsActive && oi.Product == product).ToListAsync();
}