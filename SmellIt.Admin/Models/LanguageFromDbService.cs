using System.Globalization;
using Microsoft.AspNetCore.Localization;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Admin.Models;
public class LanguageFromDbService
{
    private readonly SmellItDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public String CurrentCulture { get; set; }

    public LanguageFromDbService(SmellItDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
        CurrentCulture = CheckCulture();
    }

    public string GetValue(string key)
    {
        return "";
        //if (CurrentCulture.Equals("pl-PL"))
        //    return _dbContext.TranslationPlpls.Where(t => t.Key.Equals(key)).Select(t=>t.Value).FirstOrDefault()!;
        //return _dbContext.TranslationEngbs.Where(t => t.Key.Equals(key)).Select(t=>t.Value).FirstOrDefault()!;
    }

    private string CheckCulture()
    {
        var requestCultureFeature = _httpContextAccessor.HttpContext?.Features.Get<IRequestCultureFeature>();
        return requestCultureFeature?.RequestCulture?.Culture.ToString() ?? new CultureInfo("pl-PL").ToString();
    }
}