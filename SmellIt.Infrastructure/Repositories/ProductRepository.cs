using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<Product>> GetProductsByCategoryEncodedName(string encodedName)
    {
        var category = await DbContext.ProductCategories.FirstOrDefaultAsync(pc => pc.IsActive && pc.EncodedName == encodedName);
        
        return (await GetAllProducts(category)).OrderBy(p => p.CreatedAt);
    }

    private async Task<IEnumerable<Product>> GetAllProducts(ProductCategory? category)
    {
        var products = new List<Product>();
        
        if (category?.Products.Count > 0)
        {
            products.AddRange(category.Products.Where(p => p.IsActive));
        }
        
        if (category?.ProductCategories.Count > 0)
        {
            foreach (var subcategory in category.ProductCategories)
            {
                products.AddRange(await GetAllProducts(subcategory));
            }
        }

        return products;
    }
}
