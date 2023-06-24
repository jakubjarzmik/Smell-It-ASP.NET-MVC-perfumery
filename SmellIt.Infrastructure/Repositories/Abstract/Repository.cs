using SmellIt.Domain.Interfaces;
using SmellIt.Domain.Interfaces.Abstract;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories.Abstract;

public class Repository : IRepository
{
    protected readonly SmellItDbContext DbContext;
    protected readonly IUserContext UserContext;

    public Repository(SmellItDbContext dbContext, IUserContext userContext)
    {
        DbContext = dbContext;
        UserContext = userContext;
    }
    
    public async Task CommitAsync()
        => await DbContext.SaveChangesAsync();
}