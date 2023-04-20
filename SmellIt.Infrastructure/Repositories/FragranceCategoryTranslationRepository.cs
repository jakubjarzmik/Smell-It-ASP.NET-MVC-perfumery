using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories;
public class FragranceCategoryTranslationRepository : IFragranceCategoryTranslationRepository
{
    private readonly SmellItDbContext _dbContext;

    public FragranceCategoryTranslationRepository(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<FragranceCategoryTranslation>> GetAll()
        => await _dbContext.FragranceCategoryTranslations.Where(bt 
            => bt.IsActive).ToListAsync();

    public async Task<IEnumerable<FragranceCategoryTranslation>> GetFragranceCategoryTranslations(int fragranceCategoryId)
        => await _dbContext.FragranceCategoryTranslations.Where(bt 
            => bt.IsActive && bt.FragranceCategoryId == fragranceCategoryId).ToListAsync();

    public async Task<FragranceCategoryTranslation?> GetTranslation(int fragranceCategoryId, string languageCode)
        => await _dbContext.FragranceCategoryTranslations.FirstOrDefaultAsync(bt
            => bt.IsActive && bt.FragranceCategoryId == fragranceCategoryId && bt.Language.Code.ToLower() == languageCode.ToLower());

    public async Task<FragranceCategoryTranslation?> GetByEncodedName(string encodedName)
          => await _dbContext.FragranceCategoryTranslations.FirstOrDefaultAsync(bt 
              => bt.IsActive && bt.EncodedName == encodedName.ToLower());

    public async Task Create(FragranceCategoryTranslation fragranceCategoryTranslation)
    {
        fragranceCategoryTranslation.EncodeName();
        _dbContext.Add(fragranceCategoryTranslation);
        await _dbContext.SaveChangesAsync();
    }

    public Task Commit()
        => _dbContext.SaveChangesAsync();

}
