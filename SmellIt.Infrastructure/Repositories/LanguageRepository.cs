﻿using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Repositories;
public class LanguageRepository : ILanguageRepository
{
    private readonly SmellItDbContext _dbContext;

    public LanguageRepository(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(Language language)
    {
        _dbContext.Add(language);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Language>> GetAll()
        => await _dbContext.Languages.Where(bt => bt.IsActive).ToListAsync();

    public Task<Language?> GetByCode(string code)
        => _dbContext.Languages.Where(bt => bt.IsActive).FirstOrDefaultAsync(b => b.Code == code);

}