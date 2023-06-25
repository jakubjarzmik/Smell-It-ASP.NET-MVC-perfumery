using Dropbox.Api.Users;
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
        => await DbContext.Orders.Where(o => o.IsActive && o.UserId == userId).OrderByDescending(o => o.OrderDate).ToListAsync();

    public async Task<IEnumerable<Order>?> GetAllAsync(IdentityUser user)
        => await DbContext.Orders.Where(o => o.IsActive && o.User == user).OrderByDescending(o => o.OrderDate).ToListAsync();

    public async Task<Order?> GetLatestUserOrderAsync(string userId)
        => await DbContext.Orders.Where(o => o.IsActive && o.UserId == userId).OrderByDescending(o => o.OrderDate).FirstOrDefaultAsync();

    public async Task<int> CountLastMonthAsync()
    {
        var canceledStatus = await GetCanceledStatus();
        return await DbContext.Orders.CountAsync(o =>
            o.IsActive && o.OrderStatus != canceledStatus && o.OrderDate >= DateTime.Now.AddMonths(-1));
    }

    public async Task<decimal> CountMonthlyEarningsAsync()
    {
        var canceledStatus = await GetCanceledStatus();
        return await DbContext.Orders.Where(o => o.IsActive && o.OrderStatus != canceledStatus && o.OrderDate >= DateTime.Now.AddMonths(-1)).Select(o => o.TotalPrice).SumAsync();
    }

    public override async Task CreateAsync(Order order)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null)
        {
            return;
        }

        order.CreatedById = currentUser.Id;
        DbContext.Add(order);
        await DbContext.SaveChangesAsync();
    }

    public override async Task<IEnumerable<Order>> GetLatestListAsync(int count)
    {
        var canceledStatus = await GetCanceledStatus();
        return await DbContext.Set<Order>().Where(b => b.IsActive && b.OrderStatus != canceledStatus).OrderByDescending(b => b.CreatedAt).Take(count)
            .ToListAsync();
    }

    private async Task<OrderStatus?> GetCanceledStatus()
    {
        return (await DbContext.OrderStatusTranslations.FirstOrDefaultAsync(ost => ost.Name == "Canceled"))?.OrderStatus;
    }

}