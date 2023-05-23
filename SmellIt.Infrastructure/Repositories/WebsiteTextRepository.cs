using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class WebsiteTextRepository : BaseRepositoryWithEncodedName<WebsiteText>, IWebsiteTextRepository
{
    public WebsiteTextRepository(SmellItDbContext dbContext):base(dbContext)
    {
    }

    public async Task<WebsiteText?> GetByKey(string key)
        => await DbContext.WebsiteTexts.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.Key.ToLower() == key.ToLower());

    public override async Task Delete(WebsiteText websiteText)
    {
        websiteText.IsActive = false;
        websiteText.DeletedAt = DateTime.Now;

        DeleteTranslations(websiteText);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteByEncodedName(string encodedName)
    {
        var websiteText = await GetByEncodedName(encodedName);
        if (websiteText != null)
        {
            websiteText.IsActive = false;
            websiteText.DeletedAt = DateTime.Now;
            DeleteTranslations(websiteText);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(WebsiteText websiteText)
    {
        foreach (var websiteTextTranslation in websiteText.WebsiteTextTranslations)
        {
            websiteTextTranslation.IsActive = false;
            websiteTextTranslation.DeletedAt = DateTime.Now;
        }
    }
}
