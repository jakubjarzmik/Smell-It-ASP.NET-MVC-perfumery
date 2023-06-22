using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class WebsiteTextRepository : BaseRepositoryWithEncodedName<WebsiteText>, IWebsiteTextRepository
{
    public WebsiteTextRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }

    public async Task<WebsiteText?> GetByKeyAsync(string key)
        => await DbContext.WebsiteTexts.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.Key.ToLower() == key.ToLower());

    public override async Task DeleteAsync(WebsiteText websiteText)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        websiteText.IsActive = false;
        websiteText.DeletedAt = DateTime.Now;
        websiteText.DeletedById = currentUser.Id;

        DeleteTranslations(websiteText, currentUser.Id);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteAsync(string encodedName)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        var websiteText = await GetAsync(encodedName);
        if (websiteText != null)
        {
            websiteText.IsActive = false;
            websiteText.DeletedAt = DateTime.Now;
            websiteText.DeletedById = currentUser.Id;
            DeleteTranslations(websiteText, currentUser.Id);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(WebsiteText websiteText, string currentUserId)
    {
        foreach (var websiteTextTranslation in websiteText.WebsiteTextTranslations)
        {
            websiteTextTranslation.IsActive = false;
            websiteTextTranslation.DeletedAt = DateTime.Now;
            websiteTextTranslation.DeletedById = currentUserId;
        }
    }
}
