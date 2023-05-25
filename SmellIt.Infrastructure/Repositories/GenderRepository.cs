using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class GenderRepository : BaseRepositoryWithEncodedName<Gender>, IGenderRepository
{
    public GenderRepository(SmellItDbContext dbContext) : base(dbContext)
    {
    }
    public override async Task DeleteAsync(Gender gender)
    {
        gender.IsActive = false;
        gender.DeletedAt = DateTime.Now;

        DeleteTranslations(gender);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteByEncodedNameAsync(string encodedName)
    {
        var gender = await GetByEncodedNameAsync(encodedName);
        if (gender != null)
        {
            gender.IsActive = false;
            gender.DeletedAt = DateTime.Now;
            DeleteTranslations(gender);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(Gender gender)
    {
        foreach (var genderTranslation in gender.GenderTranslations)
        {
            genderTranslation.IsActive = false;
            genderTranslation.DeletedAt = DateTime.Now;
        }
    }
}
