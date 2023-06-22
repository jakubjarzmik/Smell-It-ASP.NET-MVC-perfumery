using Microsoft.AspNetCore.Identity;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IOrderRepository : IBaseRepository<Order>
{
    Task<IEnumerable<Order>?> GetAllAsync(IdentityUser user);
    Task<IEnumerable<Order>?> GetAllAsync(string userId);
    Task<int> CountLastMonthAsync();
    Task<decimal> CountMonthlyEarningsAsync();
}
