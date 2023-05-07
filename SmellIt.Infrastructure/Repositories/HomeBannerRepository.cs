using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class HomeBannerRepository : BaseRepositoryWithEncodedName<HomeBanner>, IHomeBannerRepository
{
    public HomeBannerRepository(SmellItDbContext dbContext) : base(dbContext) { }

    public async Task<HomeBanner?> GetByKey(string key)
        => await DbContext.HomeBanners.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.Key.ToLower() == key.ToLower());
}
