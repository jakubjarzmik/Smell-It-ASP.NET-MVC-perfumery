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
                    new TranslationEngb{Key="Aromatic", Value = "Aromatic", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="Citrus", Value = "Citrus", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="Floral", Value = "Floral", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="Fruity", Value = "Fruity", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="Oriental", Value = "Oriental", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="Other", Value = "Other", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="Spicy", Value = "Spicy", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                };
                await _dbContext.TranslationEngbs.AddRangeAsync(translationEngbs);
                List<TranslationPlpl> translations = new List<TranslationPlpl>()
                {
                    new TranslationPlpl{Key="Aromatic", Value = "Aromatyczne", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="Citrus", Value = "Cytrusowe", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="Floral", Value = "Kwiatowe", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="Fruity", Value = "Owocowe", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="Oriental", Value = "Orientalne", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="Other", Value = "Inne", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="Spicy", Value = "Ostre", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                };
                await _dbContext.TranslationPlpls.AddRangeAsync(translations);
            }
        }
    }
}
