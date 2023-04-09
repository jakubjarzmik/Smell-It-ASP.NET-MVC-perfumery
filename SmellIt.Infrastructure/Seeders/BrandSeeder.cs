using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Domain.Entities;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Seeders
{
    public class BrandSeeder : ISeeder
    {
        private readonly SmellItDbContext _dbContext;

        public BrandSeeder(SmellItDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (!_dbContext.Brands.Any())
            {
                List<Brand> brands = new List<Brand>
                {
                    new Brand { NameKey = "SmellIt", DescriptionKey = "SmellItDesc", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new Brand { NameKey = "CarolinaHerrera", DescriptionKey = "CarolinaHerreraDesc", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new Brand { NameKey = "Dior", DescriptionKey = "DiorDesc", CreatedById = _dbContext.Users.FirstOrDefault()!.Id },
                    new Brand { NameKey = "GiorgioArmani", DescriptionKey = "GiorgioArmaniDesc", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new Brand { NameKey = "PacoRabanne", DescriptionKey = "PacoRabanneDesc", CreatedById = _dbContext.Users.FirstOrDefault() !.Id },
                    new Brand { NameKey = "Versace", DescriptionKey = "VersaceDesc", CreatedById = _dbContext.Users.FirstOrDefault() !.Id },
                    new Brand { NameKey = "YvesSaintLaurent", DescriptionKey = "YvesSaintLaurentDesc", CreatedById = _dbContext.Users.FirstOrDefault() !.Id }
                };
                await _dbContext.Brands.AddRangeAsync(brands);
                List<TranslationEngb> translationEngbs = new List<TranslationEngb>()
                {
                    new TranslationEngb{Key="SmellIt", Value = "Smell It"},
                    new TranslationEngb{Key="CarolinaHerrera", Value = "Carolina Herrera"},
                    new TranslationEngb{Key="Dior", Value = "Dior"},
                    new TranslationEngb{Key="GiorgioArmani", Value = "Giorgio Armani"},
                    new TranslationEngb{Key="PacoRabanne", Value = "Paco Rabanne"},
                    new TranslationEngb{Key="Versace", Value = "Versace"},
                    new TranslationEngb{Key="YvesSaintLaurent", Value = "Yves Saint Laurent"},

                    new TranslationEngb{Key="SmellItDesc", Value = "Innovative company, which became famous for releasing the product Smell It Diffuser on the market, capable of imitating scents, you just need to connect this device to a computer or smartphone, have the fragrances refilled in the device, and choose the scent you want to experience."},
                    new TranslationEngb{Key="CarolinaHerreraDesc", Value = "Carolina Herrera perfumes are a line of luxury fragrances for women and men. The company offers many different compositions that are valued for their originality, elegance, and longevity. Among the most popular scents of the brand are \"Good Girl,\" \"212,\" \"CH,\" \"Bad Boy,\" and \"Very Good Girl.\" Each fragrance is carefully developed and composed using the highest quality ingredients, making it unique and unparalleled. Carolina Herrera perfumes are highly recognizable thanks to their distinctive shoe or capsule-shaped bottles."},
                    new TranslationEngb{Key="DiorDesc", Value = "Dior is a luxury perfume brand that offers many different fragrances for women and men. Among the most popular scents are \"J'adore\", \"Miss Dior\", \"Sauvage\", \"Poison\", \"Hypnotic Poison\", and \"Fahrenheit\". Dior perfumes stand out for their elegant and sensual fragrance compositions that contain the highest quality ingredients. The fragrance bottles are usually simple, elegant, and modern, reflecting French style and classicism. Dior fragrances are valued for their uniqueness, quality, and longevity."},
                    new TranslationEngb{Key="GiorgioArmaniDesc", Value = "Giorgio Armani is a brand that offers luxury perfumes for women and men. The brand offers many different scents that are valued for their quality, elegance, and originality. Among the most popular scents of the brand are \"Acqua di Gio,\" \"Armani Code,\" \"Si,\" \"Emporio Armani Stronger With You,\" and \"Armani Privé Rose d'Arabie.\" Giorgio Armani perfumes are composed of the highest quality ingredients, making the scents long-lasting and intense. The perfume bottles are usually simple, elegant, and fashionable, reflecting the brand's characteristic minimalism."},
                    new TranslationEngb{Key="PacoRabanneDesc", Value = "Paco Rabanne is a luxury perfume brand for women and men that offers many different fragrances. The most popular scents of the brand are \"1 Million,\" \"Lady Million,\" \"Invictus,\" and \"Olympéa.\" Paco Rabanne perfumes stand out with sensual and intriguing compositions that are composed of the highest quality ingredients. The perfume bottles are often avant-garde, modern, and original, reflecting the brand's characteristic style. Paco Rabanne perfumes are valued for their uniqueness, quality, and longevity."},
                    new TranslationEngb{Key="VersaceDesc", Value = "Versace is a luxury perfume brand for women and men that offers many different fragrances. Among the most popular scents of the brand are \"Bright Crystal,\" \"Eros,\" \"Dylan Blue,\" \"Versace Pour Homme,\" \"Yellow Diamond,\" and \"Versace Man Eau Fraîche.\" Versace perfumes stand out with sensual and extremely intense compositions that are composed of the highest quality ingredients. The perfume bottles are often adorned with characteristic patterns, reflecting the brand's style and aesthetics. Versace perfumes are valued for their uniqueness, quality, and longevity."},
                    new TranslationEngb{Key="YvesSaintLaurentDesc", Value = "Yves Saint Laurent is a luxury perfume brand for women and men that offers many different fragrances. Among the most popular scents of the brand are \"Opium,\" \"Black Opium,\" \"Y,\" \"L'Homme,\" \"La Nuit de L'Homme,\" and \"Mon Paris.\" Yves Saint Laurent perfumes stand out with elegant and sensual compositions that are composed of the highest quality ingredients. The perfume bottles are often simple, elegant, and modern, reflecting French style and classicism. Yves Saint Laurent perfumes are valued for their uniqueness, quality, and longevity."},
                };
                await _dbContext.TranslationEngbs.AddRangeAsync(translationEngbs);
                List<TranslationPlpl> translationPlpls = new List<TranslationPlpl>()
                {
                    new TranslationPlpl{Key="SmellIt", Value = "Smell It"},
                    new TranslationPlpl{Key="CarolinaHerrera", Value = "Carolina Herrera"},
                    new TranslationPlpl{Key="Dior", Value = "Dior"},
                    new TranslationPlpl{Key="GiorgioArmani", Value = "Giorgio Armani"},
                    new TranslationPlpl{Key="PacoRabanne", Value = "Paco Rabanne"},
                    new TranslationPlpl{Key="Versace", Value = "Versace"},
                    new TranslationPlpl{Key="YvesSaintLaurent", Value = "Yves Saint Laurent"},

                    new TranslationPlpl{Key="SmellItDesc", Value = "Nowatorska firma, która zasłynęła z wypuszczenia na rynek produktu Smell It Diffuser, który potrafi imitować zapachy, wystarczy tylko połączyć to urządzenie z komputerem lub smartfonem, mieć uzupełnione aromaty w urządzeniu i wybrać zapach, który chce się poczuć"},
                    new TranslationPlpl{Key="CarolinaHerreraDesc", Value = "Perfumy Carolina Herrera to linia luksusowych zapachów dla kobiet i mężczyzn. Firma oferuje wiele różnych kompozycji, które są cenione za swoją oryginalność, elegancję i trwałość. Wśród najpopularniejszych zapachów marki znajdują się: \"Good Girl\", \"212\", \"CH\", \"Bad Boy\" oraz \"Very Good Girl\". Każdy zapach jest starannie opracowany i skomponowany z wykorzystaniem najwyższej jakości składników, co czyni go unikalnym i niepowtarzalnym. Carolina Herrera zapachy są bardzo rozpoznawalne dzięki swoim charakterystycznym flakonom w kształcie butów lub kapsli."},
                    new TranslationPlpl{Key="DiorDesc", Value = "Dior to luksusowa marka perfum, która oferuje wiele różnych zapachów dla kobiet i mężczyzn. Wśród najpopularniejszych zapachów marki są \"J'adore\", \"Miss Dior\", \"Sauvage\", \"Poison\", \"Hypnotic Poison\" i \"Fahrenheit\". Perfumy Dior wyróżniają się eleganckimi i zmysłowymi kompozycjami zapachowymi, które zawierają najwyższej jakości składniki. Flakony zapachów są zwykle proste, eleganckie i nowoczesne, odzwierciedlając francuski styl i klasykę. Zapachy Dior są cenione za swoją wyjątkowość, jakość i trwałość."},
                    new TranslationPlpl{Key="GiorgioArmaniDesc", Value = "Giorgio Armani to marka, która oferuje luksusowe perfumy dla kobiet i mężczyzn. W ofercie znajduje się wiele różnych zapachów, które są cenione za swoją jakość, elegancję i oryginalność. Wśród najpopularniejszych zapachów marki znajdują się: \"Acqua di Gio\", \"Armani Code\", \"Si\", \"Emporio Armani Stronger With You\", oraz \"Armani Privé Rose d'Arabie\". Perfumy Giorgio Armani są skomponowane z najwyższej jakości składników, dzięki czemu zapachy są trwałe i intensywne. Flakony perfum są zwykle proste, eleganckie i modne, nawiązujące do charakterystycznego minimalizmu marki."},
                    new TranslationPlpl{Key="PacoRabanneDesc", Value = "Paco Rabanne to marka luksusowych perfum dla kobiet i mężczyzn, która oferuje wiele różnych zapachów. Najbardziej popularnymi zapachami marki są \"1 Million\", \"Lady Million\", \"Invictus\" i \"Olympéa\". Perfumy Paco Rabanne wyróżniają się zmysłowymi i intrygującymi kompozycjami, które są skomponowane z najwyższej jakości składników. Flakony perfum są często awangardowe, nowoczesne i oryginalne, nawiązujące do charakterystycznego stylu marki. Perfumy Paco Rabanne są cenione za swoją wyjątkowość, jakość i trwałość."},
                    new TranslationPlpl{Key="VersaceDesc", Value = "Versace to marka luksusowych perfum dla kobiet i mężczyzn, która oferuje wiele różnych zapachów. Wśród najbardziej popularnych zapachów marki znajdują się \"Bright Crystal\", \"Eros\", \"Dylan Blue\", \"Versace Pour Homme\", \"Yellow Diamond\" i \"Versace Man Eau Fraîche\". Perfumy Versace wyróżniają się zmysłowymi i niezwykle intensywnymi kompozycjami, które są skomponowane z najwyższej jakości składników. Flakony perfum są często ozdobione charakterystycznymi wzorami, nawiązującymi do stylu i estetyki marki. Perfumy Versace są cenione za swoją wyjątkowość, jakość i trwałość."},
                    new TranslationPlpl{Key="YvesSaintLaurentDesc", Value = "Yves Saint Laurent to marka luksusowych perfum dla kobiet i mężczyzn, która oferuje wiele różnych zapachów. Wśród najbardziej popularnych zapachów marki znajdują się \"Opium\", \"Black Opium\", \"Y\", \"L'Homme\", \"La Nuit de L'Homme\" i \"Mon Paris\". Perfumy Yves Saint Laurent wyróżniają się eleganckimi i zmysłowymi kompozycjami, które są skomponowane z najwyższej jakości składników. Flakony perfum są często proste, eleganckie i nowoczesne, nawiązujące do francuskiego stylu i klasyki. Perfumy Yves Saint Laurent są cenione za swoją wyjątkowość, jakość i trwałość."},
                };
                await _dbContext.TranslationPlpls.AddRangeAsync(translationPlpls);
            }
        }
    }
}
