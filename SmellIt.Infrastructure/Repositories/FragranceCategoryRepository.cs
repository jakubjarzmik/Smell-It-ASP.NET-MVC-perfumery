using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories;
public class FragranceCategoryRepository : IFragranceCategoryRepository
{
    private readonly SmellItDbContext _dbContext;

    public FragranceCategoryRepository(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(FragranceCategory fragranceCategory)
    {
        _dbContext.Add(fragranceCategory);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<FragranceCategory>> GetAll()
        => await _dbContext.FragranceCategories.Where(b => b.IsActive).OrderByDescending(b=>b.CreatedAt).ToListAsync();
    
    public async Task<FragranceCategory?> GetByEncodedName(string encodedName)
        => await _dbContext.FragranceCategories.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.EncodedName == encodedName);

    public Task Commit()
        => _dbContext.SaveChangesAsync();

}
