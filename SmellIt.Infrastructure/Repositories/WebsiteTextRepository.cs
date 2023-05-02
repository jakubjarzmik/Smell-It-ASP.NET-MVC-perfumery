using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class WebsiteTextRepository : BaseRepository<WebsiteText>, IWebsiteTextRepository
{
    public WebsiteTextRepository(SmellItDbContext dbContext):base(dbContext)
    {
    }

    public async Task<WebsiteText?> GetByKey(string key)
        => await DbContext.WebsiteTexts.Where(b => b.IsActive).FirstOrDefaultAsync(b => b.Key.ToLower() == key.ToLower());
}
