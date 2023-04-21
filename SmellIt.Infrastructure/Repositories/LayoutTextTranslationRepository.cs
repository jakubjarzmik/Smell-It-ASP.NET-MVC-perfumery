using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories;
public class LayoutTextTranslationRepository : ILayoutTextTranslationRepository
{
    private readonly SmellItDbContext _dbContext;

    public LayoutTextTranslationRepository(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<LayoutTextTranslation>> GetAll()
        => await _dbContext.LayoutTextTranslations.Where(ltt 
            => ltt.IsActive).ToListAsync();

    public async Task<IEnumerable<LayoutTextTranslation>> GetLayoutTextTranslations(int layoutTextId)
        => await _dbContext.LayoutTextTranslations.Where(ltt 
            => ltt.IsActive && ltt.LayoutTextId == layoutTextId).ToListAsync();

    public async Task<LayoutTextTranslation?> GetTranslation(int layoutTextId, string languageCode)
        => await _dbContext.LayoutTextTranslations.FirstOrDefaultAsync(ltt 
            => ltt.IsActive && ltt.LayoutTextId == layoutTextId && ltt.Language.Code.ToLower() == languageCode.ToLower());

    public async Task<LayoutTextTranslation?> GetByEncodedName(string encodedName)
        => await _dbContext.LayoutTextTranslations.FirstOrDefaultAsync(ltt 
            => ltt.IsActive && ltt.EncodedName == encodedName.ToLower());

    public async Task Create(LayoutTextTranslation layoutTextTranslation)
    {
        layoutTextTranslation.EncodeName();
        _dbContext.Add(layoutTextTranslation);
        await _dbContext.SaveChangesAsync();
    }

    public Task Commit()
        => _dbContext.SaveChangesAsync();
}