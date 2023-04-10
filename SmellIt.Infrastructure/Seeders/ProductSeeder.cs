using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                List<Product> products = new List<Product>
                {
                    new Product
                    {
                        NameKey = "SmellItDiffuser",
                        DescriptionKey = "SmellItDiffuserDesc", 
                        CategoryId = _dbContext.ProductCategories.Where(c=>c.NameKey.Equals("Diffusers")).Single().Id,
                        BrandId = _dbContext.Brands.Where(c=>c.NameKey.Equals("SmellIt")).Single().Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                    new Product
                    {
                        NameKey = "GoodGirl",
                        DescriptionKey = "GoodGirlDesc",
                        CategoryId = _dbContext.ProductCategories.Where(c=>c.NameKey.Equals("Fragrance")).Single().Id,
                        BrandId = _dbContext.Brands.Where(c=>c.NameKey.Equals("CarolinaHerrera")).Single().Id,
                        FragranceGroupId = _dbContext.FragranceCategories.Where(c=>c.NameKey.Equals("Oriental")).Single().Id,
                        GenderId = _dbContext.Genders.Where(c=>c.NameKey.Equals("Women")).Single().Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                    new Product { 
                        NameKey = "Sauvage", 
                        DescriptionKey = "SauvageDesc",
                        CategoryId = _dbContext.ProductCategories.Where(c=>c.NameKey.Equals("Fragrance")).Single().Id,
                        BrandId = _dbContext.Brands.Where(c=>c.NameKey.Equals("Dior")).Single().Id,
                        FragranceGroupId = _dbContext.FragranceCategories.Where(c=>c.NameKey.Equals("Aromatic")).Single().Id,
                        GenderId = _dbContext.Genders.Where(c=>c.NameKey.Equals("Men")).Single().Id,
                        CreatedById = _dbContext.Users.FirstOrDefault()!.Id
                    },
                    new Product
                    {
                        NameKey = "Si", 
                        DescriptionKey = "SiDesc",
                        CategoryId = _dbContext.ProductCategories.Where(c=>c.NameKey.Equals("Fragrance")).Single().Id,
                        BrandId = _dbContext.Brands.Where(c=>c.NameKey.Equals("GiorgioArmani")).Single().Id,
                        FragranceGroupId = _dbContext.FragranceCategories.Where(c=>c.NameKey.Equals("Fruity")).Single().Id,
                        GenderId = _dbContext.Genders.Where(c=>c.NameKey.Equals("Women")).Single().Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                    new Product
                    {
                        NameKey = "1Million",
                        DescriptionKey = "1MillionDesc",
                        CategoryId = _dbContext.ProductCategories.Where(c=>c.NameKey.Equals("Fragrance")).Single().Id,
                        BrandId = _dbContext.Brands.Where(c=>c.NameKey.Equals("PacoRabanne")).Single().Id,
                        FragranceGroupId = _dbContext.FragranceCategories.Where(c=>c.NameKey.Equals("Spicy")).Single().Id,
                        GenderId = _dbContext.Genders.Where(c=>c.NameKey.Equals("Men")).Single().Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                    new Product
                    {
                        NameKey = "Eros",
                        DescriptionKey = "ErosDesc",
                        CategoryId = _dbContext.ProductCategories.Where(c=>c.NameKey.Equals("Fragrance")).Single().Id,
                        BrandId = _dbContext.Brands.Where(c=>c.NameKey.Equals("Versace")).Single().Id,
                        FragranceGroupId = _dbContext.FragranceCategories.Where(c=>c.NameKey.Equals("Aromatic")).Single().Id,
                        GenderId = _dbContext.Genders.Where(c=>c.NameKey.Equals("Men")).Single().Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                    new Product
                    {
                        NameKey = "BlackOpium",
                        DescriptionKey = "BlackOpiumDesc",
                        CategoryId = _dbContext.ProductCategories.Where(c=>c.NameKey.Equals("Fragrance")).Single().Id,
                        BrandId = _dbContext.Brands.Where(c=>c.NameKey.Equals("YvesSaintLaurent")).Single().Id,
                        FragranceGroupId = _dbContext.FragranceCategories.Where(c=>c.NameKey.Equals("Oriental")).Single().Id,
                        GenderId = _dbContext.Genders.Where(c=>c.NameKey.Equals("Women")).Single().Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    }
                };
                await _dbContext.Products.AddRangeAsync(products);

                List<TranslationEngb> translationEngbs = new List<TranslationEngb>()
                {
                    new TranslationEngb{Key="SmellItDiffuser", Value = "Smell It Diffuser", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="GoodGirl", Value = "Good Girl", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="Sauvage", Value = "Sauvage", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="Si", Value = "Si", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="1Million", Value = "1 Million", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="Eros", Value = "Eros", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="BlackOpium", Value = "Black Opium", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},

                    new TranslationEngb{Key="SmellItDiffuserDesc", Value = "The modern scent diffuser, which, thanks to advanced technology, is able to replicate 99% of scents perceived by humans. This device connects wirelessly to a computer or phone via Bluetooth. With Smell it, you can test a perfume's scent without leaving your home and also experience incredible sensory experiences while watching movies", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="GoodGirlDesc", Value = "\"Good Girl\" is a popular fragrance by Carolina Herrera, available in versions for women and men. The fragrance composition is a mixture of sensual and intense notes, including bergamot, jasmine, tuberose, coffee, patchouli, and vanilla. The fragrance bottle in the shape of a glass stiletto symbolizes femininity, elegance, and confidence. \"Good Girl\" is a fragrance with character, perfect for evening outings and special occasions. The fragrance is valued for its longevity and originality, and its aroma is simultaneously sweet, sensual, and seductive.", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="SauvageDesc", Value = "\"Sauvage\" is a luxury men's fragrance by Dior that was introduced in 2015. The fragrance composition is a mixture of sensual notes of bergamot, amber accords, patchouli, juniper, and Virginia cedar. The fragrance is refreshing, yet intriguing and sensual. The fragrance bottle is simple and elegant, made of thick blue glass, reminiscent of the sky and sea. \"Dior Sauvage\" is a perfect fragrance for everyday wear that stands out for its uniqueness and longevity. It is a fragrance that suits men with strong character who appreciate classic and elegance.", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="SiDesc", Value = "\"Si\" is a luxurious fragrance for women from the Armani line, which was introduced to the market in 2013. The fragrance composition contains fruity, floral, and woody notes, including blackcurrant, freesia, rose, patchouli, amber, and vanilla. \"Si\" is an elegant, sensual, and feminine fragrance, ideal for evening outings and special occasions. The perfume bottle is simple yet elegant, made of thick, transparent glass, and features a decorative pendant on its neck. \"Giorgio Armani Si\" is valued for its longevity and intensity, and its fragrance is simultaneously sweet, sensual, and delicate.", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="1MillionDesc", Value = "\"1 Million\" is a popular men's fragrance by Paco Rabanne that was introduced in 2008. The fragrance composition is a mixture of woody, spicy, and fruity notes, including peppermint, patchouli, cinnamon, leather, and grapefruit. \"1 Million\" is a fresh, refreshing, and energizing fragrance. The fragrance bottle in the shape of a golden coin refers to luxury and wealth, symbolizing the style and class of the brand. \"Paco Rabanne 1 Million\" is valued for its originality, longevity, and intensity of fragrance, which is simultaneously sensual, masculine, and seductive.", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="ErosDesc", Value = "\"Eros\" is a popular fragrance by Versace for men that was introduced in 2012. The fragrance composition contains woody, spicy, and floral notes, including mint, citrus, green apple, and vanilla. \"Eros\" is a masculine, sensual, and intense fragrance, ideal for evening outings and special occasions. The fragrance bottle in the shape of a Greek column refers to classical aesthetics and symbolizes strength and masculinity. \"Versace Eros\" is valued for its originality, longevity, and intensity of fragrance, which is simultaneously intriguing, sensual, and seductive.", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationEngb{Key="BlackOpiumDesc", Value = "\"Black Opium\" is a popular fragrance for women by the Yves Saint Laurent brand that was introduced in 2014. The fragrance composition is a mixture of floral, coffee, woody, and vanilla notes, including rose, jasmine, coffee, patchouli, and vanilla. \"Black Opium\" is a sensual, strong, and distinctive fragrance, ideal for evening outings and special occasions. The fragrance bottle is simple but elegant, made of black matte glass, which gives it a unique character. \"Yves Saint Laurent Black Opium\" is valued for its longevity and intensity of fragrance, which is simultaneously sweet, sensual, and seductive.", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                };
                await _dbContext.TranslationEngbs.AddRangeAsync(translationEngbs);

                List<TranslationPlpl> translationPlpls = new List<TranslationPlpl>()
                {
                    new TranslationPlpl{Key="SmellItDiffuser", Value = "Dyfuzor Smell It", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="GoodGirl", Value = "Good Girl", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="Sauvage", Value = "Sauvage", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="Si", Value = "Si", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="1Million", Value = "1 Million", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="Eros", Value = "Eros", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="BlackOpium", Value = "Black Opium", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},

                    new TranslationPlpl{Key="SmellItDiffuserDesc", Value = "Nowoczesny dyfuzor zapachów, który dzięki zaawansowanej technologii jest w stanie odwzorować 99% zapachów dostrzeganych przez człowieka. Urządzenie to łączy się bezprzewodowo z komputerem lub telefonem za pomocą Bluetooth. Dzięki Smell it sprawdzisz zapach perfum bez wychodzenia z domu, a także doświadczysz niesamowitych wrażeń sensorycznych podczas oglądania filmów", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="GoodGirlDesc", Value = "\"Good Girl\" to popularny zapach marki Carolina Herrera, który jest dostępny w wersjach dla kobiet i mężczyzn. Kompozycja zapachu to mieszanka zmysłowych i intensywnych nut, w tym bergamotki, jaśminu, tuberozy, kawy, paczuli i wanilii. Flakon zapachu w kształcie szklanej szpilki, symbolizuje kobiecość, elegancję i pewność siebie. \"Good Girl\" to zapach z charakterem, który jest idealny na wieczorne wyjścia i specjalne okazje. Zapach jest ceniony za swoją trwałość i oryginalność, a jego aromat jest jednocześnie słodki, zmysłowy i uwodzicielski.", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="SauvageDesc", Value = "\"Sauvage\" to luksusowy męski zapach marki Dior, który został wprowadzony na rynek w 2015 roku. Kompozycja zapachu to mieszanka zmysłowych nut bergamotki, ambrowych akordów, paczuli, jałowca i cedru wirginijskiego. Zapach jest orzeźwiający, a jednocześnie intrygujący i zmysłowy. Flakon zapachu jest prosty i elegancki, wykonany z grubego, niebieskiego szkła, nawiązujący do nieba i morza. \"Dior Sauvage\" to zapach idealny na co dzień, który wyróżnia się swoją wyjątkowością i trwałością. Jest to zapach, który pasuje do mężczyzn o silnym charakterze, którzy cenią sobie klasykę i elegancję.", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="SiDesc", Value = "\"Si\" to luksusowy zapach dla kobiet z linii Armani, który pojawił się na rynku w 2013 roku. Kompozycja zapachu zawiera nuty owocowe, kwiatowe i drzewne, w tym czarnej porzeczki, frezji, róży, paczuli, bursztynu i wanilii. \"Si\" to elegancki, zmysłowy i kobiecy zapach, idealny na wieczorne wyjścia i specjalne okazje. Flakon perfum jest prosty, ale elegancki, wykonany z grubego, przezroczystego szkła, a na jego szyi umieszczona jest ozdobna zawieszka. \"Giorgio Armani Si\" jest ceniony za swoją trwałość i intensywność, a jego zapach jest jednocześnie słodki, zmysłowy i delikatny.", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="1MillionDesc", Value = "\"1 Million\" to popularny męski zapach marki Paco Rabanne, który został wprowadzony na rynek w 2008 roku. Kompozycja zapachu to mieszanka nut drzewnych, przyprawowych i owocowych, w tym mięty pieprzowej, paczuli, cynamonu, skóry i grejpfruta. \"1 Million\" to zapach świeży, orzeźwiający i energetyzujący. Flakon zapachu w kształcie złotej monety nawiązuje do luksusu i bogactwa, symbolizując styl i klasę marki. \"Paco Rabanne 1 Million\" jest ceniony za swoją oryginalność, trwałość i intensywność zapachu, który jest jednocześnie zmysłowy, męski i uwodzicielski.", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="ErosDesc", Value = "\"Eros\" to popularny zapach marki Versace dla mężczyzn, który został wprowadzony na rynek w 2012 roku. Kompozycja zapachu zawiera nuty drzewne, przyprawowe i kwiatowe, w tym mięty, cytrusów, zielonej jabłk i wanilii. \"Eros\" to zapach męski, zmysłowy i intensywny, idealny na wieczorne wyjścia i specjalne okazje. Flakon zapachu w kształcie greckiej kolumny nawiązuje do klasycznej estetyki i symbolizuje siłę i męskość. \"Versace Eros\" jest ceniony za swoją oryginalność, trwałość i intensywność zapachu, który jest jednocześnie intrygujący, zmysłowy i uwodzicielski.", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                    new TranslationPlpl{Key="BlackOpiumDesc", Value = "\"Black Opium\" to popularny zapach dla kobiet marki Yves Saint Laurent, który został wprowadzony na rynek w 2014 roku. Kompozycja zapachu to mieszanka nut kwiatowych, kawowych, drzewnych i waniliowych, w tym róży, jaśminu, kawy, paczuli i wanilii. \"Black Opium\" to zapach zmysłowy, mocny i wyrazisty, idealny na wieczorne wyjścia i specjalne okazje. Flakon zapachu jest prosty, ale elegancki, wykonany z czarnego, matowego szkła, co nadaje mu niepowtarzalnego charakteru. \"Yves Saint Laurent Black Opium\" jest ceniony za swoją trwałość i intensywność zapachu, który jest jednocześnie słodki, zmysłowy i uwodzicielski.", CreatedById = _dbContext.Users.FirstOrDefault() !.Id},
                };
                await _dbContext.TranslationPlpls.AddRangeAsync(translationPlpls);
            }
        }
    }
}
