using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories.Abstract
{
    public abstract class BaseRepositoryWithEncodedName<T> : BaseRepository<T> where T : BaseEntityWithEncodedName
    {
        protected BaseRepositoryWithEncodedName(SmellItDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Create(T entity)
        {
            DbContext.Add(entity);
            await DbContext.SaveChangesAsync();
            entity.EncodeName();
            await DbContext.SaveChangesAsync();
        }
        public virtual async Task<T?> GetByEncodedName(string encodedName)
            => await DbContext.Set<T>().Where(b => b.IsActive).FirstOrDefaultAsync(b => b.EncodedName == encodedName);
    }

}
