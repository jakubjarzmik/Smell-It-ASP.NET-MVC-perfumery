using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IProductPriceRepository : IBaseRepository<ProductPrice>
{
    Task<ICollection<ProductPrice>> GetByProductAsync(Product product);
    Task<ICollection<ProductPrice>> GetByProductEncodedNameAsync(string productEncodedName);
}
