using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories;
public class BrandTranslationRepository : IBrandTranslationRepository
{
    private readonly SmellItDbContext _dbContext;

    public BrandTranslationRepository(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<BrandTranslation>> GetAll()
        => await _dbContext.BrandTranslations.Where(bt 
            => bt.IsActive).ToListAsync();

    public async Task<IEnumerable<BrandTranslation>> GetBrandTranslations(int brandId)
        => await _dbContext.BrandTranslations.Where(bt 
            => bt.IsActive && bt.BrandId == brandId).ToListAsync();

    public async Task<BrandTranslation?> GetTranslation(int brandId, string languageCode)
        => await _dbContext.BrandTranslations.FirstOrDefaultAsync(bt 
            => bt.IsActive && bt.BrandId == brandId && bt.Language.Code.ToLower() == languageCode.ToLower());

    public async Task<BrandTranslation?> GetByEncodedName(string encodedName)
        => await _dbContext.BrandTranslations.FirstOrDefaultAsync(bt 
            => bt.IsActive && bt.EncodedName == encodedName.ToLower());

    public async Task Create(BrandTranslation brandTranslation)
    {
        brandTranslation.EncodeName();
        _dbContext.Add(brandTranslation);
        await _dbContext.SaveChangesAsync();
    }

    public Task Commit()
        => _dbContext.SaveChangesAsync();

}
