using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories;
public class WebsiteTextRepository : IWebsiteTextRepository
{
    private readonly SmellItDbContext _dbContext;

    public WebsiteTextRepository(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(WebsiteText websiteText)
    {
        _dbContext.Add(websiteText);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<WebsiteText>> GetAll()
        => await _dbContext.WebsiteTexts.Where(b => b.IsActive).OrderByDescending(b=>b.CreatedAt).ToListAsync();

    public async Task<WebsiteText?> GetByKey(string key)
        => await _dbContext.WebsiteTexts.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.Key.ToLower() == key.ToLower());
    public async Task<WebsiteText?> GetByEncodedName(string encodedName)
        => await _dbContext.WebsiteTexts.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.EncodedName == encodedName);

    public Task Commit()
        => _dbContext.SaveChangesAsync();
}
