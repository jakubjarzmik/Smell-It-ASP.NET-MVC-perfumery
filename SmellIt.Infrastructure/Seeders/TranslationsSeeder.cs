using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Domain.Entities;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Seeders
{
    public class TranslationsSeeder : ISeeder
    {
        private readonly SmellItDbContext _dbContext;

        public TranslationsSeeder(SmellItDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (!_dbContext.TranslationEngbs.Any())
            {
                List<TranslationEngb> translationEngbs = new()
                {
                    
                };
                await _dbContext.TranslationEngbs.AddRangeAsync(translationEngbs);
            }

            if (!_dbContext.TranslationPlpls.Any())
            {
                List<TranslationPlpl> translationPlpls = new()
                {
                    
                };
                await _dbContext.TranslationPlpls.AddRangeAsync(translationPlpls);
            }
        }
    }
}
