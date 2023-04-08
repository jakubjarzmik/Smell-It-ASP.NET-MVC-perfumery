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
                List<ProductCategory> productCategories = new List<ProductCategory>
                {
                    new ProductCategory { NameKey = "Devices", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new ProductCategory { NameKey = "Fragrance", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new ProductCategory { NameKey = "HomeFragrance",  CreatedById = _dbContext.Users.FirstOrDefault()!.Id },
                    new ProductCategory { NameKey = "Others", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                };
                await _dbContext.ProductCategories.AddRangeAsync(productCategories);

                List<TranslationEngb> translationEngbs = new List<TranslationEngb>()
                {
                    new TranslationEngb{Key="Devices", Value = "Devices"},
                    new TranslationEngb{Key="Fragrance", Value = "Fragrance"},
                    new TranslationEngb{Key="HomeFragrance", Value = "Home fragrance"},
                    new TranslationEngb{Key="Others", Value = "Others"},
                };
                await _dbContext.TranslationEngbs.AddRangeAsync(translationEngbs);
                List<TranslationPlpl> translationPlpls = new List<TranslationPlpl>()
                {
                    new TranslationPlpl{Key="Devices", Value = "Urządzenia"},
                    new TranslationPlpl{Key="Fragrance", Value = "Perfumy"},
                    new TranslationPlpl{Key="HomeFragrance", Value = "Zapachy do domu"},
                    new TranslationPlpl{Key="Others", Value = "Inne"},
                };
                await _dbContext.TranslationPlpls.AddRangeAsync(translationPlpls);
                await _dbContext.SaveChangesAsync();

                List<ProductCategory> productCategories2 = new List<ProductCategory>
                {
                    new ProductCategory
                    {
                        NameKey = "Diffusers", 
                        ParentCategoryId = _dbContext.ProductCategories.Where(c=>c.NameKey.Equals("Devices")).Single()!.Id, 
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                    new ProductCategory
                    {
                        NameKey = "Fresheners", 
                        ParentCategoryId = _dbContext.ProductCategories.Where(c=>c.NameKey.Equals("Devices")).Single()!.Id, 
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },

                    new ProductCategory
                    {
                        NameKey = "ScentedCandles", 
                        ParentCategoryId = _dbContext.ProductCategories.Where(c=>c.NameKey.Equals("HomeFragrance")).Single()!.Id, 
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                    new ProductCategory
                    {
                        NameKey = "EssentialOils", 
                        ParentCategoryId = _dbContext.ProductCategories.Where(c=>c.NameKey.Equals("HomeFragrance")).Single()!.Id, 
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },

                    new ProductCategory
                    {
                        NameKey = "CarFresheners", 
                        ParentCategoryId = _dbContext.ProductCategories.Where(c=>c.NameKey.Equals("Others")).Single()!.Id, 
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                };
                await _dbContext.ProductCategories.AddRangeAsync(productCategories2);

                List<TranslationEngb> translationEngbs2 = new List<TranslationEngb>()
                {
                    new TranslationEngb{Key="Diffusers", Value = "Diffusers"},
                    new TranslationEngb{Key="Fresheners", Value = "Fresheners"},
                    new TranslationEngb{Key="ScentedCandles", Value = "Scented candles"},
                    new TranslationEngb{Key="EssentialOils", Value = "Essential oils"},
                    new TranslationEngb{Key="CarFresheners", Value = "Car fresheners"},
                };
                await _dbContext.TranslationEngbs.AddRangeAsync(translationEngbs2);
                List<TranslationPlpl> translationPlpls2 = new List<TranslationPlpl>()
                {
                    new TranslationPlpl{Key="Diffusers", Value = "Dyfuzory"},
                    new TranslationPlpl{Key="Fresheners", Value = "Odświeżacze"},
                    new TranslationPlpl{Key="ScentedCandles", Value = "Świeczki zapachowe"},
                    new TranslationPlpl{Key="EssentialOils", Value = "Olejki zapachowe"},
                    new TranslationPlpl{Key="CarFresheners", Value = "Zapachy do samochodu"},
                };
                await _dbContext.TranslationPlpls.AddRangeAsync(translationPlpls2);
            }
        }
    }
}
