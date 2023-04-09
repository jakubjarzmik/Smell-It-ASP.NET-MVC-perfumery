using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Domain.Entities;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Seeders
{
    public class FragranceCategorySeeder : ISeeder
    {
        private readonly SmellItDbContext _dbContext;

        public FragranceCategorySeeder(SmellItDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (!_dbContext.FragranceCategories.Any())
            {
                List<FragranceCategory> fragranceGroups = new List<FragranceCategory>
                {
                    new FragranceCategory { NameKey = "Aromatic", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new FragranceCategory { NameKey = "Citrus", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new FragranceCategory { NameKey = "Floral",  CreatedById = _dbContext.Users.FirstOrDefault()!.Id },
                    new FragranceCategory { NameKey = "Fruity", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new FragranceCategory { NameKey = "Oriental", CreatedById = _dbContext.Users.FirstOrDefault() !.Id },
                    new FragranceCategory { NameKey = "Other", CreatedById = _dbContext.Users.FirstOrDefault() !.Id },
                    new FragranceCategory { NameKey = "Spicy", CreatedById = _dbContext.Users.FirstOrDefault() !.Id }
                };
                await _dbContext.FragranceCategories.AddRangeAsync(fragranceGroups);
                List<TranslationEngb> translationEngbs = new List<TranslationEngb>()
                {
                    new TranslationEngb{Key="Aromatic", Value = "Aromatic"},
                    new TranslationEngb{Key="Citrus", Value = "Citrus"},
                    new TranslationEngb{Key="Floral", Value = "Floral"},
                    new TranslationEngb{Key="Fruity", Value = "Fruity"},
                    new TranslationEngb{Key="Oriental", Value = "Oriental"},
                    new TranslationEngb{Key="Other", Value = "Other"},
                    new TranslationEngb{Key="Spicy", Value = "Spicy"},
                };
                await _dbContext.TranslationEngbs.AddRangeAsync(translationEngbs);
                List<TranslationPlpl> translations = new List<TranslationPlpl>()
                {
                    new TranslationPlpl{Key="Aromatic", Value = "Aromatyczne"},
                    new TranslationPlpl{Key="Citrus", Value = "Cytrusowe"},
                    new TranslationPlpl{Key="Floral", Value = "Kwiatowe"},
                    new TranslationPlpl{Key="Fruity", Value = "Owocowe"},
                    new TranslationPlpl{Key="Oriental", Value = "Orientalne"},
                    new TranslationPlpl{Key="Other", Value = "Inne"},
                    new TranslationPlpl{Key="Spicy", Value = "Ostre"},
                };
                await _dbContext.TranslationPlpls.AddRangeAsync(translations);
            }
        }
    }
}
