using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class PrivacyPolicyRepository : BaseRepositoryWithEncodedName<PrivacyPolicy>, IPrivacyPolicyRepository
{
    public PrivacyPolicyRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }
    public async Task<PrivacyPolicy?> GetTranslationAsync(string languageCode)
        => await DbContext.PrivacyPolicies.FirstOrDefaultAsync(pp 
            => pp.IsActive &&  pp.Language.Code.ToLower() == languageCode.ToLower());

    public async Task<PrivacyPolicy?> GetByLanguageCodeAsync(string languageCode)
        => await DbContext.PrivacyPolicies.FirstOrDefaultAsync(pp 
            => pp.IsActive && pp.Language.Code == languageCode.ToLower());
}