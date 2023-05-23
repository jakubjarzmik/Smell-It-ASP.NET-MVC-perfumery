﻿using Microsoft.EntityFrameworkCore;
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
    public override async Task Delete(Brand brand)
    {
        brand.IsActive = false;
        brand.DeletedAt = DateTime.Now;

        DeleteTranslations(brand);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteByEncodedName(string encodedName)
    {
        var brand = await GetByEncodedName(encodedName);
        if (brand != null)
        {
            brand.IsActive = false;
            brand.DeletedAt = DateTime.Now;
            DeleteTranslations(brand);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(Brand brand)
    {
        foreach (var brandTranslation in brand.BrandTranslations)
        {
            brandTranslation.IsActive = false;
            brandTranslation.DeletedAt = DateTime.Now;
        }
    }
}
