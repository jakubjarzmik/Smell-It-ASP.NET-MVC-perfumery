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

    public async Task<IEnumerable<Product>> GetProductsByCategoryEncodedNameAsync(string encodedName)
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

    public override async Task DeleteAsync(Product product)
    {
        product.IsActive = false;
        product.DeletedAt = DateTime.Now;

        DeleteAllRelatedObjects(product);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteByEncodedNameAsync(string encodedName)
    {
        var product = await GetByEncodedNameAsync(encodedName);
        if (product != null)
        {
            product.IsActive = false;
            product.DeletedAt = DateTime.Now;

            DeleteAllRelatedObjects(product);

            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteAllRelatedObjects(Product product)
    {
        foreach (var productTranslation in product.ProductTranslations)
        {
            productTranslation.IsActive = false;
            productTranslation.DeletedAt = DateTime.Now;
        }
        foreach (var productPrice in product.ProductPrices)
        {
            productPrice.IsActive = false;
            productPrice.DeletedAt = DateTime.Now;
        }
        if (product.ProductImages == null) return;
        foreach (var productImage in product.ProductImages)
        {
            productImage.IsActive = false;
            productImage.DeletedAt = DateTime.Now;
        }
    }
}
