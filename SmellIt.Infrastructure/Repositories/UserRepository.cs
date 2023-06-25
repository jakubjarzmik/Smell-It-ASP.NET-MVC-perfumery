using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class UserRepository : Repository, IUserRepository
{
    public UserRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }

    public async Task<int> CountAsync()
        => await DbContext.Users.CountAsync();
    public IEnumerable<IdentityUser> GetLatestListAsync(int count)
        =>  DbContext.Users.AsEnumerable().TakeLast(count);

    public async Task<IEnumerable<IdentityUser>> GetPaginatedAsync(int pageNumber, int pageSize)
    {
        var entities = DbContext.Users
            .OrderByDescending(u=>u.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return await entities.ToListAsync();
    }

    public async Task<IdentityUser?> GetAsync(string id)
        => await DbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

    public async Task<IdentityUser?> GetByEmailAsync(string email)
        => await DbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

    public IdentityUser? GetByEmail(string email)
        => DbContext.Users.FirstOrDefault(u => u.Email == email);

    public async Task DeleteAsync(string id)
    {
        var deletedUser = DbContext.Users.FirstOrDefault(u => u.Id == id);
        if (deletedUser != null)
        {
            DbContext.Users.Remove(deletedUser);
            await DbContext.SaveChangesAsync();
        }
    }
} 