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

    public async Task Create(FragranceCategoryTranslation fragranceCategoryTranslation)
    {
        fragranceCategoryTranslation.EncodeName();
        _dbContext.Add(fragranceCategoryTranslation);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<FragranceCategoryTranslation>> GetAll()
        => await _dbContext.FragranceCategoryTranslations.Where(bt => bt.IsActive).ToListAsync();

    public async Task<IEnumerable<FragranceCategoryTranslation>> GetByFragranceCategoryId(int id)
        => await _dbContext.FragranceCategoryTranslations.Where(bt => bt.IsActive && bt.FragranceCategoryId == id).ToListAsync();

    public async Task<FragranceCategoryTranslation?> GetByEncodedName(string encodedName)
        => await _dbContext.FragranceCategoryTranslations.Where(bt => bt.IsActive).FirstOrDefaultAsync(bt => bt.EncodedName == encodedName.ToLower());

    public Task Commit()
        => _dbContext.SaveChangesAsync();

}
