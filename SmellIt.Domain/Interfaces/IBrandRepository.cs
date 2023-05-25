using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IBrandRepository : IBaseRepositoryWithEncodedName<Brand>
{
    Task<Brand?> GetByNameAsync(string name);
}
