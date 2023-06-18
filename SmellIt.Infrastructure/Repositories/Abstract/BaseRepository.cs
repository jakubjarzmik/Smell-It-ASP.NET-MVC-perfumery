using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Interfaces;
using SmellIt.Domain.Interfaces.Abstract;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories.Abstract;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly SmellItDbContext DbContext;
    protected readonly IUserContext UserContext;

    protected BaseRepository(SmellItDbContext dbContext, IUserContext userContext)
    {
        DbContext = dbContext;
        UserContext = userContext;
    }

    public virtual async Task CreateAsync(T entity)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        entity.CreatedById = currentUser.Id;
        DbContext.Add(entity);
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        entity.DeletedById = currentUser.Id;
        entity.IsActive = false;
        entity.DeletedAt = DateTime.Now;
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
        => await DbContext.Set<T>().Where(b => b.IsActive).OrderByDescending(b => b.CreatedAt).ToListAsync();

    public virtual async Task<T?> GetByIdAsync(int id)
        => await DbContext.Set<T>().Where(b => b.IsActive).FirstOrDefaultAsync(b => b.Id == id);

    public async Task CommitAsync()
        => await DbContext.SaveChangesAsync();

    public async Task<int> CountAsync()
        => await DbContext.Set<T>().CountAsync(b => b.IsActive);

    public async Task<IEnumerable<T>> GetPaginatedAsync(int pageNumber, int pageSize)
    {
        var entities = DbContext.Set<T>().Where(b => b.IsActive)
            .OrderByDescending(b => b.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return await entities.ToListAsync();
    }
}