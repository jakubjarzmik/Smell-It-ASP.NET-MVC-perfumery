using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class DeliveryRepository : BaseRepositoryWithEncodedName<Delivery>, IDeliveryRepository
{
    public DeliveryRepository(SmellItDbContext dbContext): base(dbContext)
    {
    }
    public override async Task DeleteAsync(Delivery delivery)
    {
        delivery.IsActive = false;
        delivery.DeletedAt = DateTime.Now;

        DeleteTranslations(delivery);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteByEncodedNameAsync(string encodedName)
    {
        var delivery = await GetByEncodedNameAsync(encodedName);
        if (delivery != null)
        {
            delivery.IsActive = false;
            delivery.DeletedAt = DateTime.Now;
            DeleteTranslations(delivery);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(Delivery delivery)
    {
        foreach (var deliveryTranslation in delivery.DeliveryTranslations)
        {
            deliveryTranslation.IsActive = false;
            deliveryTranslation.DeletedAt = DateTime.Now;
        }
    }
}
