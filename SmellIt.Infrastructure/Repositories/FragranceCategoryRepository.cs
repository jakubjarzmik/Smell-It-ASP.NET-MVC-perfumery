using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class FragranceCategoryRepository : BaseRepositoryWithEncodedName<FragranceCategory>, IFragranceCategoryRepository
{
    public FragranceCategoryRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }
    public override async Task DeleteAsync(FragranceCategory fragranceCategory)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        fragranceCategory.IsActive = false;
        fragranceCategory.DeletedAt = DateTime.Now;
        fragranceCategory.DeletedById = currentUser.Id;

        DeleteTranslations(fragranceCategory, currentUser.Id);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteAsync(string encodedName)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        var fragranceCategory = await GetAsync(encodedName);
        if (fragranceCategory != null)
        {
            fragranceCategory.IsActive = false;
            fragranceCategory.DeletedAt = DateTime.Now;
            fragranceCategory.DeletedById = currentUser.Id;
            DeleteTranslations(fragranceCategory, currentUser.Id);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(FragranceCategory fragranceCategory, string currentUserId)
    {
        foreach (var fragranceCategoryTranslation in fragranceCategory.FragranceCategoryTranslations)
        {
            fragranceCategoryTranslation.IsActive = false;
            fragranceCategoryTranslation.DeletedAt = DateTime.Now;
            fragranceCategoryTranslation.DeletedById = currentUserId;
        }
    }
}
