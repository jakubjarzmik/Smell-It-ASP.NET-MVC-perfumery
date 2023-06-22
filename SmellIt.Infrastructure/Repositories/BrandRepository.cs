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
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        brand.IsActive = false;
        brand.DeletedAt = DateTime.Now;
        brand.DeletedById = currentUser.Id;

        DeleteTranslations(brand, currentUser.Id);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteAsync(string encodedName)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        var brand = await GetAsync(encodedName);
        if (brand != null)
        {
            brand.IsActive = false;
            brand.DeletedAt = DateTime.Now;
            brand.DeletedById = currentUser.Id;
            DeleteTranslations(brand, currentUser.Id);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(Brand brand, string currentUserId)
    {
        foreach (var brandTranslation in brand.BrandTranslations)
        {
            brandTranslation.IsActive = false;
            brandTranslation.DeletedAt = DateTime.Now;
            brandTranslation.DeletedById = currentUserId;
        }
    }
}
