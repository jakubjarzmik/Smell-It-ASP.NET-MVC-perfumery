using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Seeders
{
    public class ProductSeeder : ISeeder
    {
        private readonly SmellItDbContext _dbContext;

        public ProductSeeder(SmellItDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (!_dbContext.Products.Any())
            {
                var polish = new Language { Code = "pl-PL", Name = "Polski" };
                var english = new Language { Code = "en-GB", Name = "English (GB)" };
                polish.EncodeName();
                english.EncodeName();
                await _dbContext.Languages.AddAsync(polish);
                await _dbContext.Languages.AddAsync(english);
                await _dbContext.SaveChangesAsync();

                #region ProductCategories

                var devices = new ProductCategory();
                _dbContext.ProductCategories.Add(devices);

                var devicesTranslations = new[]
                {
                    new ProductCategoryTranslation { ProductCategory = devices, Language = polish, Name = "Urządzenia" },
                    new ProductCategoryTranslation { ProductCategory = devices, Language = english, Name = "Devices" },
                };
                foreach (var devicesTranslation in devicesTranslations)
                {
                    devicesTranslation.EncodeName();
                }
                devices.ProductCategoryTranslations = devicesTranslations;
                devices.EncodeName();
                await _dbContext.ProductCategoryTranslations.AddRangeAsync(devicesTranslations);


                var fragrance = new ProductCategory();
                _dbContext.ProductCategories.Add(fragrance);

                var fragranceTranslations = new[]
                {
                    new ProductCategoryTranslation { ProductCategory = fragrance, Language = polish, Name = "Perfumy" },
                    new ProductCategoryTranslation { ProductCategory = fragrance, Language = english, Name = "Fragrance" },
                };
                foreach (var fragranceTranslation in fragranceTranslations)
                {
                    fragranceTranslation.EncodeName();
                }

                fragrance.ProductCategoryTranslations = fragranceTranslations;
                fragrance.EncodeName();
                await _dbContext.ProductCategoryTranslations.AddRangeAsync(fragranceTranslations);


                var homeFragrance = new ProductCategory();
                _dbContext.ProductCategories.Add(homeFragrance);

                var homeFragranceTranslations = new[]
                {
                    new ProductCategoryTranslation { ProductCategory = homeFragrance, Language = polish, Name = "Zapachy do domu" },
                    new ProductCategoryTranslation { ProductCategory = homeFragrance, Language = english, Name = "Home fragrances" },
                };
                foreach (var homeFragranceTranslation in homeFragranceTranslations)
                {
                    homeFragranceTranslation.EncodeName();
                }
                homeFragrance.ProductCategoryTranslations = homeFragranceTranslations;
                homeFragrance.EncodeName();
                await _dbContext.ProductCategoryTranslations.AddRangeAsync(homeFragranceTranslations);


                var others = new ProductCategory();
                _dbContext.ProductCategories.Add(others);

                var othersTranslations = new[]
                {
                    new ProductCategoryTranslation { ProductCategory = others, Language = polish, Name = "Inne" },
                    new ProductCategoryTranslation { ProductCategory = others, Language = english, Name = "Others" },
                };
                foreach (var othersTranslation in othersTranslations)
                {
                    othersTranslation.EncodeName();
                }
                others.ProductCategoryTranslations = othersTranslations;
                others.EncodeName();
                await _dbContext.ProductCategoryTranslations.AddRangeAsync(othersTranslations);


                var diffusers = new ProductCategory { ParentCategory = devices };
                _dbContext.ProductCategories.Add(diffusers);

                var diffusersTranslations = new[]
                {
                    new ProductCategoryTranslation { ProductCategory = diffusers, Language = polish, Name = "Dyfuzory" },
                    new ProductCategoryTranslation { ProductCategory = diffusers, Language = english, Name = "Diffusers" },
                };
                foreach (var diffusersTranslation in diffusersTranslations)
                {
                    diffusersTranslation.EncodeName();
                }
                diffusers.ProductCategoryTranslations = diffusersTranslations;
                diffusers.EncodeName();
                await _dbContext.ProductCategoryTranslations.AddRangeAsync(diffusersTranslations);


                var fresheners = new ProductCategory { ParentCategory = devices };
                _dbContext.ProductCategories.Add(fresheners);

                var freshenersTranslations = new[]
                {
                    new ProductCategoryTranslation { ProductCategory = fresheners, Language = polish, Name = "Odświeżacze powietrza" },
                    new ProductCategoryTranslation { ProductCategory = fresheners, Language = english, Name = "Fresheners" },
                };
                foreach (var freshenersTranslation in freshenersTranslations)
                {
                    freshenersTranslation.EncodeName();
                }
                fresheners.ProductCategoryTranslations = freshenersTranslations;
                fresheners.EncodeName();
                await _dbContext.ProductCategoryTranslations.AddRangeAsync(freshenersTranslations);


                var scentedCandles = new ProductCategory { ParentCategory = homeFragrance };
                _dbContext.ProductCategories.Add(scentedCandles);

                var scentedCandlesTranslations = new[]
                {
                    new ProductCategoryTranslation { ProductCategory = scentedCandles, Language = polish, Name = "Świeczki zapachowe" },
                    new ProductCategoryTranslation { ProductCategory = scentedCandles, Language = english, Name = "Scented candles" },
                };
                foreach (var scentedCandlesTranslation in scentedCandlesTranslations)
                {
                    scentedCandlesTranslation.EncodeName();
                }
                scentedCandles.ProductCategoryTranslations = scentedCandlesTranslations;
                scentedCandles.EncodeName();
                await _dbContext.ProductCategoryTranslations.AddRangeAsync(scentedCandlesTranslations);


                var essentialOils = new ProductCategory { ParentCategory = homeFragrance };
                _dbContext.ProductCategories.Add(essentialOils);

                var essentialOilsTranslations = new[]
                {
                    new ProductCategoryTranslation { ProductCategory = essentialOils, Language = polish, Name = "Olejki zapachowe" },
                    new ProductCategoryTranslation { ProductCategory = essentialOils, Language = english, Name = "Essential oils" },
                };
                foreach (var essentialOilsTranslation in essentialOilsTranslations)
                {
                    essentialOilsTranslation.EncodeName();
                }
                essentialOils.ProductCategoryTranslations = essentialOilsTranslations;
                essentialOils.EncodeName();
                await _dbContext.ProductCategoryTranslations.AddRangeAsync(essentialOilsTranslations);


                var carFresheners = new ProductCategory { ParentCategory = others };
                _dbContext.ProductCategories.Add(carFresheners);

                var carFreshenersTranslations = new[]
                {
                    new ProductCategoryTranslation { ProductCategory = carFresheners, Language = polish, Name = "Odświeżacze do samochodu" },
                    new ProductCategoryTranslation { ProductCategory = carFresheners, Language = english, Name = "Car fresheners" },
                };
                foreach (var carFreshenersTranslation in carFreshenersTranslations)
                {
                    carFreshenersTranslation.EncodeName();
                }
                carFresheners.ProductCategoryTranslations = carFreshenersTranslations;
                carFresheners.EncodeName();
                await _dbContext.ProductCategoryTranslations.AddRangeAsync(carFreshenersTranslations);

                #endregion

                #region Brands

                var smellIt = new Brand { Name = "Smell it" };
                smellIt.EncodeName();
                _dbContext.Brands.Add(smellIt);

                var smellItTranslations = new[]
                {
                    new BrandTranslation { Brand = smellIt, Language = polish, Description = "Nowatorska firma, która zasłynęła z wypuszczenia na rynek produktu Smell It Diffuser, który potrafi imitować zapachy, wystarczy tylko połączyć to urządzenie z komputerem lub smartfonem, mieć uzupełnione aromaty w urządzeniu i wybrać zapach, który chce się poczuć." },
                    new BrandTranslation { Brand = smellIt, Language = english, Description = "Innovative company, which became famous for releasing the product Smell It Diffuser on the market, capable of imitating scents, you just need to connect this device to a computer or smartphone, have the fragrances refilled in the device, and choose the scent you want to experience." },
                };
                foreach (var smellItTranslation in smellItTranslations)
                {
                    smellItTranslation.EncodeName();
                }
                await _dbContext.BrandTranslations.AddRangeAsync(smellItTranslations);


                var carolinaHerrera = new Brand { Name = "Carolina Herrera" };
                carolinaHerrera.EncodeName();
                _dbContext.Brands.Add(carolinaHerrera);

                var carolinaHerreraTranslations = new[]
                {
                    new BrandTranslation { Brand = carolinaHerrera, Language = polish, Description = "Perfumy Carolina Herrera to linia luksusowych zapachów dla kobiet i mężczyzn. Firma oferuje wiele różnych kompozycji, które są cenione za swoją oryginalność, elegancję i trwałość. Wśród najpopularniejszych zapachów marki znajdują się: \"Good Girl\", \"212\", \"CH\", \"Bad Boy\" oraz \"Very Good Girl\". Każdy zapach jest starannie opracowany i skomponowany z wykorzystaniem najwyższej jakości składników, co czyni go unikalnym i niepowtarzalnym. Carolina Herrera zapachy są bardzo rozpoznawalne dzięki swoim charakterystycznym flakonom w kształcie butów lub kapsli." },
                    new BrandTranslation { Brand = carolinaHerrera, Language = english, Description = "Carolina Herrera perfumes are a line of luxury fragrances for women and men. The company offers many different compositions that are valued for their originality, elegance, and longevity. Among the most popular scents of the brand are \"Good Girl,\" \"212,\" \"CH,\" \"Bad Boy,\" and \"Very Good Girl.\" Each fragrance is carefully developed and composed using the highest quality ingredients, making it unique and unparalleled. Carolina Herrera perfumes are highly recognizable thanks to their distinctive shoe or capsule-shaped bottles." },
                };
                foreach (var carolinaHerreraTranslation in carolinaHerreraTranslations)
                {
                    carolinaHerreraTranslation.EncodeName();
                }
                await _dbContext.BrandTranslations.AddRangeAsync(carolinaHerreraTranslations);


                var dior = new Brand { Name = "Dior" };
                dior.EncodeName();
                _dbContext.Brands.Add(dior);

                var diorTranslations = new[]
                {
                    new BrandTranslation { Brand = dior, Language = polish, Description = "Dior to luksusowa marka perfum, która oferuje wiele różnych zapachów dla kobiet i mężczyzn. Wśród najpopularniejszych zapachów marki są \"J'adore\", \"Miss Dior\", \"Sauvage\", \"Poison\", \"Hypnotic Poison\" i \"Fahrenheit\". Perfumy Dior wyróżniają się eleganckimi i zmysłowymi kompozycjami zapachowymi, które zawierają najwyższej jakości składniki. Flakony zapachów są zwykle proste, eleganckie i nowoczesne, odzwierciedlając francuski styl i klasykę. Zapachy Dior są cenione za swoją wyjątkowość, jakość i trwałość." },
                    new BrandTranslation { Brand = dior, Language = english, Description = "Dior is a luxury perfume brand that offers many different fragrances for women and men. Among the most popular scents are \"J'adore\", \"Miss Dior\", \"Sauvage\", \"Poison\", \"Hypnotic Poison\", and \"Fahrenheit\". Dior perfumes stand out for their elegant and sensual fragrance compositions that contain the highest quality ingredients. The fragrance bottles are usually simple, elegant, and modern, reflecting French style and classicism. Dior fragrances are valued for their uniqueness, quality, and longevity." },
                };
                foreach (var diorTranslation in diorTranslations)
                {
                    diorTranslation.EncodeName();
                }
                await _dbContext.BrandTranslations.AddRangeAsync(diorTranslations);


                var giorgioArmani = new Brand { Name = "Giorgio Armani" };
                giorgioArmani.EncodeName();
                _dbContext.Brands.Add(giorgioArmani);

                var giorgioArmaniTranslations = new[]
                {
                    new BrandTranslation { Brand = giorgioArmani, Language = polish, Description = "Giorgio Armani to marka, która oferuje luksusowe perfumy dla kobiet i mężczyzn. W ofercie znajduje się wiele różnych zapachów, które są cenione za swoją jakość, elegancję i oryginalność. Wśród najpopularniejszych zapachów marki znajdują się: \"Acqua di Gio\", \"Armani Code\", \"Si\", \"Emporio Armani Stronger With You\", oraz \"Armani Privé Rose d'Arabie\". Perfumy Giorgio Armani są skomponowane z najwyższej jakości składników, dzięki czemu zapachy są trwałe i intensywne. Flakony perfum są zwykle proste, eleganckie i modne, nawiązujące do charakterystycznego minimalizmu marki." },
                    new BrandTranslation { Brand = giorgioArmani, Language = english, Description = "Giorgio Armani is a brand that offers luxury perfumes for women and men. The brand offers many different scents that are valued for their quality, elegance, and originality. Among the most popular scents of the brand are \"Acqua di Gio,\" \"Armani Code,\" \"Si,\" \"Emporio Armani Stronger With You,\" and \"Armani Privé Rose d'Arabie.\" Giorgio Armani perfumes are composed of the highest quality ingredients, making the scents long-lasting and intense. The perfume bottles are usually simple, elegant, and fashionable, reflecting the brand's characteristic minimalism." },
                };
                foreach (var giorgioArmaniTranslation in giorgioArmaniTranslations)
                {
                    giorgioArmaniTranslation.EncodeName();
                }
                await _dbContext.BrandTranslations.AddRangeAsync(giorgioArmaniTranslations);


                var pacoRabanne = new Brand { Name = "Paco Rabanne" };
                pacoRabanne.EncodeName();
                _dbContext.Brands.Add(pacoRabanne);

                var pacoRabanneTranslations = new[]
                {
                    new BrandTranslation { Brand = pacoRabanne, Language = polish, Description = "Paco Rabanne to marka luksusowych perfum dla kobiet i mężczyzn, która oferuje wiele różnych zapachów. Najbardziej popularnymi zapachami marki są \"1 Million\", \"Lady Million\", \"Invictus\" i \"Olympéa\". Perfumy Paco Rabanne wyróżniają się zmysłowymi i intrygującymi kompozycjami, które są skomponowane z najwyższej jakości składników. Flakony perfum są często awangardowe, nowoczesne i oryginalne, nawiązujące do charakterystycznego stylu marki. Perfumy Paco Rabanne są cenione za swoją wyjątkowość, jakość i trwałość." },
                    new BrandTranslation { Brand = pacoRabanne, Language = english, Description = "Paco Rabanne is a luxury perfume brand for women and men that offers many different fragrances. The most popular scents of the brand are \"1 Million,\" \"Lady Million,\" \"Invictus,\" and \"Olympéa.\" Paco Rabanne perfumes stand out with sensual and intriguing compositions that are composed of the highest quality ingredients. The perfume bottles are often avant-garde, modern, and original, reflecting the brand's characteristic style. Paco Rabanne perfumes are valued for their uniqueness, quality, and longevity." },
                };
                foreach (var pacoRabanneTranslation in pacoRabanneTranslations)
                {
                    pacoRabanneTranslation.EncodeName();
                }
                await _dbContext.BrandTranslations.AddRangeAsync(pacoRabanneTranslations);


                var versace = new Brand { Name = "Versace" };
                versace.EncodeName();
                _dbContext.Brands.Add(versace);

                var versaceTranslations = new[]
                {
                    new BrandTranslation { Brand = versace, Language = polish, Description = "Versace to marka luksusowych perfum dla kobiet i mężczyzn, która oferuje wiele różnych zapachów. Wśród najbardziej popularnych zapachów marki znajdują się \"Bright Crystal\", \"Eros\", \"Dylan Blue\", \"Versace Pour Homme\", \"Yellow Diamond\" i \"Versace Man Eau Fraîche\". Perfumy Versace wyróżniają się zmysłowymi i niezwykle intensywnymi kompozycjami, które są skomponowane z najwyższej jakości składników. Flakony perfum są często ozdobione charakterystycznymi wzorami, nawiązującymi do stylu i estetyki marki. Perfumy Versace są cenione za swoją wyjątkowość, jakość i trwałość." },
                    new BrandTranslation { Brand = versace, Language = english, Description = "Versace is a luxury perfume brand for women and men that offers many different fragrances. Among the most popular scents of the brand are \"Bright Crystal,\" \"Eros,\" \"Dylan Blue,\" \"Versace Pour Homme,\" \"Yellow Diamond,\" and \"Versace Man Eau Fraîche.\" Versace perfumes stand out with sensual and extremely intense compositions that are composed of the highest quality ingredients. The perfume bottles are often adorned with characteristic patterns, reflecting the brand's style and aesthetics. Versace perfumes are valued for their uniqueness, quality, and longevity." },
                };
                foreach (var versaceTranslation in versaceTranslations)
                {
                    versaceTranslation.EncodeName();
                }
                await _dbContext.BrandTranslations.AddRangeAsync(versaceTranslations);


                var yvesSaintLaurent = new Brand { Name = "Yves Saint Laurent" };
                yvesSaintLaurent.EncodeName();
                _dbContext.Brands.Add(yvesSaintLaurent);

                var yvesSaintLaurentTranslations = new[]
                {
                    new BrandTranslation { Brand = yvesSaintLaurent, Language = polish, Description = "Yves Saint Laurent to marka luksusowych perfum dla kobiet i mężczyzn, która oferuje wiele różnych zapachów. Wśród najbardziej popularnych zapachów marki znajdują się \"Opium\", \"Black Opium\", \"Y\", \"L'Homme\", \"La Nuit de L'Homme\" i \"Mon Paris\". Perfumy Yves Saint Laurent wyróżniają się eleganckimi i zmysłowymi kompozycjami, które są skomponowane z najwyższej jakości składników. Flakony perfum są często proste, eleganckie i nowoczesne, nawiązujące do francuskiego stylu i klasyki. Perfumy Yves Saint Laurent są cenione za swoją wyjątkowość, jakość i trwałość." },
                    new BrandTranslation { Brand = yvesSaintLaurent, Language = english, Description = "Yves Saint Laurent is a luxury perfume brand for women and men that offers many different fragrances. Among the most popular scents of the brand are \"Opium,\" \"Black Opium,\" \"Y,\" \"L'Homme,\" \"La Nuit de L'Homme,\" and \"Mon Paris.\" Yves Saint Laurent perfumes stand out with elegant and sensual compositions that are composed of the highest quality ingredients. The perfume bottles are often simple, elegant, and modern, reflecting French style and classicism. Yves Saint Laurent perfumes are valued for their uniqueness, quality, and longevity." },
                };
                foreach (var yvesSaintLaurentTranslation in yvesSaintLaurentTranslations)
                {
                    yvesSaintLaurentTranslation.EncodeName();
                }
                await _dbContext.BrandTranslations.AddRangeAsync(yvesSaintLaurentTranslations);

                #endregion

                #region FragranceCategories

                var aromatic = new FragranceCategory();
                _dbContext.FragranceCategories.Add(aromatic);

                var aromaticTranslations = new[]
                {
                    new FragranceCategoryTranslation { FragranceCategory = aromatic, Language = polish, Name = "Aromatyczne", Description = "Perfumy aromatyczne charakteryzują się zapachami ziołowymi i drzewnymi. Najczęściej zawierają nuty takie jak rozmaryn, kolendra, mięta, drzewo sandałowe i cedr. Są one często stosowane w zapachach dla mężczyzn."},
                    new FragranceCategoryTranslation { FragranceCategory = aromatic, Language = english, Name = "Aromatic", Description = "Aromatic perfumes are characterized by herbal and woody scents. They often contain notes such as rosemary, coriander, mint, sandalwood, and cedar. They are commonly used in men's fragrances."},
                };
                foreach (var aromaticTranslation in aromaticTranslations)
                {
                    aromaticTranslation.EncodeName();
                }
                aromatic.FragranceCategoryTranslations = aromaticTranslations;
                aromatic.EncodeName();
                await _dbContext.FragranceCategoryTranslations.AddRangeAsync(aromaticTranslations);


                var citrus = new FragranceCategory();
                _dbContext.FragranceCategories.Add(citrus);

                var citrusTranslations = new[]
                {
                    new FragranceCategoryTranslation { FragranceCategory = citrus, Language = polish, Name = "Cytrusowe", Description = "Perfumy cytrusowe charakteryzują się orzeźwiającymi i energicznymi zapachami, które zawierają nuty takie jak pomarańcza, cytryna, bergamotka i grejpfrut. Są one często stosowane w zapachach letnich i sportowych."},
                    new FragranceCategoryTranslation { FragranceCategory = citrus, Language = english, Name = "Citrus", Description = "Citrus perfumes are characterized by refreshing and energetic scents that contain notes such as orange, lemon, bergamot, and grapefruit. They are commonly used in summer and sports fragrances."},
                };
                foreach (var citrusTranslation in citrusTranslations)
                {
                    citrusTranslation.EncodeName();
                }
                citrus.FragranceCategoryTranslations = citrusTranslations;
                citrus.EncodeName();
                await _dbContext.FragranceCategoryTranslations.AddRangeAsync(citrusTranslations);


                var floral = new FragranceCategory();
                _dbContext.FragranceCategories.Add(floral);

                var floralTranslations = new[]
                {
                    new FragranceCategoryTranslation { FragranceCategory = floral, Language = polish, Name = "Kwiatowe", Description = "Perfumy kwiatowe charakteryzują się słodkimi i romantycznymi zapachami, które zawierają nuty takie jak róża, jaśmin, fiołek, piwonia i magnolia. Są one często stosowane w zapachach dla kobiet."},
                    new FragranceCategoryTranslation { FragranceCategory = floral, Language = english, Name = "Floral", Description = "Floral perfumes are characterized by sweet and romantic scents that contain notes such as rose, jasmine, violet, peony, and magnolia. They are commonly used in women's fragrances."},
                };
                foreach (var floralTranslation in floralTranslations)
                {
                    floralTranslation.EncodeName();
                }
                floral.FragranceCategoryTranslations = floralTranslations;
                floral.EncodeName();
                await _dbContext.FragranceCategoryTranslations.AddRangeAsync(floralTranslations);


                var fruity = new FragranceCategory();
                _dbContext.FragranceCategories.Add(fruity);

                var fruityTranslations = new[]
                {
                    new FragranceCategoryTranslation { FragranceCategory = fruity, Language = polish, Name = "Owocowe", Description = "Perfumy owocowe charakteryzują się słodkimi i soczystymi zapachami, które zawierają nuty takie jak truskawka, malina, brzoskwinia, gruszka i jabłko. Są one często stosowane w zapachach letnich i na co dzień."},
                    new FragranceCategoryTranslation { FragranceCategory = fruity, Language = english, Name = "Fruity", Description = "Fruity perfumes are characterized by sweet and juicy scents that contain notes such as strawberry, raspberry, peach, pear, and apple. They are commonly used in summer and everyday fragrances."},
                };
                foreach (var fruityTranslation in fruityTranslations)
                {
                    fruityTranslation.EncodeName();
                }
                fruity.FragranceCategoryTranslations = fruityTranslations;
                fruity.EncodeName();
                await _dbContext.FragranceCategoryTranslations.AddRangeAsync(fruityTranslations);


                var oriental = new FragranceCategory();
                _dbContext.FragranceCategories.Add(oriental);

                var orientalTranslations = new[]
                {
                    new FragranceCategoryTranslation { FragranceCategory = oriental, Language= polish, Name = "Orientalne", Description = "Perfumy orientalne charakteryzują się zmysłowymi i intensywnymi zapachami, które zawierają nuty takie jak wanilia, paczula, kardamon, goździk i drzewo sandałowe. Są one często stosowane w zapachach wieczorowych i na specjalne okazje."},
                    new FragranceCategoryTranslation { FragranceCategory = oriental, Language = english, Name = "Oriental", Description = "Oriental perfumes are characterized by sensual and intense scents that contain notes such as vanilla, patchouli, cardamom, clove, and sandalwood. They are commonly used in evening and special occasion fragrances."},
                };
                foreach (var orientalTranslation in orientalTranslations)
                {
                    orientalTranslation.EncodeName();
                }
                oriental.FragranceCategoryTranslations = orientalTranslations;
                oriental.EncodeName();
                await _dbContext.FragranceCategoryTranslations.AddRangeAsync(orientalTranslations);


                var other = new FragranceCategory();
                _dbContext.FragranceCategories.Add(other);

                var otherTranslations = new[]
                {
                    new FragranceCategoryTranslation { FragranceCategory = other, Language = polish, Name = "Inne"},
                    new FragranceCategoryTranslation { FragranceCategory = other, Language = english, Name = "Other"},
                };
                foreach (var otherTranslation in otherTranslations)
                {
                    otherTranslation.EncodeName();
                }
                other.FragranceCategoryTranslations = otherTranslations;
                other.EncodeName();
                await _dbContext.FragranceCategoryTranslations.AddRangeAsync(otherTranslations);


                var spicy = new FragranceCategory();
                _dbContext.FragranceCategories.Add(spicy);

                var spicyTranslations = new[]
                {
                    new FragranceCategoryTranslation { FragranceCategory = spicy, Language = polish, Name = "Ostre", Description = "Perfumy ostre charakteryzują się mocnymi i intensywnymi zapachami, które zawierają nuty takie jak pieprz, imbir, cynamon, anyż i gałka muszkatołowa. Są one często stosowane w zapachach dla mężczyzn."},
                    new FragranceCategoryTranslation { FragranceCategory = spicy, Language = english, Name = "Spicy", Description = "Spicy perfumes are characterized by strong and intense scents that contain notes such as pepper, ginger, cinnamon, anise, and nutmeg. They are commonly used in men's fragrances."},
                };
                foreach (var spicyTranslation in spicyTranslations)
                {
                    spicyTranslation.EncodeName();
                }
                spicy.FragranceCategoryTranslations = spicyTranslations;
                spicy.EncodeName();
                await _dbContext.FragranceCategoryTranslations.AddRangeAsync(spicyTranslations);

                #endregion

                #region Genders

                var men = new Gender();
                _dbContext.Genders.Add(men);

                var menTranslations = new[]
                {
                    new GenderTranslation { Gender = men, Language = polish, Name = "Męskie" },
                    new GenderTranslation { Gender = men, Language = english, Name = "Men" },
                };
                foreach (var menTranslation in menTranslations)
                {
                    menTranslation.EncodeName();
                }
                men.GenderTranslations = menTranslations;
                men.EncodeName();
                await _dbContext.GenderTranslations.AddRangeAsync(menTranslations);


                var women = new Gender();
                _dbContext.Genders.Add(women);

                var womenTranslations = new[]
                {
                    new GenderTranslation { Gender = women, Language = polish, Name = "Damskie" },
                    new GenderTranslation { Gender = women, Language = english, Name = "Women" },
                };
                foreach (var womenTranslation in womenTranslations)
                {
                    womenTranslation.EncodeName();
                }
                women.GenderTranslations = womenTranslations;
                women.EncodeName();
                await _dbContext.GenderTranslations.AddRangeAsync(womenTranslations);


                var unisex = new Gender();
                _dbContext.Genders.Add(unisex);

                var unisexTranslations = new[]
                {
                    new GenderTranslation { Gender = unisex, Language = polish, Name = "Unisex" },
                    new GenderTranslation { Gender = unisex, Language = english, Name = "Unisex" },
                };
                foreach (var unisexTranslation in unisexTranslations)
                {
                    unisexTranslation.EncodeName();
                }
                unisex.GenderTranslations = unisexTranslations;
                unisex.EncodeName();
                await _dbContext.GenderTranslations.AddRangeAsync(unisexTranslations);

                #endregion

                #region Products

                var smellItDiffuser = new Product
                {
                    Brand = smellIt,
                    Category = diffusers
                };
                await _dbContext.Products.AddAsync(smellItDiffuser);

                var smellItDiffuserTranslations = new[]
                {
                    new ProductTranslation { Product = smellItDiffuser, Language = polish, Name = "Dyfuzor Smell It", Description = "Nowoczesny dyfuzor zapachów, który dzięki zaawansowanej technologii jest w stanie odwzorować 99% zapachów dostrzeganych przez człowieka. Urządzenie to łączy się bezprzewodowo z komputerem lub telefonem za pomocą Bluetooth. Dzięki Smell it sprawdzisz zapach perfum bez wychodzenia z domu, a także doświadczysz niesamowitych wrażeń sensorycznych podczas oglądania filmów."},
                    new ProductTranslation { Product = smellItDiffuser, Language = english, Name = "Smell It diffuser", Description = "The modern scent diffuser, which, thanks to advanced technology, is able to replicate 99% of scents perceived by humans. This device connects wirelessly to a computer or phone via Bluetooth. With Smell it, you can test a perfume's scent without leaving your home and also experience incredible sensory experiences while watching movies."},
                };
                foreach (var smellItDiffuserTranslation in smellItDiffuserTranslations)
                {
                    smellItDiffuserTranslation.EncodeName();
                }
                smellItDiffuser.ProductTranslations = smellItDiffuserTranslations;
                smellItDiffuser.EncodeName();
                await _dbContext.ProductTranslations.AddRangeAsync(smellItDiffuserTranslations);


                var goodGirl = new Product
                {
                    Brand = carolinaHerrera,
                    Category = fragrance,
                    FragranceCategory = oriental,
                    Gender = women
                };
                await _dbContext.Products.AddAsync(goodGirl);

                var goodGirlTranslations = new[]
                {
                    new ProductTranslation { Product = goodGirl, Language = polish, Name = "Good Girl", Description = "\"Good Girl\" to popularny zapach marki Carolina Herrera, który jest dostępny w wersjach dla kobiet i mężczyzn. Kompozycja zapachu to mieszanka zmysłowych i intensywnych nut, w tym bergamotki, jaśminu, tuberozy, kawy, paczuli i wanilii. Flakon zapachu w kształcie szklanej szpilki, symbolizuje kobiecość, elegancję i pewność siebie. \"Good Girl\" to zapach z charakterem, który jest idealny na wieczorne wyjścia i specjalne okazje. Zapach jest ceniony za swoją trwałość i oryginalność, a jego aromat jest jednocześnie słodki, zmysłowy i uwodzicielski."},
                    new ProductTranslation { Product = goodGirl, Language = english, Name = "Good Girl", Description = "\"Good Girl\" is a popular fragrance by Carolina Herrera, available in versions for women and men. The fragrance composition is a mixture of sensual and intense notes, including bergamot, jasmine, tuberose, coffee, patchouli, and vanilla. The fragrance bottle in the shape of a glass stiletto symbolizes femininity, elegance, and confidence. \"Good Girl\" is a fragrance with character, perfect for evening outings and special occasions. The fragrance is valued for its longevity and originality, and its aroma is simultaneously sweet, sensual, and seductive."},
                };
                foreach (var goodGirlTranslation in goodGirlTranslations)
                {
                    goodGirlTranslation.EncodeName();
                }
                goodGirl.ProductTranslations = goodGirlTranslations;
                goodGirl.EncodeName();
                await _dbContext.ProductTranslations.AddRangeAsync(goodGirlTranslations);


                var savuage = new Product
                {
                    Brand = dior,
                    Category = fragrance,
                    FragranceCategory = aromatic,
                    Gender = men
                };
                await _dbContext.Products.AddAsync(savuage);

                var savuageTranslations = new[]
                {
                    new ProductTranslation { Product = savuage, Language = polish, Name = "Savuage", Description = "\"Dior Sauvage\" to luksusowy męski zapach marki Dior, który został wprowadzony na rynek w 2015 roku. Kompozycja zapachu to mieszanka zmysłowych nut bergamotki, ambrowych akordów, paczuli, jałowca i cedru wirginijskiego. Zapach jest orzeźwiający, a jednocześnie intrygujący i zmysłowy. Flakon zapachu jest prosty i elegancki, wykonany z grubego, niebieskiego szkła, nawiązujący do nieba i morza. \"Dior Sauvage\" to zapach idealny na co dzień, który wyróżnia się swoją wyjątkowością i trwałością. Jest to zapach, który pasuje do mężczyzn o silnym charakterze, którzy cenią sobie klasykę i elegancję."},
                    new ProductTranslation { Product = savuage, Language = english, Name = "Savuage", Description = "\"Dior Sauvage\" is a luxury men's fragrance by Dior that was introduced in 2015. The fragrance composition is a mixture of sensual notes of bergamot, amber accords, patchouli, juniper, and Virginia cedar. The fragrance is refreshing, yet intriguing and sensual. The fragrance bottle is simple and elegant, made of thick blue glass, reminiscent of the sky and sea. \"Dior Sauvage\" is a perfect fragrance for everyday wear that stands out for its uniqueness and longevity. It is a fragrance that suits men with strong character who appreciate classic and elegance."},
                };
                foreach (var savuageTranslation in savuageTranslations)
                {
                    savuageTranslation.EncodeName();
                }
                savuage.ProductTranslations = savuageTranslations;
                savuage.EncodeName();
                await _dbContext.ProductTranslations.AddRangeAsync(savuageTranslations);


                var si = new Product
                {
                    Brand = giorgioArmani,
                    Category = fragrance,
                    FragranceCategory = fruity,
                    Gender = women
                };
                await _dbContext.Products.AddAsync(si);

                var siTranslations = new[]
                {
                    new ProductTranslation { Product = si, Language = polish, Name = "Si", Description = "\"Armani Si\" to zapach dla kobiet marki Armani, który został wprowadzony na rynek w 2013 roku. Kompozycja zapachu to połączenie nut owocowych, kwiatowych i drzewnych, w tym cassis, frezji, róż, paczuli, ambry i wanilii. \"Si\" to zapach elegancki, zmysłowy i kobiecy, idealny na wieczorne wyjścia i specjalne okazje. Flakon zapachu jest prosty i elegancki, wykonany z grubego, przezroczystego szkła, a na jego szyi umieszczona jest ozdobna zawieszka. Zapach \"Si\" jest ceniony za swoją trwałość i intensywność, a jego aromat jest jednocześnie słodki, zmysłowy i delikatny."},
                    new ProductTranslation { Product = si, Language = english, Name = "Si", Description = "\"Giorgio Armani Si\" is a fragrance for women by the Armani brand that was introduced in 2013. The fragrance composition is a combination of fruity, floral, and woody notes, including cassis, freesia, rose, patchouli, amber, and vanilla. \"Si\" is an elegant, sensual, and feminine fragrance, ideal for evening outings and special occasions. The fragrance bottle is simple and elegant, made of thick, transparent glass, and features a decorative pendant on its neck. \"Si\" fragrance is valued for its longevity and intensity, and its aroma is simultaneously sweet, sensual, and delicate."},
                };
                foreach (var siTranslation in siTranslations)
                {
                    siTranslation.EncodeName();
                }
                si.ProductTranslations = siTranslations;
                si.EncodeName();
                await _dbContext.ProductTranslations.AddRangeAsync(siTranslations);


                var oneMillion = new Product
                {
                    Brand = pacoRabanne,
                    Category = fragrance,
                    FragranceCategory = spicy,
                    Gender = men
                };
                await _dbContext.Products.AddAsync(oneMillion);

                var oneMillionTranslations = new[]
                {
                    new ProductTranslation { Product = oneMillion, Language = polish, Name = "1 Million", Description = "\"Paco Rabanne 1 Million\" to popularny męski zapach marki Paco Rabanne, który został wprowadzony na rynek w 2008 roku. Kompozycja zapachu to mieszanka nut drzewnych, przyprawowych i owocowych, w tym mięty pieprzowej, paczuli, cynamonu, skóry i grejpfruta. \"1 Million\" to zapach świeży, orzeźwiający i energetyzujący. Flakon zapachu w kształcie złotej monety nawiązuje do luksusu i bogactwa, symbolizując styl i klasę marki. \"Paco Rabanne 1 Million\" jest ceniony za swoją oryginalność, trwałość i intensywność zapachu, który jest jednocześnie zmysłowy, męski i uwodzicielski."},
                    new ProductTranslation { Product = oneMillion, Language = english, Name = "1 Million", Description = "\"Paco Rabanne 1 Million\" is a popular men's fragrance by Paco Rabanne that was introduced in 2008. The fragrance composition is a mixture of woody, spicy, and fruity notes, including peppermint, patchouli, cinnamon, leather, and grapefruit. \"1 Million\" is a fresh, refreshing, and energizing fragrance. The fragrance bottle in the shape of a golden coin refers to luxury and wealth, symbolizing the style and class of the brand. \"Paco Rabanne 1 Million\" is valued for its originality, longevity, and intensity of fragrance, which is simultaneously sensual, masculine, and seductive."},
                };
                foreach (var oneMillionTranslation in oneMillionTranslations)
                {
                    oneMillionTranslation.EncodeName();
                }
                oneMillion.ProductTranslations = oneMillionTranslations;
                oneMillion.EncodeName();
                await _dbContext.ProductTranslations.AddRangeAsync(oneMillionTranslations);


                var eros = new Product
                {
                    Brand = versace,
                    Category = fragrance,
                    FragranceCategory = aromatic,
                    Gender = men
                };
                await _dbContext.Products.AddAsync(eros);

                var erosTranslations = new[]
                {
                    new ProductTranslation { Product = eros, Language = polish, Name = "Eros", Description = "\"Versace Eros\" to popularny zapach marki Versace dla mężczyzn, który został wprowadzony na rynek w 2012 roku. Kompozycja zapachu zawiera nuty drzewne, przyprawowe i kwiatowe, w tym mięty, cytrusów, zielonej jabłk i wanilii. \"Eros\" to zapach męski, zmysłowy i intensywny, idealny na wieczorne wyjścia i specjalne okazje. Flakon zapachu w kształcie greckiej kolumny nawiązuje do klasycznej estetyki i symbolizuje siłę i męskość. \"Versace Eros\" jest ceniony za swoją oryginalność, trwałość i intensywność zapachu, który jest jednocześnie intrygujący, zmysłowy i uwodzicielski."},
                    new ProductTranslation { Product = eros, Language = english, Name = "Eros", Description = "\"Versace Eros\" is a popular fragrance by Versace for men that was introduced in 2012. The fragrance composition contains woody, spicy, and floral notes, including mint, citrus, green apple, and vanilla. \"Eros\" is a masculine, sensual, and intense fragrance, ideal for evening outings and special occasions. The fragrance bottle in the shape of a Greek column refers to classical aesthetics and symbolizes strength and masculinity. \"Versace Eros\" is valued for its originality, longevity, and intensity of fragrance, which is simultaneously intriguing, sensual, and seductive."},
                };
                foreach (var erosTranslation in erosTranslations)
                {
                    erosTranslation.EncodeName();
                }
                eros.ProductTranslations = erosTranslations;
                eros.EncodeName();
                await _dbContext.ProductTranslations.AddRangeAsync(erosTranslations);


                var blackOpium = new Product
                {
                    Brand = yvesSaintLaurent,
                    Category = fragrance,
                    FragranceCategory = oriental,
                    Gender = women
                };
                await _dbContext.Products.AddAsync(blackOpium);

                var blackOpiumTranslations = new[]
                {
                    new ProductTranslation { Product = blackOpium, Language = polish, Name = "Black Opium", Description = "\"Yves Saint Laurent Black Opium\" to popularny zapach dla kobiet marki Yves Saint Laurent, który został wprowadzony na rynek w 2014 roku. Kompozycja zapachu to mieszanka nut kwiatowych, kawowych, drzewnych i waniliowych, w tym róży, jaśminu, kawy, paczuli i wanilii. \"Black Opium\" to zapach zmysłowy, mocny i wyrazisty, idealny na wieczorne wyjścia i specjalne okazje. Flakon zapachu jest prosty, ale elegancki, wykonany z czarnego, matowego szkła, co nadaje mu niepowtarzalnego charakteru. \"Yves Saint Laurent Black Opium\" jest ceniony za swoją trwałość i intensywność zapachu, który jest jednocześnie słodki, zmysłowy i uwodzicielski."},
                    new ProductTranslation { Product = blackOpium, Language = english, Name = "Black Opium", Description = "\"Yves Saint Laurent Black Opium\" is a popular fragrance for women by the Yves Saint Laurent brand that was introduced in 2014. The fragrance composition is a mixture of floral, coffee, woody, and vanilla notes, including rose, jasmine, coffee, patchouli, and vanilla. \"Black Opium\" is a sensual, strong, and distinctive fragrance, ideal for evening outings and special occasions. The fragrance bottle is simple but elegant, made of black matte glass, which gives it a unique character. \"Yves Saint Laurent Black Opium\" is valued for its longevity and intensity of fragrance, which is simultaneously sweet, sensual, and seductive."},
                };
                foreach (var blackOpiumTranslation in blackOpiumTranslations)
                {
                    blackOpiumTranslation.EncodeName();
                }
                blackOpium.ProductTranslations = blackOpiumTranslations;
                blackOpium.EncodeName();
                await _dbContext.ProductTranslations.AddRangeAsync(blackOpiumTranslations);


                #endregion

                #region ProductImages

                List<ProductImage> productImages = new()
                {
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/smell-it/dyfuzor-smell-it1.jpg",
                        ImageAlt = "Smell It Diffuser",
                        Product = smellItDiffuser
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/women/Giorgio Armani Si/armani-si1.png",
                        ImageAlt = "Si",
                        Product = si
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/men/Dior Savuage/dior-savuage1.png",
                        ImageAlt = "Sauvage",
                        Product = savuage
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/women/YSL Black Opium/ysl-black-opium1.png",
                        ImageAlt = "Black Opium",
                        Product = blackOpium
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/women/Carolina Herrera Good Girl/ch-good-girl1.png",
                        ImageAlt = "Good Girl",
                        Product = goodGirl
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/men/Paco Rabanne 1 Million/pr-1million1.png",
                        ImageAlt = "1 Million",
                        Product = oneMillion
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/men/Versace Eros/versace-eros1.png",
                        ImageAlt = "Eros",
                        Product = eros
                    },
                };
                foreach (var productImage in productImages)
                {
                    productImage.EncodeName();
                }
                await _dbContext.ProductImages.AddRangeAsync(productImages);

                #endregion
            }
        }
    }
}
