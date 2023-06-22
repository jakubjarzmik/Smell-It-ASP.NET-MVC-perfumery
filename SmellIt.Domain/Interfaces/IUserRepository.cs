using Microsoft.AspNetCore.Identity;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IUserRepository : IRepository
{
    Task<int> CountAsync();
    IEnumerable<IdentityUser> GetLatestListAsync(int count);
}
