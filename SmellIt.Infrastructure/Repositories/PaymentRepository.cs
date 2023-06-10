using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class PaymentRepository : BaseRepositoryWithEncodedName<Payment>, IPaymentRepository
{
    public PaymentRepository(SmellItDbContext dbContext): base(dbContext)
    {
    }
    public override async Task DeleteAsync(Payment payment)
    {
        payment.IsActive = false;
        payment.DeletedAt = DateTime.Now;

        DeleteTranslations(payment);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteByEncodedNameAsync(string encodedName)
    {
        var payment = await GetByEncodedNameAsync(encodedName);
        if (payment != null)
        {
            payment.IsActive = false;
            payment.DeletedAt = DateTime.Now;
            DeleteTranslations(payment);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(Payment payment)
    {
        foreach (var paymentTranslation in payment.PaymentTranslations)
        {
            paymentTranslation.IsActive = false;
            paymentTranslation.DeletedAt = DateTime.Now;
        }
    }
}
