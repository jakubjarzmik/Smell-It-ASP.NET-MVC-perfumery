using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface IProductRepository
{
    Task Create(Product product);
}
