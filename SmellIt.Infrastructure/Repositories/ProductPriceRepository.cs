using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class ProductPriceRepository : BaseRepository<ProductPrice>, IProductPriceRepository
{
    public ProductPriceRepository(SmellItDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ICollection<ProductPrice>> GetByProduct(Product product)
        => await DbContext.ProductPrices.Where(pi => pi.IsActive && pi.Product == product).OrderByDescending(pp=>pp.StartDateTime).ToListAsync();

    public async Task<ICollection<ProductPrice>> GetByProductEncodedName(string productEncodedName)
        => await DbContext.ProductPrices.Where(pi => pi.IsActive && pi.Product.EncodedName == productEncodedName).OrderByDescending(pp=>pp.StartDateTime).ToListAsync();
}
