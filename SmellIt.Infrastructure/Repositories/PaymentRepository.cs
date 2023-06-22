using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class PaymentRepository : BaseRepositoryWithEncodedName<Payment>, IPaymentRepository
{
    public PaymentRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }
    public override async Task DeleteAsync(Payment payment)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        payment.IsActive = false;
        payment.DeletedAt = DateTime.Now;
        payment.DeletedById = currentUser.Id;

        DeleteTranslations(payment, currentUser.Id);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteAsync(string encodedName)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        var payment = await GetAsync(encodedName);
        if (payment != null)
        {
            payment.IsActive = false;
            payment.DeletedAt = DateTime.Now;
            payment.DeletedById = currentUser.Id;
            DeleteTranslations(payment, currentUser.Id);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(Payment payment, string currentUserId)
    {
        foreach (var paymentTranslation in payment.PaymentTranslations)
        {
            paymentTranslation.IsActive = false;
            paymentTranslation.DeletedAt = DateTime.Now;
            paymentTranslation.DeletedById = currentUserId;
        }
    }
}
