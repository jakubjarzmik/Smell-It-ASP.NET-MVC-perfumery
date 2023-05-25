using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IProductImageRepository : IBaseRepository<ProductImage>
{
    Task<ICollection<ProductImage>?> GetByProductIdAsync(int id);
}
