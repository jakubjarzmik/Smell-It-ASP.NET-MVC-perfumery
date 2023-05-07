using Microsoft.EntityFrameworkCore;
using SmellIt.Application.Helpers;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class ProductCategoryRepository : BaseRepositoryWithEncodedName<ProductCategory>, IProductCategoryRepository
{
    public ProductCategoryRepository(SmellItDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<IEnumerable<ProductCategory>> GetAll()
        => ProductCategoryManager.SortCategories(await DbContext.ProductCategories.Where(b => b.IsActive).ToListAsync());

    public async Task<IEnumerable<ProductCategory>> GetProductCategoriesByParentCategory(ProductCategory parentCategory)
    => await DbContext.ProductCategories.Where(pc => pc.IsActive && pc.ParentCategory == parentCategory).OrderByDescending(b => b.CreatedAt).ToListAsync();
}
