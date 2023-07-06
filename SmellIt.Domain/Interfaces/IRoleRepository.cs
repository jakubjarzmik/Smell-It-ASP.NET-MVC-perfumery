using Microsoft.AspNetCore.Identity;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IRoleRepository : IRepository
{
    Task<IEnumerable<IdentityRole>> GetAllAsync();
    Task<IdentityRole?> GetAsync(IdentityRole entity);
    Task<IdentityRole?> GetAsync(string id);
    Task<IdentityRole?> GetByNameAsync(string name);
    Task DeleteAsync(string id);
}
