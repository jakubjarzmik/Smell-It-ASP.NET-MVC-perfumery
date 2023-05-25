using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class LanguageRepository : BaseRepositoryWithEncodedName<Language>, ILanguageRepository
{
    public LanguageRepository(SmellItDbContext dbContext) :base (dbContext)
    {
    }
    public Task<Language?> GetByCodeAsync(string code)
        => DbContext.Languages.Where(bt => bt.IsActive).FirstOrDefaultAsync(b => b.Code == code);

}
