using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories;
public class HomeBannerTranslationRepository : IHomeBannerTranslationRepository
{
    private readonly SmellItDbContext _dbContext;

    public HomeBannerTranslationRepository(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<HomeBannerTranslation>> GetAll()
        => await _dbContext.HomeBannerTranslations.Where(hbt 
            => hbt.IsActive).OrderByDescending(b => b.CreatedAt).ToListAsync();

    public async Task<IEnumerable<HomeBannerTranslation>> GetHomeBannerTranslations(int homeBannerId)
        => await _dbContext.HomeBannerTranslations.Where(htt 
            => htt.IsActive && htt.HomeBannerId == homeBannerId).OrderByDescending(b => b.CreatedAt).ToListAsync();

    public async Task<HomeBannerTranslation?> GetTranslation(int homeBannerId, string languageCode)
        => await _dbContext.HomeBannerTranslations.FirstOrDefaultAsync(hbt 
            => hbt.IsActive && hbt.HomeBannerId == homeBannerId && hbt.Language.Code.ToLower() == languageCode.ToLower());

    public async Task<HomeBannerTranslation?> GetByEncodedName(string encodedName)
        => await _dbContext.HomeBannerTranslations.FirstOrDefaultAsync(hbt 
            => hbt.IsActive && hbt.EncodedName == encodedName.ToLower());

    public async Task Create(HomeBannerTranslation homeBannerTranslation)
    {
        homeBannerTranslation.EncodeName();
        _dbContext.Add(homeBannerTranslation);
        await _dbContext.SaveChangesAsync();
    }

    public Task Commit()
        => _dbContext.SaveChangesAsync();
}