using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class OrderStatusRepository : BaseRepositoryWithEncodedName<OrderStatus>, IOrderStatusRepository
{
    public OrderStatusRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }

    public async Task<OrderStatus?> GetByName(string name)
        => (await DbContext.OrderStatusTranslations.FirstOrDefaultAsync(ost => ost.Name == name))?.OrderStatus;
    public override async Task DeleteAsync(OrderStatus orderStatus)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        orderStatus.IsActive = false;
        orderStatus.DeletedAt = DateTime.Now;
        orderStatus.DeletedById = currentUser.Id;

        DeleteTranslations(orderStatus, currentUser.Id);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteAsync(string encodedName)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        var orderStatus = await GetAsync(encodedName);
        if (orderStatus != null)
        {
            orderStatus.IsActive = false;
            orderStatus.DeletedAt = DateTime.Now;
            orderStatus.DeletedById = currentUser.Id;
            DeleteTranslations(orderStatus, currentUser.Id);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(OrderStatus orderStatus, string currentUserId)
    {
        foreach (var orderStatusTranslation in orderStatus.OrderStatusTranslations)
        {
            orderStatusTranslation.IsActive = false;
            orderStatusTranslation.DeletedAt = DateTime.Now;
            orderStatusTranslation.DeletedById = currentUserId;
        }
    }
}