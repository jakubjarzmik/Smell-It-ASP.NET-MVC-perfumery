using System.Globalization;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Admin.Models;
public class LanguageFromDbService
{
    private readonly SmellItDbContext _dbContext;

    public LanguageFromDbService(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public string GetValue(string key)
    {
        if(CultureInfo.CurrentCulture.Equals("pl-PL"))
            return _dbContext.TranslationPlpls.Where(t => t.Key.Equals("key")).Select(t=>t.Value).FirstOrDefault()!;
        else
            return _dbContext.TranslationEngbs.Where(t => t.Key.Equals("key")).Select(t=>t.Value).FirstOrDefault()!;
    }
}