using SmellIt.Domain.Interfaces.Abstract;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories.Abstract;

public class Repository : IRepository
{
    protected readonly SmellItDbContext DbContext;

    public Repository(SmellItDbContext dbContext)
    {
        DbContext = dbContext;
    }
    
    public async Task CommitAsync()
        => await DbContext.SaveChangesAsync();
}