using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Domain.Entities;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Seeders
{
    public class TranslationSeeder : ISeeder
    {
        private readonly SmellItDbContext _dbContext;

        public TranslationSeeder(SmellItDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (!_dbContext.Translations.Any())
            {
                List<Translation> data = new List<Translation>
                {
                    new Translation() { LanguageCode = "en-GB", Key = "Home", Value = "Home",CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new Translation() { LanguageCode = "pl-PL", Key = "Home", Value = "Strona główna",CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    
                    new Translation() { LanguageCode = "en-GB", Key = "Cart", Value = "Cart",CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new Translation() { LanguageCode = "pl-PL", Key = "Cart", Value = "Koszyk",CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                };
                await _dbContext.Translations.AddRangeAsync(data);
            }
        }
    }
}
