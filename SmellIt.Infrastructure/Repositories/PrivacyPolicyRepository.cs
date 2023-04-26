using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories;
public class PrivacyPolicyRepository : IPrivacyPolicyRepository
{
    private readonly SmellItDbContext _dbContext;

    public PrivacyPolicyRepository(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PrivacyPolicy>> GetAll()
        => await _dbContext.PrivacyPolicies.Where(pp 
            => pp.IsActive).ToListAsync();

    public async Task<PrivacyPolicy?> GetTranslation(string languageCode)
        => await _dbContext.PrivacyPolicies.FirstOrDefaultAsync(pp 
            => pp.IsActive &&  pp.Language.Code.ToLower() == languageCode.ToLower());

    public async Task<PrivacyPolicy?> GetByEncodedName(string encodedName)
        => await _dbContext.PrivacyPolicies.FirstOrDefaultAsync(pp 
            => pp.IsActive && pp.EncodedName == encodedName.ToLower());

    public async Task<PrivacyPolicy?> GetByLanguageCode(string languageCode)
        => await _dbContext.PrivacyPolicies.FirstOrDefaultAsync(pp 
            => pp.IsActive && pp.Language.Code == languageCode.ToLower());

    public async Task Create(PrivacyPolicy privacyPolicy)
    {
        privacyPolicy.EncodeName();
        _dbContext.Add(privacyPolicy);
        await _dbContext.SaveChangesAsync();
    }

    public Task Commit()
        => _dbContext.SaveChangesAsync();
}