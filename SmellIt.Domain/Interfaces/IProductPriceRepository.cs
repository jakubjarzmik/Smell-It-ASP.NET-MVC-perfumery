using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IProductPriceRepository : IBaseRepository<ProductPrice>
{
    Task Create(ProductPrice productPrice);
    Task<ICollection<ProductPrice>> GetByProduct(Product product);
}
