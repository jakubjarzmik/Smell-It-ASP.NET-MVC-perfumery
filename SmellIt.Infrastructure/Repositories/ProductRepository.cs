using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly SmellItDbContext _dbContext;

    public ProductRepository(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Create(Product product)
    {
        _dbContext.Add(product);
        await _dbContext.SaveChangesAsync();
    }
}
