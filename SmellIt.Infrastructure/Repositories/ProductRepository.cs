using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class ProductRepository : BaseRepositoryWithEncodedName<Product>, IProductRepository
{
    public ProductRepository(SmellItDbContext dbContext):base(dbContext)
    {
    }
}
