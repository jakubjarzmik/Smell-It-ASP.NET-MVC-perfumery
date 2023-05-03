using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories.Abstract
{
    public abstract class BaseRepository<T> where T : BaseEntityWithEncodedName
    {
        protected readonly SmellItDbContext DbContext;

        protected BaseRepository(SmellItDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task Create(T entity)
        {
            DbContext.Add(entity);
            await DbContext.SaveChangesAsync();
            entity.EncodeName();
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
            => await DbContext.Set<T>().Where(b => b.IsActive).OrderByDescending(b => b.CreatedAt).ToListAsync();

        public virtual async Task<T?> GetByEncodedName(string encodedName)
            => await DbContext.Set<T>().Where(b => b.IsActive).FirstOrDefaultAsync(b => b.EncodedName == encodedName);

        public async Task Commit()
            => await DbContext.SaveChangesAsync();
    }

}
