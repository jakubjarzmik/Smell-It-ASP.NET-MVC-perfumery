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
                List<ProductCategory> data = new List<ProductCategory>
                {
                    new ProductCategory { Name = "Devices", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new ProductCategory { Name = "Fragrance", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new ProductCategory { Name = "HomeFragrance",  CreatedById = _dbContext.Users.FirstOrDefault()!.Id },
                    new ProductCategory { Name = "Others", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                };
                await _dbContext.ProductCategories.AddRangeAsync(data);
                await _dbContext.SaveChangesAsync();
                List<ProductCategory> data2 = new List<ProductCategory>
                {
                    new ProductCategory
                    {
                        Name = "Diffusers", 
                        ParentCategoryId = _dbContext.ProductCategories.Where(c=>c.Name.Equals("Devices")).Single()!.Id, 
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                    new ProductCategory
                    {
                        Name = "Fresheners", 
                        ParentCategoryId = _dbContext.ProductCategories.Where(c=>c.Name.Equals("Devices")).Single()!.Id, 
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },

                    new ProductCategory
                    {
                        Name = "ScentedCandles", 
                        ParentCategoryId = _dbContext.ProductCategories.Where(c=>c.Name.Equals("HomeFragrance")).Single()!.Id, 
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                    new ProductCategory
                    {
                        Name = "EssentialOils", 
                        ParentCategoryId = _dbContext.ProductCategories.Where(c=>c.Name.Equals("HomeFragrance")).Single()!.Id, 
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },

                    new ProductCategory
                    {
                        Name = "CarFresheners", 
                        ParentCategoryId = _dbContext.ProductCategories.Where(c=>c.Name.Equals("Others")).Single()!.Id, 
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                };
                await _dbContext.ProductCategories.AddRangeAsync(data2);
            }
        }
    }
}
