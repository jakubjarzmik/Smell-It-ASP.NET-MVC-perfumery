using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Interfaces;
using SmellIt.Domain.Interfaces.Abstract;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories.Abstract;

public abstract class BaseRepositoryWithEncodedName<T> : BaseRepository<T>, IBaseRepositoryWithEncodedName<T> where T : BaseEntityWithEncodedName
{
    protected BaseRepositoryWithEncodedName(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }

    public override async Task CreateAsync(T entity)
    {
        entity.CreatedById = UserContext.GetCurrentUser().Id;
        DbContext.Add(entity);
        await DbContext.SaveChangesAsync();
        entity.EncodeName();
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteByEncodedNameAsync(string encodedName)
    {
        var entity = await GetByEncodedNameAsync(encodedName);
        if (entity != null)
        {
            entity.DeletedById = UserContext.GetCurrentUser().Id;
            entity.IsActive = false;
            entity.DeletedAt = DateTime.Now;
            await DbContext.SaveChangesAsync();
        }
    }

    public virtual async Task<T?> GetByEncodedNameAsync(string encodedName)
        => await DbContext.Set<T>().Where(b => b.IsActive).FirstOrDefaultAsync(b => b.EncodedName == encodedName);
}