using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories;
public class WebsiteTextTranslationRepository : IWebsiteTextTranslationRepository
{
    private readonly SmellItDbContext _dbContext;

    public WebsiteTextTranslationRepository(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<WebsiteTextTranslation>> GetAll()
        => await _dbContext.WebsiteTextTranslations.Where(ltt 
            => ltt.IsActive).ToListAsync();

    public async Task<IEnumerable<WebsiteTextTranslation>> GetWebsiteTextTranslations(int websiteTextId)
        => await _dbContext.WebsiteTextTranslations.Where(ltt 
            => ltt.IsActive && ltt.LayoutTextId == websiteTextId).ToListAsync();

    public async Task<WebsiteTextTranslation?> GetTranslation(int websiteTextId, string languageCode)
        => await _dbContext.WebsiteTextTranslations.FirstOrDefaultAsync(ltt 
            => ltt.IsActive && ltt.LayoutTextId == websiteTextId && ltt.Language.Code.ToLower() == languageCode.ToLower());

    public async Task<WebsiteTextTranslation?> GetByEncodedName(string encodedName)
        => await _dbContext.WebsiteTextTranslations.FirstOrDefaultAsync(ltt 
            => ltt.IsActive && ltt.EncodedName == encodedName.ToLower());

    public async Task Create(WebsiteTextTranslation websiteTextTranslation)
    {
        websiteTextTranslation.EncodeName();
        _dbContext.Add(websiteTextTranslation);
        await _dbContext.SaveChangesAsync();
    }

    public Task Commit()
        => _dbContext.SaveChangesAsync();
}