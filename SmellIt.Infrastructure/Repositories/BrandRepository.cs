using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class BrandRepository : BaseRepositoryWithEncodedName<Brand>, IBrandRepository
{
    public BrandRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }

    public async Task<Brand?> GetByNameAsync(string name)
        => await DbContext.Brands.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.Name.ToLower() == name.ToLower());
    public override async Task DeleteAsync(Brand brand)
    {
        brand.IsActive = false;
        brand.DeletedAt = DateTime.Now;
        brand.DeletedById = UserContext.GetCurrentUser().Id;

        DeleteTranslations(brand);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteByEncodedNameAsync(string encodedName)
    {
        var brand = await GetByEncodedNameAsync(encodedName);
        if (brand != null)
        {
            brand.IsActive = false;
            brand.DeletedAt = DateTime.Now;
            brand.DeletedById = UserContext.GetCurrentUser().Id;
            DeleteTranslations(brand);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(Brand brand)
    {
        foreach (var brandTranslation in brand.BrandTranslations)
        {
            brandTranslation.IsActive = false;
            brandTranslation.DeletedAt = DateTime.Now;
            brandTranslation.DeletedById = UserContext.GetCurrentUser().Id;
        }
    }
}
