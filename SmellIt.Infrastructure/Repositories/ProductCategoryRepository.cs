using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
{
    public ProductCategoryRepository(SmellItDbContext dbContext): base(dbContext)
    {
    }

    public async Task<IEnumerable<ProductCategory>> GetProductCategoriesByParentCategory(ProductCategory parentCategory)
        => await DbContext.ProductCategories.Where(pc => pc.IsActive && pc.ParentCategory == parentCategory).ToListAsync();
}
