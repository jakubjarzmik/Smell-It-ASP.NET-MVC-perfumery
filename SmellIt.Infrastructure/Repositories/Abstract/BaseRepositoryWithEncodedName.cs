using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Interfaces.Abstract;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories.Abstract
{
    public abstract class BaseRepositoryWithEncodedName<T> : BaseRepository<T>, IBaseRepositoryWithEncodedName<T> 
        where T : BaseEntityWithEncodedName
    {
        protected BaseRepositoryWithEncodedName(SmellItDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task CreateAsync(T entity)
        {
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
                entity.IsActive = false;
                entity.DeletedAt = DateTime.Now;
                await DbContext.SaveChangesAsync();
            }
        }

        public virtual async Task<T?> GetByEncodedNameAsync(string encodedName)
            => await DbContext.Set<T>().Where(b => b.IsActive).FirstOrDefaultAsync(b => b.EncodedName == encodedName);
    }
}
