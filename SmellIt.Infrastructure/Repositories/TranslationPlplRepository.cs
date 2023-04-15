using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories;
public class TranslationPlplRepository : ITranslationPlplRepository
{
    private readonly SmellItDbContext _dbContext;

    public TranslationPlplRepository(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Create(TranslationPlpl translationPlpl)
    {
        _dbContext.Add(translationPlpl);
        await _dbContext.SaveChangesAsync();
    }

    public Task<TranslationPlpl?> GetByKey(string key)
        => _dbContext.TranslationPlpls.FirstOrDefaultAsync(t => t.Key.ToLower().Equals(key.ToLower()));

    public Task Commit()
        => _dbContext.SaveChangesAsync();
}
