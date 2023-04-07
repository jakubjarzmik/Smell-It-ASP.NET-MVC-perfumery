using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Domain.Entities;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Seeders
{
    public class GenderSeeder : ISeeder
    {
        private readonly SmellItDbContext _dbContext;

        public GenderSeeder(SmellItDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (!_dbContext.Genders.Any())
            {
                List<Gender> data = new List<Gender>
                {
                    new Gender { Name = "Women", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new Gender { Name = "Men", CreatedById = _dbContext.Users.FirstOrDefault()!.Id },
                    new Gender { Name = "Unisex", CreatedById = _dbContext.Users.FirstOrDefault() !.Id }
                };
                await _dbContext.Genders.AddRangeAsync(data);
            }
        }
    }
}
