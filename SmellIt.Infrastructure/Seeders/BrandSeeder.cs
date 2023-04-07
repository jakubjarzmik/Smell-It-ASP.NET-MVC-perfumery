using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Domain.Entities;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Seeders
{
    public class BrandSeeder : ISeeder
    {
        private readonly SmellItDbContext _dbContext;

        public BrandSeeder(SmellItDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (!_dbContext.Brands.Any())
            {
                List<Brand> data = new List<Brand>
                {
                    new Brand { Name = "Smell It", Description = "SmellItDesc", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new Brand { Name = "Carolina Herrera", Description = "CarolinaHerreraDesc", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new Brand { Name = "Dior", Description = "DiorDesc", CreatedById = _dbContext.Users.FirstOrDefault()!.Id },
                    new Brand { Name = "Giorgio Armani", Description = "GiorgioArmaniDesc", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new Brand { Name = "Paco Rabanne", Description = "PacoRabanneDesc", CreatedById = _dbContext.Users.FirstOrDefault() !.Id },
                    new Brand { Name = "Versace", Description = "VersaceDesc", CreatedById = _dbContext.Users.FirstOrDefault() !.Id },
                    new Brand { Name = "Yves Saint Laurent", Description = "YvesSaintLaurentDesc", CreatedById = _dbContext.Users.FirstOrDefault() !.Id }
                };
                await _dbContext.Brands.AddRangeAsync(data);
            }
        }
    }
}
