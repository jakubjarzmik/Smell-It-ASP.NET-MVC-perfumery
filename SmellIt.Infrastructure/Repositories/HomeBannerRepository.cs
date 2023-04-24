using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories;
public class HomeBannerRepository : IHomeBannerRepository
{
    private readonly SmellItDbContext _dbContext;

    public HomeBannerRepository(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(HomeBanner homeBanner)
    {
        _dbContext.Add(homeBanner);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<HomeBanner>> GetAll()
        => await _dbContext.HomeBanners.Where(b => b.IsActive).OrderByDescending(b=>b.CreatedAt).ToListAsync();

    public async Task<HomeBanner?> GetByKey(string key)
        => await _dbContext.HomeBanners.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.Key.ToLower() == key.ToLower());
    public async Task<HomeBanner?> GetByEncodedName(string encodedName)
        => await _dbContext.HomeBanners.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.EncodedName == encodedName);

    public Task Commit()
        => _dbContext.SaveChangesAsync();
}
