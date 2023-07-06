using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;
using static Dropbox.Api.Files.ListRevisionsMode;

namespace SmellIt.Infrastructure.Repositories;
public class RoleRepository : Repository, IRoleRepository
{
    public RoleRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }

    public async Task<IEnumerable<IdentityRole>> GetAllAsync()
        => await DbContext.Roles.OrderByDescending(u => u.Id).ToListAsync();

    public async Task<IdentityRole?> GetAsync(IdentityRole entity)
        => await DbContext.Roles.FirstOrDefaultAsync(u => u == entity);

    public async Task<IdentityRole?> GetAsync(string id)
        => await DbContext.Roles.FirstOrDefaultAsync(u => u.Id == id);

    public async Task<IdentityRole?> GetByNameAsync(string name)
        => await DbContext.Roles.FirstOrDefaultAsync(u => u.Name == name);

    public async Task DeleteAsync(string id)
    {
        var deletedRole = DbContext.Roles.FirstOrDefault(u => u.Id == id);
        if (deletedRole != null)
        {
            DbContext.Roles.Remove(deletedRole);
            await DbContext.SaveChangesAsync();
        }
    }
} 