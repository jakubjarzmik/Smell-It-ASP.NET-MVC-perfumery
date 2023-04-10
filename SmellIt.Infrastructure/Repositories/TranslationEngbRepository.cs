using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories;
public class TranslationEngbRepository : ITranslationEngbRepository
{
    private readonly SmellItDbContext _dbContext;

    public TranslationEngbRepository(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Create(TranslationEngb translationEngb)
    {
        _dbContext.Add(translationEngb);
        await _dbContext.SaveChangesAsync();
    }

    public Task<TranslationEngb?> GetByKey(string key)
        => _dbContext.TranslationEngbs.FirstOrDefaultAsync(t => t.Key.ToLower().Equals(key.ToLower()));
}
