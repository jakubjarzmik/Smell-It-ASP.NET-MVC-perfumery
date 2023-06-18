﻿using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Domain.Models;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;
using System.Drawing.Drawing2D;

namespace SmellIt.Infrastructure.Repositories;
public class DeliveryRepository : BaseRepositoryWithEncodedName<Delivery>, IDeliveryRepository
{
    public DeliveryRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }
    public override async Task DeleteAsync(Delivery delivery)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        delivery.IsActive = false;
        delivery.DeletedAt = DateTime.Now;
        delivery.DeletedById = currentUser.Id;

        DeleteTranslations(delivery, currentUser.Id);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteByEncodedNameAsync(string encodedName)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        var delivery = await GetByEncodedNameAsync(encodedName);
        if (delivery != null)
        {
            delivery.IsActive = false;
            delivery.DeletedAt = DateTime.Now;
            delivery.DeletedById = currentUser.Id;
            DeleteTranslations(delivery, currentUser.Id);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(Delivery delivery, string currentUserId)
    {
        foreach (var deliveryTranslation in delivery.DeliveryTranslations)
        {
            deliveryTranslation.IsActive = false;
            deliveryTranslation.DeletedAt = DateTime.Now;
            deliveryTranslation.DeletedById = currentUserId;
        }
    }
}
