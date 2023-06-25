using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class ProductRepository : BaseRepositoryWithEncodedName<Product>, IProductRepository
{
    public ProductRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryEncodedNameAsync(string encodedName)
    {
        var category = await DbContext.ProductCategories.FirstOrDefaultAsync(pc => pc.IsActive && pc.EncodedName == encodedName);
        
        return (await GetAllProductsAsync(category)).OrderBy(p => p.CreatedAt);
    }

    private async Task<IEnumerable<Product>> GetAllProductsAsync(ProductCategory? category)
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
                products.AddRange(await GetAllProductsAsync(subcategory));
            }
        }

        return products;
    }

    public async Task<IEnumerable<Product>> GetMostPopularProductsAsync(int count)
    {
        var canceledStatus = (await DbContext.OrderStatusTranslations.FirstOrDefaultAsync(ost => ost.Name == "Canceled"))?.OrderStatus;

        var topProducts = await DbContext.OrderItems
            .Where(oi => oi.IsActive && oi.Order.OrderStatus != canceledStatus && oi.Order.OrderDate >= DateTime.Now.AddMonths(-1))
            .GroupBy(oi => oi.ProductId)
            .Select(group => new
            {
                ProductId = group.Key,
                Quantity = group.Sum(x => x.Quantity)
            })
            .OrderByDescending(x => x.Quantity)
            .Take(count)
            .Select(x => x.ProductId)
            .ToListAsync();

        return await DbContext.Products.Where(p => topProducts.Contains(p.Id)).ToListAsync();
    }

    public override async Task DeleteAsync(Product product)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        product.IsActive = false;
        product.DeletedAt = DateTime.Now;
        product.DeletedById = currentUser.Id;

        DeleteAllRelatedObjects(product, currentUser.Id);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteAsync(string encodedName)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        var product = await GetAsync(encodedName);
        if (product != null)
        {
            product.IsActive = false;
            product.DeletedAt = DateTime.Now;
            product.DeletedById = currentUser.Id;

            DeleteAllRelatedObjects(product, currentUser.Id);

            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteAllRelatedObjects(Product product, string currentUserId)
    {
        foreach (var productTranslation in product.ProductTranslations)
        {
            productTranslation.IsActive = false;
            productTranslation.DeletedAt = DateTime.Now;
            productTranslation.DeletedById = currentUserId;
        }
        foreach (var productPrice in product.ProductPrices)
        {
            productPrice.IsActive = false;
            productPrice.DeletedAt = DateTime.Now;
            productPrice.DeletedById = currentUserId;
        }
        if (product.ProductImages == null) return;
        foreach (var productImage in product.ProductImages)
        {
            productImage.IsActive = false;
            productImage.DeletedAt = DateTime.Now;
            productImage.DeletedById = currentUserId;
        }
    }
}
