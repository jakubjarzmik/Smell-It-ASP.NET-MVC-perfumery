using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class FragranceCategoryRepository : BaseRepositoryWithEncodedName<FragranceCategory>, IFragranceCategoryRepository
{
    public FragranceCategoryRepository(SmellItDbContext dbContext): base(dbContext)
    {
    }
    public override async Task Delete(FragranceCategory fragranceCategory)
    {
        fragranceCategory.IsActive = false;
        fragranceCategory.DeletedAt = DateTime.Now;

        DeleteTranslations(fragranceCategory);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteByEncodedName(string encodedName)
    {
        var fragranceCategory = await GetByEncodedName(encodedName);
        if (fragranceCategory != null)
        {
            fragranceCategory.IsActive = false;
            fragranceCategory.DeletedAt = DateTime.Now;
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
        }
    }
}
