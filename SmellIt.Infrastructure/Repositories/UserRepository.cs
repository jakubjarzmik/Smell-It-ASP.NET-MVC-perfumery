using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class UserRepository : Repository, IUserRepository
{
    public UserRepository(SmellItDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<int> CountAsync()
        => await DbContext.Users.CountAsync();
    public IEnumerable<IdentityUser> GetLatestListAsync(int count)
        =>  DbContext.Users.AsEnumerable().TakeLast(count);
} 