using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class BrandRepository : BaseRepositoryWithEncodedName<Brand>, IBrandRepository
{
    public BrandRepository(SmellItDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Brand?> GetByName(string name)
        => await DbContext.Brands.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.Name.ToLower() == name.ToLower());
}
