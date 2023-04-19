using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Website.Models;
public class LanguageFromDbService
{
    private readonly SmellItDbContext _dbContext;

    public LanguageFromDbService(SmellItDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public string GetValue(string key)
    {
        return "";
        //if(CultureInfo.CurrentCulture.ToString().Equals("pl-PL"))
        //    return _dbContext.TranslationPlpls.Where(t => t.Key.Equals("key")).Select(t=>t.Value).FirstOrDefault()!;
        //else
        //    return _dbContext.TranslationEngbs.Where(t => t.Key.Equals("key")).Select(t=>t.Value).FirstOrDefault()!;
    }
}