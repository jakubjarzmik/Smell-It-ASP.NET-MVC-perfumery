using SmellIt.Domain.Entities;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Seeders
{
    public class Seeder
    {
        private readonly SmellItDbContext _dbContext;

        public Seeder(SmellItDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Products.Any())
                {
                    #region Languages

                    var polish = new Language { Code = "pl-PL", Name = "Polski" };
                    var english = new Language { Code = "en-GB", Name = "English (GB)" };
                    polish.EncodeName();
                    english.EncodeName();
                    await _dbContext.Languages.AddAsync(polish);
                    await _dbContext.Languages.AddAsync(english);

                    #endregion

                    #region Addresses

                    var address = new Address
                    {
                        Street = "Floriańska 1",
                        PostalCode = "31-042",
                        City = "Kraków",
                        Country = "Polska",
                    };
                    address.EncodeName();
                    await _dbContext.Addresses.AddAsync(address);

                    #endregion

                    #region ProductCategories

                    var devices = new ProductCategory();
                    await _dbContext.ProductCategories.AddAsync(devices);

                    List<ProductCategoryTranslation> devicesTranslations = new()
                {
                    new ProductCategoryTranslation { ProductCategory = devices, Language = polish, Name = "Urządzenia"},
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
                    await _dbContext.ProductCategories.AddAsync(fragrance);

                    List<ProductCategoryTranslation> fragranceTranslations = new()
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
                    await _dbContext.ProductCategories.AddAsync(homeFragrance);

                    List<ProductCategoryTranslation> homeFragranceTranslations = new()
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
                    await _dbContext.ProductCategories.AddAsync(others);

                    List<ProductCategoryTranslation> othersTranslations = new()
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
                    await _dbContext.ProductCategories.AddAsync(diffusers);

                    List<ProductCategoryTranslation> diffusersTranslations = new()
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
                    await _dbContext.ProductCategories.AddAsync(fresheners);

                    List<ProductCategoryTranslation> freshenersTranslations = new()
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
                    await _dbContext.ProductCategories.AddAsync(scentedCandles);

                    List<ProductCategoryTranslation> scentedCandlesTranslations = new()
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
                    await _dbContext.ProductCategories.AddAsync(essentialOils);

                    List<ProductCategoryTranslation> essentialOilsTranslations = new()
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
                    await _dbContext.ProductCategories.AddAsync(carFresheners);

                    List<ProductCategoryTranslation> carFreshenersTranslations = new()
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
                    await _dbContext.Brands.AddAsync(smellIt);

                    List<BrandTranslation> smellItTranslations = new()
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
                    await _dbContext.Brands.AddAsync(carolinaHerrera);

                    List<BrandTranslation> carolinaHerreraTranslations = new()
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
                    await _dbContext.Brands.AddAsync(dior);

                    List<BrandTranslation> diorTranslations = new()
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
                    await _dbContext.Brands.AddAsync(giorgioArmani);

                    List<BrandTranslation> giorgioArmaniTranslations = new()
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
                    await _dbContext.Brands.AddAsync(pacoRabanne);

                    List<BrandTranslation> pacoRabanneTranslations = new()
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
                    await _dbContext.Brands.AddAsync(versace);

                    List<BrandTranslation> versaceTranslations = new()
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
                    await _dbContext.Brands.AddAsync(yvesSaintLaurent);

                    List<BrandTranslation> yvesSaintLaurentTranslations = new()
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
                    await _dbContext.FragranceCategories.AddAsync(aromatic);

                    List<FragranceCategoryTranslation> aromaticTranslations = new()
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
                    await _dbContext.FragranceCategories.AddAsync(citrus);

                    List<FragranceCategoryTranslation> citrusTranslations = new()
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
                    await _dbContext.FragranceCategories.AddAsync(floral);

                    List<FragranceCategoryTranslation> floralTranslations = new()
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
                    await _dbContext.FragranceCategories.AddAsync(fruity);

                    List<FragranceCategoryTranslation> fruityTranslations = new()
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
                    await _dbContext.FragranceCategories.AddAsync(oriental);

                    List<FragranceCategoryTranslation> orientalTranslations = new()
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
                    await _dbContext.FragranceCategories.AddAsync(other);

                    List<FragranceCategoryTranslation> otherTranslations = new()
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
                    await _dbContext.FragranceCategories.AddAsync(spicy);

                    List<FragranceCategoryTranslation> spicyTranslations = new()
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
                    await _dbContext.Genders.AddAsync(men);

                    List<GenderTranslation> menTranslations = new()
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
                    await _dbContext.Genders.AddAsync(women);

                    List<GenderTranslation> womenTranslations = new()
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
                    await _dbContext.Genders.AddAsync(unisex);

                    List<GenderTranslation> unisexTranslations = new()
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

                    List<ProductTranslation> smellItDiffuserTranslations = new()
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

                    List<ProductTranslation> goodGirlTranslations = new()
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

                    List<ProductTranslation> savuageTranslations = new()
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

                    List<ProductTranslation> siTranslations = new()
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

                    List<ProductTranslation> oneMillionTranslations = new()
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

                    List<ProductTranslation> erosTranslations = new()
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

                    List<ProductTranslation> blackOpiumTranslations = new()
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

                    #region WebsiteText

                    var phoneNumber = new WebsiteText { Key = "PhoneNumber" };
                    phoneNumber.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(phoneNumber);

                    List<WebsiteTextTranslation> phoneNumberTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = phoneNumber, Language = polish, Text = "+48 777 321 321" },
                        new WebsiteTextTranslation { WebsiteText = phoneNumber, Language = english, Text = "+48 777 321 321" },
                    };
                    foreach (var x in phoneNumberTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(phoneNumberTranslations);


                    var emailSmellIt = new WebsiteText { Key = "EmailSmellIt" };
                    emailSmellIt.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(emailSmellIt);

                    List<WebsiteTextTranslation> emailSmellItTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = emailSmellIt, Language = polish, Text = "info@smellit.com" },
                        new WebsiteTextTranslation { WebsiteText = emailSmellIt, Language = english, Text = "info@smellit.com" },
                    };
                    foreach (var x in emailSmellItTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(emailSmellItTranslations);


                    var total = new WebsiteText { Key = "Total" };
                    total.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(total);

                    List<WebsiteTextTranslation> totalTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = total, Language = polish, Text = "Razem" },
                        new WebsiteTextTranslation { WebsiteText = total, Language = english, Text = "Total" },
                    };
                    foreach (var x in totalTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(totalTranslations);


                    var cart = new WebsiteText { Key = "Cart" };
                    cart.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(cart);

                    List<WebsiteTextTranslation> cartTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = cart, Language = polish, Text = "Koszyk" },
                        new WebsiteTextTranslation { WebsiteText = cart, Language = english, Text = "Cart" },
                    };
                    foreach (var x in cartTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(cartTranslations);


                    var search = new WebsiteText { Key = "Search" };
                    search.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(search);

                    List<WebsiteTextTranslation> searchTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = search, Language = polish, Text = "Szukaj" },
                        new WebsiteTextTranslation { WebsiteText = search, Language = english, Text = "Search" },
                    };
                    foreach (var x in searchTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(searchTranslations);


                    var home = new WebsiteText { Key = "Home" };
                    home.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(home);

                    List<WebsiteTextTranslation> homeTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = home, Language = polish, Text = "Strona główna" },
                        new WebsiteTextTranslation { WebsiteText = home, Language = english, Text = "Home" },
                    };
                    foreach (var x in homeTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(homeTranslations);


                    var products = new WebsiteText { Key = "Products" };
                    products.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(products);

                    List<WebsiteTextTranslation> productsTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = products, Language = polish, Text = "Produkty" },
                        new WebsiteTextTranslation { WebsiteText = products, Language = english, Text = "Products" },
                    };
                    foreach (var x in productsTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(productsTranslations);


                    var contact = new WebsiteText { Key = "Contact" };
                    contact.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(contact);

                    List<WebsiteTextTranslation> contactTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = contact, Language = polish, Text = "Kontakt" },
                        new WebsiteTextTranslation { WebsiteText = contact, Language = english, Text = "Contact" },
                    };
                    foreach (var x in contactTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(contactTranslations);


                    var aboutUs = new WebsiteText { Key = "AboutUs" };
                    aboutUs.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(aboutUs);

                    List<WebsiteTextTranslation> aboutUsTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = aboutUs, Language = polish, Text = "O nas" },
                        new WebsiteTextTranslation { WebsiteText = aboutUs, Language = english, Text = "About Us" },
                    };
                    foreach (var x in aboutUsTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(aboutUsTranslations);


                    var signIn = new WebsiteText { Key = "SignIn" };
                    signIn.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(signIn);

                    List<WebsiteTextTranslation> signInTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = signIn, Language = polish, Text = "Zaloguj się" },
                        new WebsiteTextTranslation { WebsiteText = signIn, Language = english, Text = "Sign in" },
                    };
                    foreach (var x in signInTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(signInTranslations);


                    var register = new WebsiteText { Key = "Register" };
                    register.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(register);

                    List<WebsiteTextTranslation> registerTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = register, Language = polish, Text = "Zarejestruj się" },
                        new WebsiteTextTranslation { WebsiteText = register, Language = english, Text = "Register" },
                    };
                    foreach (var x in registerTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(registerTranslations);


                    var subscribeToNewsletter = new WebsiteText { Key = "SubscribeToNewsletter" };
                    subscribeToNewsletter.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(subscribeToNewsletter);

                    List<WebsiteTextTranslation> subscribeToNewsletterTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = subscribeToNewsletter, Language = polish, Text = "Zapisz się do newsletter'a" },
                        new WebsiteTextTranslation { WebsiteText = subscribeToNewsletter, Language = english, Text = "Subscribe to Newsletter" },
                    };
                    foreach (var x in subscribeToNewsletterTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(subscribeToNewsletterTranslations);


                    var subscribeToNewsletterDesc = new WebsiteText { Key = "SubscribeToNewsletterDesc" };
                    subscribeToNewsletterDesc.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(subscribeToNewsletterDesc);

                    List<WebsiteTextTranslation> subscribeToNewsletterDescTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = subscribeToNewsletterDesc, Language = polish, Text = "Jako pierwszy dowiesz się o najnowszych promocjach i produktach" },
                        new WebsiteTextTranslation { WebsiteText = subscribeToNewsletterDesc, Language = english, Text = "Be the first to find out about the latest promotions and products" },
                    };
                    foreach (var x in subscribeToNewsletterDescTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(subscribeToNewsletterDescTranslations);


                    var enterYourEmail = new WebsiteText { Key = "EnterYourEmail" };
                    enterYourEmail.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(enterYourEmail);

                    List<WebsiteTextTranslation> enterYourEmailTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = enterYourEmail, Language = polish, Text = "Podaj swój adres e-mail" },
                        new WebsiteTextTranslation { WebsiteText = enterYourEmail, Language = english, Text = "Enter your e-mail" },
                    };
                    foreach (var x in enterYourEmailTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(enterYourEmailTranslations);


                    var subscribeNow = new WebsiteText { Key = "SubscribeNow" };
                    subscribeNow.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(subscribeNow);

                    List<WebsiteTextTranslation> subscribeNowTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = subscribeNow, Language = polish, Text = "Subskrybuj!" },
                        new WebsiteTextTranslation { WebsiteText = subscribeNow, Language = english, Text = "Subscribe Now!" },
                    };
                    foreach (var x in subscribeNowTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(subscribeNowTranslations);


                    var privacyPolicy = new WebsiteText { Key = "PrivacyPolicy" };
                    privacyPolicy.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(privacyPolicy);

                    List<WebsiteTextTranslation> privacyPolicyTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = privacyPolicy, Language = polish, Text = "Polityka prywatności" },
                        new WebsiteTextTranslation { WebsiteText = privacyPolicy, Language = english, Text = "Privacy Policy" },
                    };
                    foreach (var x in privacyPolicyTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(privacyPolicyTranslations);


                    var sortBy = new WebsiteText { Key = "SortBy" };
                    sortBy.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(sortBy);

                    List<WebsiteTextTranslation> sortByTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = sortBy, Language = polish, Text = "Sortuj według" },
                        new WebsiteTextTranslation { WebsiteText = sortBy, Language = english, Text = "Sort by" },
                    };
                    foreach (var x in sortByTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(sortByTranslations);


                    var newest = new WebsiteText { Key = "Newest" };
                    newest.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(newest);

                    List<WebsiteTextTranslation> newestTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = newest, Language = polish, Text = "Najnowsze" },
                        new WebsiteTextTranslation { WebsiteText = newest, Language = english, Text = "Newest" },
                    };
                    foreach (var x in newestTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(newestTranslations);


                    var oldest = new WebsiteText { Key = "Oldest" };
                    oldest.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(oldest);

                    List<WebsiteTextTranslation> oldestTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = oldest, Language = polish, Text = "Najstarsze" },
                        new WebsiteTextTranslation { WebsiteText = oldest, Language = english, Text = "Oldest" },
                    };
                    foreach (var x in oldestTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(oldestTranslations);


                    var priceAscending = new WebsiteText { Key = "PriceAscending" };
                    priceAscending.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(priceAscending);

                    List<WebsiteTextTranslation> priceAscendingTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = priceAscending, Language = polish, Text = "Cena rosnąco" },
                        new WebsiteTextTranslation { WebsiteText = priceAscending, Language = english, Text = "Price ascending" },
                    };
                    foreach (var x in priceAscendingTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(priceAscendingTranslations);


                    var priceDescending = new WebsiteText { Key = "PriceDescending" };
                    priceDescending.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(priceDescending);

                    List<WebsiteTextTranslation> priceDescendingTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = priceDescending, Language = polish, Text = "Cena malejąco" },
                        new WebsiteTextTranslation { WebsiteText = priceDescending, Language = english, Text = "Price descending" },
                    };
                    foreach (var x in priceDescendingTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(priceDescendingTranslations);


                    var filters = new WebsiteText { Key = "Filters" };
                    filters.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(filters);

                    List<WebsiteTextTranslation> filtersTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = filters, Language = polish, Text = "Filtry" },
                        new WebsiteTextTranslation { WebsiteText = filters, Language = english, Text = "Filters" },
                    };
                    foreach (var x in filtersTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(filtersTranslations);


                    var category = new WebsiteText { Key = "Category" };
                    category.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(category);

                    List<WebsiteTextTranslation> categoryTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = category, Language = polish, Text = "Kategoria" },
                        new WebsiteTextTranslation { WebsiteText = category, Language = english, Text = "Category" },
                    };
                    foreach (var x in categoryTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(categoryTranslations);


                    var gender = new WebsiteText { Key = "Gender" };
                    gender.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(gender);

                    List<WebsiteTextTranslation> genderTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = gender, Language = polish, Text = "Płeć" },
                        new WebsiteTextTranslation { WebsiteText = gender, Language = english, Text = "Gender" },
                    };
                    foreach (var x in genderTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(genderTranslations);


                    var brand = new WebsiteText { Key = "Brand" };
                    brand.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(brand);

                    List<WebsiteTextTranslation> brandTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = brand, Language = polish, Text = "Marka" },
                        new WebsiteTextTranslation { WebsiteText = brand, Language = english, Text = "Brand" },
                    };
                    foreach (var x in brandTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(brandTranslations);


                    var fragranceCategory = new WebsiteText { Key = "FragranceCategory" };
                    fragranceCategory.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(fragranceCategory);

                    List<WebsiteTextTranslation> fragranceCategoryTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = fragranceCategory, Language = polish, Text = "Kategoria zapachu" },
                        new WebsiteTextTranslation { WebsiteText = fragranceCategory, Language = english, Text = "Fragrance category" },
                    };
                    foreach (var x in fragranceCategoryTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(fragranceCategoryTranslations);


                    var yourName = new WebsiteText { Key = "YourName" };
                    yourName.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(yourName);

                    List<WebsiteTextTranslation> yourNameTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = yourName, Language = polish, Text = "Twoje imię" },
                        new WebsiteTextTranslation { WebsiteText = yourName, Language = english, Text = "Your name" },
                    };
                    foreach (var x in yourNameTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(yourNameTranslations);


                    var yourEmail = new WebsiteText { Key = "YourEmail" };
                    yourEmail.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(yourEmail);

                    List<WebsiteTextTranslation> yourEmailTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = yourEmail, Language = polish, Text = "Twój email" },
                        new WebsiteTextTranslation { WebsiteText = yourEmail, Language = english, Text = "Your email" },
                    };
                    foreach (var x in yourEmailTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(yourEmailTranslations);


                    var subject = new WebsiteText { Key = "Subject" };
                    subject.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(subject);

                    List<WebsiteTextTranslation> subjectTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = subject, Language = polish, Text = "Temat" },
                        new WebsiteTextTranslation { WebsiteText = subject, Language = english, Text = "Subject" },
                    };
                    foreach (var x in subjectTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(subjectTranslations);


                    var message = new WebsiteText { Key = "Message" };
                    message.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(message);

                    List<WebsiteTextTranslation> messageTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = message, Language = polish, Text = "Wiadomość" },
                        new WebsiteTextTranslation { WebsiteText = message, Language = english, Text = "Message" },
                    };
                    foreach (var x in messageTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(messageTranslations);


                    var send = new WebsiteText { Key = "Send" };
                    send.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(send);

                    List<WebsiteTextTranslation> sendTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = send, Language = polish, Text = "Wyślij" },
                        new WebsiteTextTranslation { WebsiteText = send, Language = english, Text = "Send" },
                    };
                    foreach (var x in sendTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(sendTranslations);


                    var thanksForMessage = new WebsiteText { Key = "ThanksForMessage" };
                    thanksForMessage.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(thanksForMessage);

                    List<WebsiteTextTranslation> thanksForMessageTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = thanksForMessage, Language = polish, Text = "Dziękujemy za wiadomość!" },
                        new WebsiteTextTranslation { WebsiteText = thanksForMessage, Language = english, Text = "Thanks for message!" },
                    };
                    foreach (var x in thanksForMessageTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(thanksForMessageTranslations);


                    var somethingWentWrong = new WebsiteText { Key = "SomethingWentWrong" };
                    somethingWentWrong.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(somethingWentWrong);

                    List<WebsiteTextTranslation> somethingWentWrongTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = somethingWentWrong, Language = polish, Text = "Coś poszło nie tak" },
                        new WebsiteTextTranslation { WebsiteText = somethingWentWrong, Language = english, Text = "Something went wrong" },
                    };
                    foreach (var x in somethingWentWrongTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(somethingWentWrongTranslations);


                    var seeNow = new WebsiteText { Key = "SeeNow" };
                    seeNow.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(seeNow);

                    List<WebsiteTextTranslation> seeNowTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = seeNow, Language = polish, Text = "Zobacz teraz" },
                        new WebsiteTextTranslation { WebsiteText = seeNow, Language = english, Text = "See now" },
                    };
                    foreach (var x in seeNowTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(seeNowTranslations);


                    var privacyTitle = new WebsiteText { Key = "PrivacyTitle" };
                    privacyTitle.EncodeName();
                    await _dbContext.WebsiteTexts.AddAsync(privacyTitle);

                    List<WebsiteTextTranslation> privacyTitleTranslations = new()
                    {
                        new WebsiteTextTranslation { WebsiteText = privacyTitle, Language = polish, Text = "Polityka prywatności sklepu internetowego \"Smell it\"" },
                        new WebsiteTextTranslation { WebsiteText = privacyTitle, Language = english, Text = "Privacy Policy of the online store \"Smell it\"" },
                    };
                    foreach (var x in privacyTitleTranslations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.WebsiteTextTranslations.AddRangeAsync(privacyTitleTranslations);


                    //var = new WebsiteText { Key = "" };
                    //.EncodeName();
                    //await _dbContext.WebsiteTexts.AddAsync();

                    //List<WebsiteTextTranslation> Translations = new()
                    //{
                    //	new WebsiteTextTranslation { WebsiteText = , Language = polish, Text = "" },
                    //	new WebsiteTextTranslation { WebsiteText = , Language = english, Text = "" },
                    //};
                    //foreach (var x in Translations)
                    //{
                    //	x.EncodeName();
                    //}
                    //await _dbContext.WebsiteTextTranslations.AddRangeAsync(Translations);

                    #endregion

                    #region HomeBanner

                    var homeBanner1 = new HomeBanner
                    {
                        Key = "HomeBanner1",
                        ImagePath = "/images/banners/HomeBanner1.jpg"
                    };
                    homeBanner1.EncodeName();
                    await _dbContext.HomeBanners.AddAsync(homeBanner1);

                    List<HomeBannerTranslation> homeBanner1Translations = new()
                    {
                        new HomeBannerTranslation { HomeBanner = homeBanner1, Language = polish, Text = "Poczuj każdy zapach niewychodząc z domu" },
                        new HomeBannerTranslation { HomeBanner = homeBanner1, Language = english, Text = "Experience every scent without leaving your home" },
                    };
                    foreach (var x in homeBanner1Translations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.HomeBannerTranslations.AddRangeAsync(homeBanner1Translations);


                    var homeBanner2 = new HomeBanner
                    {
                        Key = "HomeBanner2",
                        ImagePath = "/images/banners/HomeBanner2.jpg"
                    };
                    homeBanner2.EncodeName();
                    await _dbContext.HomeBanners.AddAsync(homeBanner2);

                    List<HomeBannerTranslation> homeBanner2Translations = new()
                    {
                        new HomeBannerTranslation { HomeBanner = homeBanner2, Language = polish, Text = "Dior - SAUVAGE\noczaruje Cię już w chwili, gdy otworzysz flakon" },
                        new HomeBannerTranslation { HomeBanner = homeBanner2, Language = english, Text = "Dior - SAUVAGE\nwill captivate you from the moment you open the bottle" },
                    };
                    foreach (var x in homeBanner2Translations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.HomeBannerTranslations.AddRangeAsync(homeBanner2Translations);


                    var homeBanner3 = new HomeBanner
                    {
                        Key = "HomeBanner3",
                        ImagePath = "/images/banners/HomeBanner3.jpg"
                    };
                    homeBanner3.EncodeName();
                    await _dbContext.HomeBanners.AddAsync(homeBanner3);

                    List<HomeBannerTranslation> homeBanner3Translations = new()
                    {
                        new HomeBannerTranslation { HomeBanner = homeBanner3, Language = polish, Text = "Armani Si\nperfumt damskie, których nie zapomnisz" },
                        new HomeBannerTranslation { HomeBanner = homeBanner3, Language = english, Text = "Armani Si\nwomen's perfume, unforgettable" },
                    };
                    foreach (var x in homeBanner3Translations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.HomeBannerTranslations.AddRangeAsync(homeBanner3Translations);


                    var homeBanner4 = new HomeBanner
                    {
                        Key = "HomeBanner4",
                        ImagePath = "/images/banners/HomeBanner4.jpg"
                    };
                    homeBanner4.EncodeName();
                    await _dbContext.HomeBanners.AddAsync(homeBanner4);

                    List<HomeBannerTranslation> homeBanner4Translations = new()
                    {
                        new HomeBannerTranslation { HomeBanner = homeBanner4, Language = polish, Text = "Zapachy do domu, które wytworzą przytulną atmosferę" },
                        new HomeBannerTranslation { HomeBanner = homeBanner4, Language = english, Text = "Home fragrances that will create a cozy atmosphere" },
                    };
                    foreach (var x in homeBanner4Translations)
                    {
                        x.EncodeName();
                    }
                    await _dbContext.HomeBannerTranslations.AddRangeAsync(homeBanner4Translations);


                    #endregion

                    #region PrivacyPolicy

                    var privacyPolicyTextEn = new PrivacyPolicy
                    {
                        Language = english,
                        Text = "<p>This Privacy Policy sets out the rules for processing personal data by the online store \"Smell it\" operated by Smell it Sp. z o.o. with its registered office in Cracow</p> <h3>1. Personal data controller</h3> <p>The personal data controller is Smell it Sp. z o.o. with its registered office in Cracow</p> <h3>2. Purposes and legal basis for processing personal data</h3> <p>The \"Smell it\" online store processes personal data for the purpose of fulfilling orders, including payment processing and delivery of ordered products, as well as enabling the use of other store functionalities, such as a newsletter and a customer account.</p> <p>The legal basis for processing personal data is:</p> <ul> <li>the conclusion and performance of a sales contract (Art. 6(1)(b) of the GDPR)</li> <li>the legitimate interests of the data controller, consisting in fulfilling orders and enabling the use of store functionalities (Art. 6(1)(f) of the GDPR)</li> <li>the customer's consent to the processing of personal data for the purpose of receiving a newsletter and using a customer account (Art. 6(1)(a) of the GDPR)</li> </ul> <p>&nbsp;</p> <h3>3. Types of personal data processed</h3> <p>The \"Smell it\" online store processes the following personal data:</p> <ul> <li>first and last name</li> <li>email address</li> <li>telephone number</li> <li>delivery address</li> <li>bank account number or credit card information (in case of payment processing)</li> </ul> <p>&nbsp;</p> <h3>4. Recipients of personal data</h3> <p>Personal data processed by the \"Smell it\" online store may be disclosed to entities responsible for payment processing and delivery of ordered products. Additionally, the controller may disclose personal data to authorities authorized by law and to entities processing data on behalf of the controller (e.g. IT service providers).</p> <h3>5. Retention period for personal data</h3> <p>Personal data processed by the \"Smell it\" online store will be stored for the period necessary to fulfill an order and to enable the use of store functionalities. Personal data processed for the purpose of receiving a newsletter and using a customer account will be stored until consent is withdrawn.</p> <h3>6. Rights of data subjects</h3> <p>Each person whose personal data is processed by the \"Smell it\" online store has the right to:</p> <ul> <li>access their personal data</li> <li>rectify their personal data</li> <li>erase their personal data</li> <li>restrict the processing of their personal data</li> <li>transfer their personal data</li> <li>object to the processing of their personal data</li> </ul> <p>&nbsp;</p> <h3>7. Cookies</h3> <p>The \"Smell it\" online store uses cookies to enable the use of store functionalities and to improve the quality of provided services. Cookies are small text files stored on the user's device.</p> <p>The user can block or delete cookies at any time by using the appropriate settings in their web browser.</p> <h3>8. Changes to the Privacy Policy</h3> <p>The controller reserves the right to make changes to the Privacy Policy at any time. These changes will be published on the store's website.</p> <h3>9. Contact with the Administrator</h3> <p>For issues related to the processing of personal data by the \"Smell it\" online store, please contact the personal data Administrator via email at info@smellit.com or in writing at the registered office address.</p>"
                    };
                    privacyPolicyTextEn.EncodeName();
                    await _dbContext.PrivacyPolicies.AddAsync(privacyPolicyTextEn);

                    var privacyPolicyTextPl = new PrivacyPolicy
                    {
                        Language = polish,
                        Text = "<p>Niniejsza Polityka Prywatności określa zasady przetwarzania danych osobowych przez sklep internetowy \"Smell it\" prowadzony przez Smell it sp. z o.o., z siedzibą w Krakowie.</p> <h3>1. Administrator danych osobowych</h3> <p>Administratorem danych osobowych jest Smell it sp. z o.o., z siedzibą w Krakowie.</p> <h3>2. Cele i podstawy przetwarzania danych osobowych</h3> <p>Sklep internetowy \"Smell it\" przetwarza dane osobowe w celu realizacji zam&oacute;wień, w tym dokonywania płatności oraz dostawy zam&oacute;wionych produkt&oacute;w, oraz w celu umożliwienia korzystania z pozostałych funkcjonalności sklepu, w tym newslettera oraz konta klienta.</p> <p>Podstawą przetwarzania danych osobowych jest:</p> <ul> <li>zawarcie i wykonanie umowy sprzedaży (art. 6 ust. 1 lit. b RODO)</li> <li>prawnie uzasadniony interes Administratora polegający na realizacji zam&oacute;wień oraz umożliwieniu korzystania z funkcjonalności sklepu (art. 6 ust. 1 lit. f RODO)</li> <li>zgoda klienta na przetwarzanie danych osobowych w celu otrzymywania newslettera oraz korzystania z konta klienta (art. 6 ust. 1 lit. a RODO)</li> </ul> <p>&nbsp;</p> <h3>3. Rodzaje przetwarzanych danych osobowych</h3> <p>Sklep internetowy \"Smell it\" przetwarza następujące dane osobowe:</p> <ul> <li>imię i nazwisko</li> <li>adres e-mail</li> <li>numer telefonu</li> <li>adres dostawy</li> <li>numer rachunku bankowego lub karty płatniczej (w przypadku dokonywania płatności)</li> </ul> <p>&nbsp;</p> <h3>4. Odbiorcy danych osobowych</h3> <p>Dane osobowe przetwarzane przez sklep internetowy \"Smell it\" mogą być przekazywane podmiotom zajmującym się obsługą płatności oraz dostawą zam&oacute;wionych produkt&oacute;w. Ponadto, Administrator może przekazywać dane osobowe organom uprawnionym na mocy prawa oraz podmiotom przetwarzającym dane na zlecenie Administratora (np. dostawcom usług IT).</p> <h3>5. Okres przechowywania danych osobowych</h3> <p>Dane osobowe przetwarzane przez sklep internetowy \"Smell it\" będą przechowywane przez okres niezbędny do realizacji zam&oacute;wienia oraz w celu umożliwienia korzystania z funkcjonalności sklepu. Dane osobowe przetwarzane w celu otrzymywania newslettera oraz korzystania z konta klienta będą przechowywane do czasu wycofania zgody na ich przetwarzanie.</p> <h3>6. Prawa osoby, kt&oacute;rej dane dotyczą</h3> <p>Każda osoba, kt&oacute;rej dane osobowe są przetwarzane przez sklep internetowy \"Smell it\", ma prawo do:</p> <ul> <li>dostępu do swoich danych osobowych</li> <li>sprostowania swoich danych osobowych</li> <li>usunięcia swoich danych osobowych</li> <li>ograniczenia przetwarzania swoich danych osobowych</li> <li>przenoszenia swoich danych osobowych</li> <li>wniesienia sprzeciwu wobec przetwarzania swoich danych osobowych</li> </ul> <p>&nbsp;</p> <h3>7. Pliki cookies</h3> <p>Sklep internetowy \"Smell it\" korzysta z plik&oacute;w cookies w celu umożliwienia korzystania z funkcjonalności sklepu oraz poprawy jakości świadczonych usług. Pliki cookies są małymi plikami tekstowymi przechowywanymi na urządzeniu końcowym użytkownika sklepu.</p> <p>Użytkownik może w każdej chwili zablokować lub usunąć pliki cookies za pomocą odpowiednich ustawień w przeglądarce internetowej.</p> <h3>8. Zmiany w Polityce Prywatności</h3> <p>Administrator zastrzega sobie prawo do dokonywania zmian w Polityce Prywatności w dowolnym czasie. Zmiany te będą publikowane na stronie internetowej sklepu.</p> <h3>9. Kontakt z Administratorem</h3> <p>W sprawach związanych z przetwarzaniem danych osobowych przez sklep internetowy \"Smell it\" należy skontaktować się z Administratorem danych osobowych za pomocą adresu e-mail info@smellit.com lub pisemnie na adres siedziby firmy.</p>"
                    };
                    privacyPolicyTextPl.EncodeName();
                    await _dbContext.PrivacyPolicies.AddAsync(privacyPolicyTextPl);

                    #endregion

                    #region SocialSite

                    var facebookSite = new SocialSite
                    {
                        Type = "facebook",
                        Link = "https://www.facebook.com/jakubjarzmik00"
                    };
                    facebookSite.EncodeName();
                    await _dbContext.SocialSites.AddAsync(facebookSite);

                    var instagramSite = new SocialSite
                    {
                        Type = "instagram",
                        Link = "https://www.instagram.com/jjerzu"
                    };
                    instagramSite.EncodeName();
                    await _dbContext.SocialSites.AddAsync(instagramSite);

                    var linkedinSite = new SocialSite
                    {
                        Type = "linkedin",
                        Link = "https://www.linkedin.com/in/jakub-jarzmik"
                    };
                    linkedinSite.EncodeName();
                    await _dbContext.SocialSites.AddAsync(linkedinSite);

                    var githubSite = new SocialSite
                    {
                        Type = "github",
                        Link = "https://github.com/jakubjarzmik"
                    };
                    githubSite.EncodeName();
                    await _dbContext.SocialSites.AddAsync(githubSite);

                    #endregion

                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
