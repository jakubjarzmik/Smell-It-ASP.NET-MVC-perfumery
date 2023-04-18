using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories;
public class BrandRepository : IBrandRepository
{
    private readonly SmellItDbContext _dbContext;

    public BrandRepository(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(Brand brand)
    {
        _dbContext.Add(brand);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Brand>> GetAll()
        => await _dbContext.Brands.Where(b => b.IsActive).OrderByDescending(b=>b.CreatedAt).ToListAsync();

    public async Task<Brand?> GetByName(string name)
        => await _dbContext.Brands.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.Name.ToLower() == name.ToLower());
    public async Task<Brand?> GetByEncodedName(string encodedName)
        => await _dbContext.Brands.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.EncodedName == encodedName);

    public Task Commit()
        => _dbContext.SaveChangesAsync();

}
