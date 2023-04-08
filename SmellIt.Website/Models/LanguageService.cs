using System.Reflection;
using Microsoft.Extensions.Localization;

namespace SmellIt.Website.Models
{
    public class LanguageService
    {
        private readonly IStringLocalizer _localizer;

        public LanguageService( IStringLocalizerFactory factory)
        {
            var type = typeof(Resources);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName!);
            _localizer = factory.Create("Resources", assemblyName.Name!);
        }

        public LocalizedString GetValue(string key)
        {
            return _localizer[key];
        }
    }
}
