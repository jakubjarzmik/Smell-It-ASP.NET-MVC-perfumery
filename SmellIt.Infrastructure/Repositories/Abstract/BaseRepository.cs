using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories.Abstract
{
    public abstract class BaseRepository<T> where T : BaseEntity
    {
        protected readonly SmellItDbContext DbContext;

        protected BaseRepository(SmellItDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task Create(T entity)
        {
            DbContext.Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task Delete(T entity)
        {
            entity.IsActive = false;
            entity.DeletedAt = DateTime.Now;
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
            => await DbContext.Set<T>().Where(b => b.IsActive).OrderByDescending(b => b.CreatedAt).ToListAsync();

        public virtual async Task<T?> GetById(int id)
            => await DbContext.Set<T>().Where(b => b.IsActive).FirstOrDefaultAsync(b => b.Id == id);

        public async Task Commit()
            => await DbContext.SaveChangesAsync();
    }

}
