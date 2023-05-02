﻿using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class PrivacyPolicyRepository : BaseRepository<PrivacyPolicy>, IPrivacyPolicyRepository
{
    public PrivacyPolicyRepository(SmellItDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<PrivacyPolicy?> GetTranslation(string languageCode)
        => await DbContext.PrivacyPolicies.FirstOrDefaultAsync(pp 
            => pp.IsActive &&  pp.Language.Code.ToLower() == languageCode.ToLower());

    public async Task<PrivacyPolicy?> GetByLanguageCode(string languageCode)
        => await DbContext.PrivacyPolicies.FirstOrDefaultAsync(pp 
            => pp.IsActive && pp.Language.Code == languageCode.ToLower());
}