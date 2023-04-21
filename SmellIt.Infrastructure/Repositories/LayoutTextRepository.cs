using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories;
public class LayoutTextRepository : ILayoutTextRepository
{
    private readonly SmellItDbContext _dbContext;

    public LayoutTextRepository(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(LayoutText layoutText)
    {
        _dbContext.Add(layoutText);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<LayoutText>> GetAll()
        => await _dbContext.LayoutTexts.Where(b => b.IsActive).OrderByDescending(b=>b.CreatedAt).ToListAsync();

    public async Task<LayoutText?> GetByKey(string key)
        => await _dbContext.LayoutTexts.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.Key.ToLower() == key.ToLower());
    public async Task<LayoutText?> GetByEncodedName(string encodedName)
        => await _dbContext.LayoutTexts.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.EncodedName == encodedName);

    public Task Commit()
        => _dbContext.SaveChangesAsync();
}
