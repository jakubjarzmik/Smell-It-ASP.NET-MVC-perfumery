using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class FragranceCategoryRepository : BaseRepositoryWithEncodedName<FragranceCategory>, IFragranceCategoryRepository
{
    public FragranceCategoryRepository(SmellItDbContext dbContext): base(dbContext)
    {
    }
}
