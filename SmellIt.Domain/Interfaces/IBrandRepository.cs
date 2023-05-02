using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IBrandRepository : IBaseRepository<Brand>
{
    Task<Brand?> GetByName(string name);
}
