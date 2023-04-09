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
}
