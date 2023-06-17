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
        fragranceCategory.IsActive = false;
        fragranceCategory.DeletedAt = DateTime.Now;
        fragranceCategory.DeletedById = UserContext.GetCurrentUser().Id;

        DeleteTranslations(fragranceCategory);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteByEncodedNameAsync(string encodedName)
    {
        var fragranceCategory = await GetByEncodedNameAsync(encodedName);
        if (fragranceCategory != null)
        {
            fragranceCategory.IsActive = false;
            fragranceCategory.DeletedAt = DateTime.Now;
            fragranceCategory.DeletedById = UserContext.GetCurrentUser().Id;
            DeleteTranslations(fragranceCategory);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(FragranceCategory fragranceCategory)
    {
        foreach (var fragranceCategoryTranslation in fragranceCategory.FragranceCategoryTranslations)
        {
            fragranceCategoryTranslation.IsActive = false;
            fragranceCategoryTranslation.DeletedAt = DateTime.Now;
            fragranceCategoryTranslation.DeletedById = UserContext.GetCurrentUser().Id;
        }
    }
}
