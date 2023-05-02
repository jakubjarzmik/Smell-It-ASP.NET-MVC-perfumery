using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories;
public class SocialSiteRepository : ISocialSiteRepository
{
    private readonly SmellItDbContext _dbContext;

    public SocialSiteRepository(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(SocialSite socialSite)
    {
        _dbContext.Add(socialSite);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<SocialSite>> GetAll()
        => await _dbContext.SocialSites.Where(b => b.IsActive).OrderByDescending(b=>b.CreatedAt).ToListAsync();

    public async Task<SocialSite?> GetByEncodedName(string encodedName)
        => await _dbContext.SocialSites.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.EncodedName!.ToLower() == encodedName.ToLower());

    public async Task<SocialSite?> GetByType(string type)
        => await _dbContext.SocialSites.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.Type.ToLower() == type.ToLower());

    public Task Commit()
        => _dbContext.SaveChangesAsync();

}
