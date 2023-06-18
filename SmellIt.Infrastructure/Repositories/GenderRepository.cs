using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class GenderRepository : BaseRepositoryWithEncodedName<Gender>, IGenderRepository
{
    public GenderRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }
    public override async Task DeleteAsync(Gender gender)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        gender.IsActive = false;
        gender.DeletedAt = DateTime.Now;
        gender.DeletedById = currentUser.Id;

        DeleteTranslations(gender, currentUser.Id);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteByEncodedNameAsync(string encodedName)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        var gender = await GetByEncodedNameAsync(encodedName);
        if (gender != null)
        {
            gender.IsActive = false;
            gender.DeletedAt = DateTime.Now;
            gender.DeletedById = currentUser.Id;
            DeleteTranslations(gender, currentUser.Id);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(Gender gender, string currentUserId)
    {
        foreach (var genderTranslation in gender.GenderTranslations)
        {
            genderTranslation.IsActive = false;
            genderTranslation.DeletedAt = DateTime.Now;
            genderTranslation.DeletedById = currentUserId;
        }
    }
}
