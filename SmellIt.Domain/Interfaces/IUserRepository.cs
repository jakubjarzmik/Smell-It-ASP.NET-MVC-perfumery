using Microsoft.AspNetCore.Identity;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IUserRepository : IRepository
{
    Task<int> CountAsync();
    IEnumerable<IdentityUser> GetLatestListAsync(int count);
    Task<IEnumerable<IdentityUser>> GetPaginatedAsync(int pageNumber, int pageSize);
    Task<IdentityUser?> GetAsync(string id);
    Task<IdentityUser?> GetByEmailAsync(string email);
    IdentityUser? GetByEmail(string email);
    Task DeleteAsync(string id);
}
