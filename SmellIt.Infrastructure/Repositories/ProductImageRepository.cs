using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class ProductImageRepository : BaseRepository<ProductImage>, IProductImageRepository
{
    public ProductImageRepository(SmellItDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ICollection<ProductImage>?> GetByProductId(int id)
        => await DbContext.ProductImages.Where(pi => pi.IsActive && pi.ProductId == id).ToListAsync();
}
