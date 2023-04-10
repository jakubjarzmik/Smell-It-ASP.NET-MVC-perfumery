using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Domain.Entities;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Seeders
{
    public class ProductCategorySeeder : ISeeder
    {
        private readonly SmellItDbContext _dbContext;

        public ProductCategorySeeder(SmellItDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (!_dbContext.ProductCategories.Any())
            {
                List<ProductCategory> productCategories = new()
                {
                    new ProductCategory { NameKey = "Devices", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new ProductCategory { NameKey = "Fragrance", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new ProductCategory { NameKey = "HomeFragrance",  CreatedById = _dbContext.Users.FirstOrDefault()!.Id },
                    new ProductCategory { NameKey = "Others", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                };
                await _dbContext.ProductCategories.AddRangeAsync(productCategories);

                List<TranslationEngb> translationEngbs = new()
                {
                    new TranslationEngb{Key="Devices", Value = "Devices", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="Fragrance", Value = "Fragrance", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="HomeFragrance", Value = "Home fragrance", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="Others", Value = "Others", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                };
                await _dbContext.TranslationEngbs.AddRangeAsync(translationEngbs);
                List<TranslationPlpl> translationPlpls = new()
                {
                    new TranslationPlpl{Key="Devices", Value = "Urządzenia", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="Fragrance", Value = "Perfumy", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="HomeFragrance", Value = "Zapachy do domu", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="Others", Value = "Inne", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                };
                await _dbContext.TranslationPlpls.AddRangeAsync(translationPlpls);
                await _dbContext.SaveChangesAsync();

                List<ProductCategory> productCategories2 = new()
                {
                    new ProductCategory
                    {
                        NameKey = "Diffusers",
                        ParentCategoryId = _dbContext.ProductCategories.Single(c=>c.NameKey.Equals("Devices")).Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                    new ProductCategory
                    {
                        NameKey = "Fresheners",
                        ParentCategoryId = _dbContext.ProductCategories.Single(c=>c.NameKey.Equals("Devices")).Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },

                    new ProductCategory
                    {
                        NameKey = "ScentedCandles",
                        ParentCategoryId = _dbContext.ProductCategories.Single(c=>c.NameKey.Equals("HomeFragrance")).Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                    new ProductCategory
                    {
                        NameKey = "EssentialOils",
                        ParentCategoryId = _dbContext.ProductCategories.Single(c => c.NameKey.Equals("HomeFragrance")).Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },

                    new ProductCategory
                    {
                        NameKey = "CarFresheners",
                        ParentCategoryId = _dbContext.ProductCategories.Single(c => c.NameKey.Equals("Others")).Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                };
                await _dbContext.ProductCategories.AddRangeAsync(productCategories2);

                List<TranslationEngb> translationEngbs2 = new()
                {
                    new TranslationEngb{Key="Diffusers", Value = "Diffusers", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="Fresheners", Value = "Fresheners", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="ScentedCandles", Value = "Scented candles", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="EssentialOils", Value = "Essential oils", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="CarFresheners", Value = "Car fresheners", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                };
                await _dbContext.TranslationEngbs.AddRangeAsync(translationEngbs2);
                List<TranslationPlpl> translationPlpls2 = new()
                {
                    new TranslationPlpl{Key="Diffusers", Value = "Dyfuzory", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="Fresheners", Value = "Odświeżacze", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="ScentedCandles", Value = "Świeczki zapachowe", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="EssentialOils", Value = "Olejki zapachowe", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="CarFresheners", Value = "Zapachy do samochodu", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                };
                await _dbContext.TranslationPlpls.AddRangeAsync(translationPlpls2);
            }
        }
    }
}
