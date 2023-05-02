using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class SocialSiteRepository : BaseRepository<SocialSite>, ISocialSiteRepository
{
    public SocialSiteRepository(SmellItDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<SocialSite?> GetByType(string type)
        => await DbContext.SocialSites.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.Type.ToLower() == type.ToLower());
}
