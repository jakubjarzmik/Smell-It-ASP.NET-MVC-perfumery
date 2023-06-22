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
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        homeBanner.IsActive = false;
        homeBanner.DeletedAt = DateTime.Now;
        homeBanner.DeletedById = currentUser.Id;
        DeleteTranslations(homeBanner, currentUser.Id);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteAsync(string encodedName)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        var homeBanner = await GetAsync(encodedName);
        if (homeBanner != null)
        {
            homeBanner.IsActive = false;
            homeBanner.DeletedAt = DateTime.Now;
            homeBanner.DeletedById = currentUser.Id;
            DeleteTranslations(homeBanner, currentUser.Id);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(HomeBanner homeBanner, string currentUserId)
    {
        foreach (var homeBannerTranslation in homeBanner.HomeBannerTranslations)
        {
            homeBannerTranslation.IsActive = false;
            homeBannerTranslation.DeletedAt = DateTime.Now;
            homeBannerTranslation.DeletedById = currentUserId;
        }
    }
}
