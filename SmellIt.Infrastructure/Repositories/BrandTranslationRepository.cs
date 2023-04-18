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

    public async Task Create(BrandTranslation brandTranslation)
    {
        brandTranslation.EncodeName();
        _dbContext.Add(brandTranslation);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<BrandTranslation>> GetAll()
        => await _dbContext.BrandTranslations.ToListAsync();

    public async Task<IEnumerable<BrandTranslation>> GetByBrandId(int id)
        => await _dbContext.BrandTranslations.Where(b => b.BrandId == id).ToListAsync();

    public async Task<BrandTranslation?> GetByEncodedName(string encodedName)
        => await _dbContext.BrandTranslations.FirstOrDefaultAsync(b => b.EncodedName == encodedName.ToLower());

    public Task Commit()
        => _dbContext.SaveChangesAsync();

}
