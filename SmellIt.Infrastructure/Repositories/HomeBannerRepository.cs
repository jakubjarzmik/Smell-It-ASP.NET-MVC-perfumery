using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class HomeBannerRepository : BaseRepositoryWithEncodedName<HomeBanner>, IHomeBannerRepository
{
    public HomeBannerRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {

    }

    public async Task<HomeBanner?> GetByKeyAsync(string key)
        => await DbContext.HomeBanners.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.Key.ToLower() == key.ToLower());

    public override async Task DeleteAsync(HomeBanner homeBanner)
    {
        homeBanner.IsActive = false;
        homeBanner.DeletedAt = DateTime.Now;
        homeBanner.DeletedById = UserContext.GetCurrentUser().Id;
        DeleteTranslations(homeBanner);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteByEncodedNameAsync(string encodedName)
    {
        var homeBanner = await GetByEncodedNameAsync(encodedName);
        if (homeBanner != null)
        {
            homeBanner.IsActive = false;
            homeBanner.DeletedAt = DateTime.Now;
            homeBanner.DeletedById = UserContext.GetCurrentUser().Id;
            DeleteTranslations(homeBanner);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(HomeBanner homeBanner)
    {
        foreach (var homeBannerTranslation in homeBanner.HomeBannerTranslations)
        {
            homeBannerTranslation.IsActive = false;
            homeBannerTranslation.DeletedAt = DateTime.Now;
            homeBannerTranslation.DeletedById = UserContext.GetCurrentUser().Id;
        }
    }
}
