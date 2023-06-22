using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IProductRepository : IBaseRepositoryWithEncodedName<Product>
{
    Task<IEnumerable<Product>> GetProductsByCategoryEncodedNameAsync(string encodedName);
    Task<IEnumerable<Product>> GetMostPopularProductsAsync(int count);
}
