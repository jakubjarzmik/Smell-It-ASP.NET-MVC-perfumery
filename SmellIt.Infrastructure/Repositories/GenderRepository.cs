using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class GenderRepository : BaseRepositoryWithEncodedName<Gender>, IGenderRepository
{
    public GenderRepository(SmellItDbContext dbContext) : base(dbContext)
    {
    }
}
