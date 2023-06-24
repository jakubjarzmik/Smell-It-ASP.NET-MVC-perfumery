using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Interfaces;
using SmellIt.Domain.Interfaces.Abstract;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories.Abstract;

public abstract class BaseRepository<T> : Repository, IBaseRepository<T> where T : BaseEntity
{
    protected BaseRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }

    public virtual async Task CreateAsync(T cartItem)
    {
        var currentUser = UserContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return;
        }

        cartItem.CreatedById = currentUser.Id;
        DbContext.Add(cartItem);
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

    public virtual async Task<T?> GetAsync(T entity)
        => await DbContext.Set<T>().Where(b => b.IsActive).FirstOrDefaultAsync(b => b == entity);

    public virtual async Task<T?> GetAsync(int id)
        => await DbContext.Set<T>().Where(b => b.IsActive).FirstOrDefaultAsync(b => b.Id == id);
    
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

    public async Task<IEnumerable<T>> GetLatestListAsync(int count)
        => await DbContext.Set<T>().Where(b => b.IsActive).OrderByDescending(b => b.CreatedAt).Take(count).ToListAsync();
}