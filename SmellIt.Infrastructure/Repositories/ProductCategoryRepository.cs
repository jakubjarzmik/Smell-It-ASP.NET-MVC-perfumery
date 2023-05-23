﻿using Microsoft.EntityFrameworkCore;
using SmellIt.Application.Helpers;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class ProductCategoryRepository : BaseRepositoryWithEncodedName<ProductCategory>, IProductCategoryRepository
{
    private readonly IProductCategorySorter _productCategorySorter;

    public ProductCategoryRepository(SmellItDbContext dbContext, IProductCategorySorter productCategorySorter) : base(dbContext)
    {
        _productCategorySorter = productCategorySorter;
    }

    public override async Task<IEnumerable<ProductCategory>> GetAll()
        => _productCategorySorter.SortCategories(await DbContext.ProductCategories.Where(b => b.IsActive).ToListAsync());

    public async Task<IEnumerable<ProductCategory>> GetProductCategoriesByParentCategory(ProductCategory parentCategory)
    => await DbContext.ProductCategories.Where(pc => pc.IsActive && pc.ParentCategory == parentCategory).OrderByDescending(b => b.CreatedAt).ToListAsync();

    public override async Task Delete(ProductCategory productCategory)
    {
        productCategory.IsActive = false;
        productCategory.DeletedAt = DateTime.Now;

        DeleteTranslations(productCategory);

        await DbContext.SaveChangesAsync();
    }

    public override async Task DeleteByEncodedName(string encodedName)
    {
        var productCategory = await GetByEncodedName(encodedName);
        if (productCategory != null)
        {
            productCategory.IsActive = false;
            productCategory.DeletedAt = DateTime.Now;
            DeleteTranslations(productCategory);
            await DbContext.SaveChangesAsync();
        }
    }

    private void DeleteTranslations(ProductCategory productCategory)
    {
        foreach (var productCategoryTranslation in productCategory.ProductCategoryTranslations)
        {
            productCategoryTranslation.IsActive = false;
            productCategoryTranslation.DeletedAt = DateTime.Now;
        }
    }
}
