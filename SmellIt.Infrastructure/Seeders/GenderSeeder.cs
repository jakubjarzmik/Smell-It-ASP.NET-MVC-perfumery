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
                List<Gender> genders = new()
                {
                    new Gender { NameKey = "Women", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new Gender { NameKey = "Men", CreatedById = _dbContext.Users.FirstOrDefault()!.Id },
                    new Gender { NameKey = "Unisex", CreatedById = _dbContext.Users.FirstOrDefault() !.Id }
                };
                await _dbContext.Genders.AddRangeAsync(genders);
                List<TranslationEngb> translationEngbs = new()
                {
                    new TranslationEngb{Key="Women", Value = "Women", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="Men", Value = "Men", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="Unisex", Value = "Unisex", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                };
                await _dbContext.TranslationEngbs.AddRangeAsync(translationEngbs);
                List<TranslationPlpl> translationPlpls = new()
                {
                    new TranslationPlpl{Key="Women", Value = "Damskie", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="Men", Value = "Męskie", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="Unisex", Value = "Unisex", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                };
                await _dbContext.TranslationPlpls.AddRangeAsync(translationPlpls);
            }
        }
    }
}
