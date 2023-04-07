using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Domain.Entities;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Seeders
{
    public class FragranceGroupSeeder : ISeeder
    {
        private readonly SmellItDbContext _dbContext;

        public FragranceGroupSeeder(SmellItDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (!_dbContext.FragranceGroups.Any())
            {
                List<FragranceGroup> data = new List<FragranceGroup>
                {
                    new FragranceGroup { Name = "Aromatic", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new FragranceGroup { Name = "Citrus", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new FragranceGroup { Name = "Floral",  CreatedById = _dbContext.Users.FirstOrDefault()!.Id },
                    new FragranceGroup { Name = "Fruity", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new FragranceGroup { Name = "Oriental", CreatedById = _dbContext.Users.FirstOrDefault() !.Id },
                    new FragranceGroup { Name = "Other", CreatedById = _dbContext.Users.FirstOrDefault() !.Id },
                    new FragranceGroup { Name = "Spicy", CreatedById = _dbContext.Users.FirstOrDefault() !.Id }
                };
                await _dbContext.FragranceGroups.AddRangeAsync(data);
            }
        }
    }
}
