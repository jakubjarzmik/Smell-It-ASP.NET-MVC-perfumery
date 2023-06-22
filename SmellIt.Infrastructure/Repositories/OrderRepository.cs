using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }

    public async Task<IEnumerable<Order>?> GetAllAsync(string userId)
        => await DbContext.Orders.Where(o => o.IsActive && o.UserId == userId).ToListAsync();

    public async Task<IEnumerable<Order>?> GetAllAsync(IdentityUser user)
        => await DbContext.Orders.Where(o => o.IsActive && o.User == user).ToListAsync();
    public async Task<int> CountLastMonthAsync()
        => await DbContext.Orders.CountAsync(o => o.IsActive && o.OrderDate >= DateTime.Now.AddMonths(-1));

    public async Task<decimal> CountMonthlyEarningsAsync()
        => await DbContext.Orders.Where(o => o.IsActive && o.OrderDate >= DateTime.Now.AddMonths(-1)).Select(o=>o.TotalPrice).SumAsync();
} 