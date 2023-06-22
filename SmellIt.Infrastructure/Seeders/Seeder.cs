using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Seeders;

public class Seeder
{
    private readonly SmellItDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private IdentityUser? _defaultAdmin;
    private IdentityUser? _defaultClient;
    private IdentityUser? _defaultClient2;
    private Product? _sauvage;
    private Product? _si;
    private readonly Language _polish;
    private readonly Language _english;

    public Seeder(SmellItDbContext dbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _roleManager = roleManager;
        _polish = _dbContext.Languages.FirstOrDefault(l => l.Code == "pl-PL") ??
                  new Language { Code = "pl-PL", Name = "Polski" };
        _english = _dbContext.Languages.FirstOrDefault(l => l.Code == "en-GB") ??
                   new Language { Code = "en-GB", Name = "English (GB)" };
    }

    public async Task Seed()
    {
        if (await _dbContext.Database.CanConnectAsync())
        {
            await SeedRolesAsync();
            await SeedDefaultUsers();
            await SeedAddressesAsync();
            await SeedProductsAsync();
            await SeedOrdersAsync();
            await SeedWebsiteTextsAsync();
            await SeedHomeBannersAsync();
            await SeedPrivacyPoliciesAsync();
            await SeedSocialSitesAsync();

            await _dbContext.SaveChangesAsync();
        }
    }

    private async Task SeedOrdersAsync()
    {

        if (!await _dbContext.Orders.AnyAsync())
        {
            #region Payments

            var cashOnDelivery = new Payment();
            await _dbContext.Payments.AddAsync(cashOnDelivery);

            List<PaymentTranslation> cashOnDeliveryTranslations = new()
            {
                new PaymentTranslation
                {
                    Payment = cashOnDelivery, Language = _polish, Name = "Płatność za pobraniem",
                },
                new PaymentTranslation
                {
                    Payment = cashOnDelivery, Language = _english, Name = "Cash on Delivery",
                },
            };
            cashOnDelivery.PaymentTranslations = cashOnDeliveryTranslations;
            await _dbContext.PaymentTranslations.AddRangeAsync(cashOnDeliveryTranslations);


            var bankTransfer = new Payment();
            await _dbContext.Payments.AddAsync(bankTransfer);

            List<PaymentTranslation> bankTransferTranslations = new()
        {
            new PaymentTranslation
            {
                Payment = bankTransfer, Language = _polish, Name = "Przelew bankowy",
            },
            new PaymentTranslation
            {
                Payment = bankTransfer, Language = _english, Name = "Bank Transfer",
            },
        };
            bankTransfer.PaymentTranslations = bankTransferTranslations;
            await _dbContext.PaymentTranslations.AddRangeAsync(bankTransferTranslations);


            var blik = new Payment();
            await _dbContext.Payments.AddAsync(bankTransfer);

            List<PaymentTranslation> blikTranslations = new()
        {
            new PaymentTranslation
            {
                Payment = blik, Language = _polish, Name = "Blik",
            },
            new PaymentTranslation
            {
                Payment = blik, Language = _english, Name = "Blik",
            },
        };
            blik.PaymentTranslations = blikTranslations;
            await _dbContext.PaymentTranslations.AddRangeAsync(blikTranslations);


            var creditCard = new Payment();
            await _dbContext.Payments.AddAsync(creditCard);

            List<PaymentTranslation> creditCardTranslations = new()
            {
                new PaymentTranslation
                {
                    Payment = creditCard, Language = _polish, Name = "Karta płatnicza",
                },
                new PaymentTranslation
                {
                    Payment = creditCard, Language = _english, Name = "Credit Card",
                },
            };
            creditCard.PaymentTranslations = creditCardTranslations;
            await _dbContext.PaymentTranslations.AddRangeAsync(creditCardTranslations);


            await _dbContext.SaveChangesAsync();
            var paymentList = await _dbContext.Payments.ToListAsync();
            foreach (var x in paymentList)
            {
                x.EncodeName();
                x.CreatedBy = _defaultAdmin;
            }

            #endregion

            #region Deliveries

            var parcelLocker = new Delivery
            {
                Price = 9
            };
            await _dbContext.Deliveries.AddAsync(parcelLocker);

            List<DeliveryTranslation> parcelLockerTranslations = new()
            {
                new DeliveryTranslation
                {
                    Delivery = parcelLocker, Language = _polish, Name = "Paczkomat",
                },
                new DeliveryTranslation
                {
                    Delivery = parcelLocker, Language = _english, Name = "Parcel Locker",
                },
            };
            parcelLocker.DeliveryTranslations = parcelLockerTranslations;
            await _dbContext.DeliveryTranslations.AddRangeAsync(parcelLockerTranslations);


            var courier = new Delivery
            {
                Price = 12
            };
            await _dbContext.Deliveries.AddAsync(courier);

            List<DeliveryTranslation> courierTranslations = new()
            {
                new DeliveryTranslation
                {
                    Delivery = courier, Language = _polish, Name = "Kurier",
                },
                new DeliveryTranslation
                {
                    Delivery = courier, Language = _english, Name = "Courier",
                },
            };
            courier.DeliveryTranslations = courierTranslations;
            await _dbContext.DeliveryTranslations.AddRangeAsync(courierTranslations);


            var selfPickup = new Delivery
            {
                Price = 0
            };
            await _dbContext.Deliveries.AddAsync(selfPickup);

            List<DeliveryTranslation> selfPickupTranslations = new()
            {
                new DeliveryTranslation
                {
                    Delivery = selfPickup, Language = _polish, Name = "Odbiór osobisty",
                },
                new DeliveryTranslation
                {
                    Delivery = selfPickup, Language = _english, Name = "Self-pickup",
                },
            };
            selfPickup.DeliveryTranslations = selfPickupTranslations;
            await _dbContext.DeliveryTranslations.AddRangeAsync(selfPickupTranslations);


            await _dbContext.SaveChangesAsync();
            var deliveryList = await _dbContext.Deliveries.ToListAsync();
            foreach (var x in deliveryList)
            {
                x.EncodeName();
                x.CreatedBy = _defaultAdmin;
            }
            #endregion

            #region Order statuses

            var shipped = new OrderStatus();
            await _dbContext.OrderStatus.AddAsync(shipped);

            List<OrderStatusTranslation> shippedTranslations = new()
            {
                new OrderStatusTranslation { OrderStatus = shipped, Language = _polish, Name = "Wysłane" },
                new OrderStatusTranslation { OrderStatus = shipped, Language = _english, Name = "Shipped" },
            };
            shipped.OrderStatusTranslations = shippedTranslations;
            await _dbContext.OrderStatusTranslations.AddRangeAsync(shippedTranslations);


            var preparing = new OrderStatus();
            await _dbContext.OrderStatus.AddAsync(preparing);

            List<OrderStatusTranslation> preparingTranslations = new()
            {
                new OrderStatusTranslation { OrderStatus = preparing, Language = _polish, Name = "W trakcie przygotowywania" },
                new OrderStatusTranslation { OrderStatus = preparing, Language = _english, Name = "Preparing" },
            };
            preparing.OrderStatusTranslations = preparingTranslations;
            await _dbContext.OrderStatusTranslations.AddRangeAsync(preparingTranslations);


            var received = new OrderStatus();
            await _dbContext.OrderStatus.AddAsync(received);

            List<OrderStatusTranslation> receivedTranslations = new()
            {
                new OrderStatusTranslation { OrderStatus = received, Language = _polish, Name = "Przyjęte" },
                new OrderStatusTranslation { OrderStatus = received, Language = _english, Name = "Received" },
            };
            received.OrderStatusTranslations = receivedTranslations;
            await _dbContext.OrderStatusTranslations.AddRangeAsync(receivedTranslations);



            await _dbContext.SaveChangesAsync();
            var orderStatusList = await _dbContext.OrderStatus.ToListAsync();
            foreach (var x in orderStatusList)
            {
                x.EncodeName();
                x.CreatedBy = _defaultAdmin;
            }
            #endregion

            #region Addresses

            var adamNowakAddress = new Address
            {
                CreatedBy = _defaultClient2,
                FullName = "Adam Nowak",
                FirstLine = "Lubawska 23",
                PostalCode = "81-066",
                City = "Gdynia"
            };

            await _dbContext.Addresses.AddAsync(adamNowakAddress);

            var janKowalskiAddress = new Address
            {
                CreatedBy = _defaultClient,
                FullName = "Jan Kowalski",
                FirstLine = "Bolesława Krzywoustego 144",
                PostalCode = "02-496",
                City = "Warszawa"
            };

            await _dbContext.Addresses.AddAsync(janKowalskiAddress);

            await _dbContext.SaveChangesAsync();
            #endregion

            #region Orders

            var order1 = new Order
            {
                OrderDate = DateTime.Now.AddDays(-5),
                Notes = "Proszę o jak najszybszą dostawę",
                User = _defaultClient!,
                PhoneNumber = "746456878",
                Address = janKowalskiAddress,
                CreatedBy = _defaultClient,
                Delivery = courier,
                Payment = creditCard,
                OrderStatus = shipped
            };
            await _dbContext.AddAsync(order1);


            var order2 = new Order
            {
                OrderDate = DateTime.Now,
                User = _defaultClient!,
                PhoneNumber = "746456878",
                Address = janKowalskiAddress,
                CreatedBy = _defaultClient,
                Delivery = parcelLocker,
                Payment = blik,
                OrderStatus = received
            };
            await _dbContext.AddAsync(order2);


            var order3 = new Order
            {
                OrderDate = DateTime.Now.AddDays(-1),
                Notes = "Proszę dobrze zapakować",
                User = _defaultClient2!,
                PhoneNumber = "693532993",
                Address = adamNowakAddress,
                CreatedBy = _defaultClient2,
                Delivery = parcelLocker,
                Payment = bankTransfer,
                OrderStatus = preparing
            };
            await _dbContext.AddAsync(order3);


            await _dbContext.SaveChangesAsync();

            #endregion

            #region OrderItems

            var sauvagePrice = _sauvage!.ProductPrices.First().Value;
            var sauvageOrderItem = new OrderItem
            {
                CreatedBy = _defaultClient,
                Quantity = 2,
                Product = _sauvage,
                UnitPrice = sauvagePrice,
                TotalPrice = sauvagePrice * 2,
                Order = order1
            };
            await _dbContext.AddAsync(sauvageOrderItem);

            var siPrice = _si!.ProductPrices.First().Value;
            var siOrderItem = new OrderItem
            {
                CreatedBy = _defaultClient,
                Quantity = 1,
                Product = _si,
                UnitPrice = siPrice,
                TotalPrice = siPrice,
                Order = order1
            };
            await _dbContext.AddAsync(siOrderItem);

            order1.TotalPrice = sauvageOrderItem.TotalPrice + siOrderItem.TotalPrice;

            await _dbContext.SaveChangesAsync();


            
            var sauvageOrderItem2 = new OrderItem
            {
                CreatedBy = _defaultClient,
                Quantity = 1,
                Product = _sauvage,
                UnitPrice = sauvagePrice,
                TotalPrice = sauvagePrice,
                Order = order2
            };
            await _dbContext.AddAsync(sauvageOrderItem2);

            order2.TotalPrice = sauvageOrderItem2.TotalPrice;

            await _dbContext.SaveChangesAsync();
            


            
            var siOrderItem2 = new OrderItem
            {
                CreatedBy = _defaultClient2,
                Quantity = 2,
                Product = _si,
                UnitPrice = siPrice,
                TotalPrice = siPrice * 2,
                Order = order3
            };
            await _dbContext.AddAsync(siOrderItem2);

            order3.TotalPrice = siOrderItem2.TotalPrice;

            await _dbContext.SaveChangesAsync();

            #endregion
        }
    }

    public async Task SeedRolesAsync()
    {
        var roles = new[] { "Admin", "Employee" };
        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                var identityRole = new IdentityRole(role);
                await _roleManager.CreateAsync(identityRole);
            }
        }
    }

    public async Task SeedDefaultUsers()
    {
        _defaultAdmin = new IdentityUser { UserName = "admin@smellit.com", Email = "admin@smellit.com" };
        if (_userManager.FindByEmailAsync(_defaultAdmin.Email).Result == null)
        {
            await _userManager.CreateAsync(_defaultAdmin, "zaq1@WSX");
            await _userManager.AddToRoleAsync(_defaultAdmin, "Admin");
            await _userManager.AddToRoleAsync(_defaultAdmin, "Employee");
        }

        var defaultEmployee = new IdentityUser { UserName = "employee@smellit.com", Email = "employee@smellit.com" };
        if (_userManager.FindByEmailAsync(defaultEmployee.Email).Result == null)
        {
            await _userManager.CreateAsync(defaultEmployee, "zaq1@WSX");
            await _userManager.AddToRoleAsync(defaultEmployee, "Employee");
        }

        _defaultClient = new IdentityUser { UserName = "jankowalski@gmail.com", Email = "jankowalski@gmail.com" };
        if (_userManager.FindByEmailAsync(_defaultClient.Email).Result == null)
        {
            await _userManager.CreateAsync(_defaultClient, "zaq1@WSX");
        }

        _defaultClient2 = new IdentityUser { UserName = "adamnowak@outlook.com", Email = "adamnowak@outlook.com" };
        if (_userManager.FindByEmailAsync(_defaultClient2.Email).Result == null)
        {
            await _userManager.CreateAsync(_defaultClient2, "zaq1@WSX");
        }
    }

    private async Task SeedSocialSitesAsync()
    {
        if (!await _dbContext.SocialSites.AnyAsync())
        {
            var githubSite = new SocialSite
            {
                Type = "github",
                Link = "https://github.com/jakubjarzmik"
            };
            await _dbContext.SocialSites.AddAsync(githubSite);

            var linkedinSite = new SocialSite
            {
                Type = "linkedin",
                Link = "https://www.linkedin.com/in/jakub-jarzmik"
            };
            await _dbContext.SocialSites.AddAsync(linkedinSite);

            var instagramSite = new SocialSite
            {
                Type = "instagram",
                Link = "https://www.instagram.com/jjerzu"
            };
            await _dbContext.SocialSites.AddAsync(instagramSite);

            var facebookSite = new SocialSite
            {
                Type = "facebook",
                Link = "https://www.facebook.com/jakubjarzmik00"
            };
            await _dbContext.SocialSites.AddAsync(facebookSite);

            await _dbContext.SaveChangesAsync();
            var socialSites = await _dbContext.SocialSites.ToListAsync();
            foreach (var x in socialSites)
            {
                x.EncodeName();
                x.CreatedBy = _defaultAdmin;
            }
        }
    }

    private async Task SeedPrivacyPoliciesAsync()
    {
        if (!await _dbContext.PrivacyPolicies.AnyAsync())
        {
            var privacyPolicyTextEn = new PrivacyPolicy
            {
                Language = _english,
                Text =
                    "<p>This Privacy Policy sets out the rules for processing personal data by the online store \"Smell it\" operated by Smell it Sp. z o.o. with its registered office in Cracow</p> <h3>1. Personal data controller</h3> <p>The personal data controller is Smell it Sp. z o.o. with its registered office in Cracow</p> <h3>2. Purposes and legal basis for processing personal data</h3> <p>The \"Smell it\" online store processes personal data for the purpose of fulfilling orders, including payment processing and delivery of ordered products, as well as enabling the use of other store functionalities, such as a newsletter and a customer account.</p> <p>The legal basis for processing personal data is:</p> <ul> <li>the conclusion and performance of a sales contract (Art. 6(1)(b) of the GDPR)</li> <li>the legitimate interests of the data controller, consisting in fulfilling orders and enabling the use of store functionalities (Art. 6(1)(f) of the GDPR)</li> <li>the customer's consent to the processing of personal data for the purpose of receiving a newsletter and using a customer account (Art. 6(1)(a) of the GDPR)</li> </ul> <p>&nbsp;</p> <h3>3. Types of personal data processed</h3> <p>The \"Smell it\" online store processes the following personal data:</p> <ul> <li>first and last name</li> <li>email address</li> <li>telephone number</li> <li>delivery address</li> <li>bank account number or credit card information (in case of payment processing)</li> </ul> <p>&nbsp;</p> <h3>4. Recipients of personal data</h3> <p>Personal data processed by the \"Smell it\" online store may be disclosed to entities responsible for payment processing and delivery of ordered products. Additionally, the controller may disclose personal data to authorities authorized by law and to entities processing data on behalf of the controller (e.g. IT service providers).</p> <h3>5. Retention period for personal data</h3> <p>Personal data processed by the \"Smell it\" online store will be stored for the period necessary to fulfill an order and to enable the use of store functionalities. Personal data processed for the purpose of receiving a newsletter and using a customer account will be stored until consent is withdrawn.</p> <h3>6. Rights of data subjects</h3> <p>Each person whose personal data is processed by the \"Smell it\" online store has the right to:</p> <ul> <li>access their personal data</li> <li>rectify their personal data</li> <li>erase their personal data</li> <li>restrict the processing of their personal data</li> <li>transfer their personal data</li> <li>object to the processing of their personal data</li> </ul> <p>&nbsp;</p> <h3>7. Cookies</h3> <p>The \"Smell it\" online store uses cookies to enable the use of store functionalities and to improve the quality of provided services. Cookies are small text files stored on the user's device.</p> <p>The user can block or delete cookies at any time by using the appropriate settings in their web browser.</p> <h3>8. Changes to the Privacy Policy</h3> <p>The controller reserves the right to make changes to the Privacy Policy at any time. These changes will be published on the store's website.</p> <h3>9. Contact with the Administrator</h3> <p>For issues related to the processing of personal data by the \"Smell it\" online store, please contact the personal data Administrator via email at info@smellit.com or in writing at the registered office address.</p>"
            };
            await _dbContext.PrivacyPolicies.AddAsync(privacyPolicyTextEn);

            var privacyPolicyTextPl = new PrivacyPolicy
            {
                Language = _polish,
                Text =
                    "<p>Niniejsza Polityka Prywatności określa zasady przetwarzania danych osobowych przez sklep internetowy \"Smell it\" prowadzony przez Smell it sp. z o.o., z siedzibą w Krakowie.</p> <h3>1. Administrator danych osobowych</h3> <p>Administratorem danych osobowych jest Smell it sp. z o.o., z siedzibą w Krakowie.</p> <h3>2. Cele i podstawy przetwarzania danych osobowych</h3> <p>Sklep internetowy \"Smell it\" przetwarza dane osobowe w celu realizacji zam&oacute;wień, w tym dokonywania płatności oraz dostawy zam&oacute;wionych produkt&oacute;w, oraz w celu umożliwienia korzystania z pozostałych funkcjonalności sklepu, w tym newslettera oraz konta klienta.</p> <p>Podstawą przetwarzania danych osobowych jest:</p> <ul> <li>zawarcie i wykonanie umowy sprzedaży (art. 6 ust. 1 lit. b RODO)</li> <li>prawnie uzasadniony interes Administratora polegający na realizacji zam&oacute;wień oraz umożliwieniu korzystania z funkcjonalności sklepu (art. 6 ust. 1 lit. f RODO)</li> <li>zgoda klienta na przetwarzanie danych osobowych w celu otrzymywania newslettera oraz korzystania z konta klienta (art. 6 ust. 1 lit. a RODO)</li> </ul> <p>&nbsp;</p> <h3>3. Rodzaje przetwarzanych danych osobowych</h3> <p>Sklep internetowy \"Smell it\" przetwarza następujące dane osobowe:</p> <ul> <li>imię i nazwisko</li> <li>adres e-mail</li> <li>numer telefonu</li> <li>adres dostawy</li> <li>numer rachunku bankowego lub karty płatniczej (w przypadku dokonywania płatności)</li> </ul> <p>&nbsp;</p> <h3>4. Odbiorcy danych osobowych</h3> <p>Dane osobowe przetwarzane przez sklep internetowy \"Smell it\" mogą być przekazywane podmiotom zajmującym się obsługą płatności oraz dostawą zam&oacute;wionych produkt&oacute;w. Ponadto, Administrator może przekazywać dane osobowe organom uprawnionym na mocy prawa oraz podmiotom przetwarzającym dane na zlecenie Administratora (np. dostawcom usług IT).</p> <h3>5. Okres przechowywania danych osobowych</h3> <p>Dane osobowe przetwarzane przez sklep internetowy \"Smell it\" będą przechowywane przez okres niezbędny do realizacji zam&oacute;wienia oraz w celu umożliwienia korzystania z funkcjonalności sklepu. Dane osobowe przetwarzane w celu otrzymywania newslettera oraz korzystania z konta klienta będą przechowywane do czasu wycofania zgody na ich przetwarzanie.</p> <h3>6. Prawa osoby, kt&oacute;rej dane dotyczą</h3> <p>Każda osoba, kt&oacute;rej dane osobowe są przetwarzane przez sklep internetowy \"Smell it\", ma prawo do:</p> <ul> <li>dostępu do swoich danych osobowych</li> <li>sprostowania swoich danych osobowych</li> <li>usunięcia swoich danych osobowych</li> <li>ograniczenia przetwarzania swoich danych osobowych</li> <li>przenoszenia swoich danych osobowych</li> <li>wniesienia sprzeciwu wobec przetwarzania swoich danych osobowych</li> </ul> <p>&nbsp;</p> <h3>7. Pliki cookies</h3> <p>Sklep internetowy \"Smell it\" korzysta z plik&oacute;w cookies w celu umożliwienia korzystania z funkcjonalności sklepu oraz poprawy jakości świadczonych usług. Pliki cookies są małymi plikami tekstowymi przechowywanymi na urządzeniu końcowym użytkownika sklepu.</p> <p>Użytkownik może w każdej chwili zablokować lub usunąć pliki cookies za pomocą odpowiednich ustawień w przeglądarce internetowej.</p> <h3>8. Zmiany w Polityce Prywatności</h3> <p>Administrator zastrzega sobie prawo do dokonywania zmian w Polityce Prywatności w dowolnym czasie. Zmiany te będą publikowane na stronie internetowej sklepu.</p> <h3>9. Kontakt z Administratorem</h3> <p>W sprawach związanych z przetwarzaniem danych osobowych przez sklep internetowy \"Smell it\" należy skontaktować się z Administratorem danych osobowych za pomocą adresu e-mail info@smellit.com lub pisemnie na adres siedziby firmy.</p>"
            };
            await _dbContext.PrivacyPolicies.AddAsync(privacyPolicyTextPl);

            await _dbContext.SaveChangesAsync();
            var privacyPolicyList = await _dbContext.PrivacyPolicies.ToListAsync();
            foreach (var x in privacyPolicyList)
            {
                x.EncodeName();
                x.CreatedBy = _defaultAdmin;
            }
        }
    }

    private async Task SeedHomeBannersAsync()
    {
        if (!await _dbContext.HomeBanners.AnyAsync())
        {
            var homeBanner1 = new HomeBanner
            {
                Key = "HomeBanner1",
                ImagePath = "https://i.imgur.com/rJpL9Qr.jpg"
            };
            await _dbContext.HomeBanners.AddAsync(homeBanner1);

            List<HomeBannerTranslation> homeBanner1Translations = new()
        {
            new HomeBannerTranslation
            {
                HomeBanner = homeBanner1, Language = _polish,
                Text = "Zapachy do domu, które wytworzą przytulną atmosferę"
            },
            new HomeBannerTranslation
            {
                HomeBanner = homeBanner1, Language = _english,
                Text = "Home fragrances that will create a cozy atmosphere"
            },
        };
            homeBanner1.HomeBannerTranslations = homeBanner1Translations;
            await _dbContext.HomeBannerTranslations.AddRangeAsync(homeBanner1Translations);


            var homeBanner2 = new HomeBanner
            {
                Key = "HomeBanner2",
                ImagePath = "https://i.imgur.com/THroTSI.jpg"
            };
            await _dbContext.HomeBanners.AddAsync(homeBanner2);

            List<HomeBannerTranslation> homeBanner2Translations = new()
        {
            new HomeBannerTranslation
            {
                HomeBanner = homeBanner2, Language = _polish,
                Text = "Dior - SAUVAGE\noczaruje Cię już w chwili, gdy otworzysz flakon"
            },
            new HomeBannerTranslation
            {
                HomeBanner = homeBanner2, Language = _english,
                Text = "Dior - SAUVAGE\nwill captivate you from the moment you open the bottle"
            },
        };
            homeBanner2.HomeBannerTranslations = homeBanner2Translations;
            await _dbContext.HomeBannerTranslations.AddRangeAsync(homeBanner2Translations);


            var homeBanner3 = new HomeBanner
            {
                Key = "HomeBanner3",
                ImagePath = "https://i.imgur.com/3Cq8XuF.png"
            };
            await _dbContext.HomeBanners.AddAsync(homeBanner3);

            List<HomeBannerTranslation> homeBanner3Translations = new()
        {
            new HomeBannerTranslation
            {
                HomeBanner = homeBanner3, Language = _polish, Text = "Armani Si\nperfumy damskie, których nie zapomnisz"
            },
            new HomeBannerTranslation
                { HomeBanner = homeBanner3, Language = _english, Text = "Armani Si\nwomen's perfume, unforgettable" },
        };
            homeBanner3.HomeBannerTranslations = homeBanner3Translations;
            await _dbContext.HomeBannerTranslations.AddRangeAsync(homeBanner3Translations);


            var homeBanner4 = new HomeBanner
            {
                Key = "HomeBanner4",
                ImagePath = "https://i.imgur.com/SttTli5.jpg"
            };
            await _dbContext.HomeBanners.AddAsync(homeBanner4);

            List<HomeBannerTranslation> homeBanner4Translations = new()
        {
            new HomeBannerTranslation
                { HomeBanner = homeBanner4, Language = _polish, Text = "Poczuj każdy zapach nie wychodząc z domu" },
            new HomeBannerTranslation
            {
                HomeBanner = homeBanner4, Language = _english, Text = "Experience every scent without leaving your home"
            },
        };
            homeBanner4.HomeBannerTranslations = homeBanner4Translations;
            await _dbContext.HomeBannerTranslations.AddRangeAsync(homeBanner4Translations);

            await _dbContext.SaveChangesAsync();
            var homeBannerList = await _dbContext.HomeBanners.ToListAsync();
            foreach (var x in homeBannerList)
            {
                x.EncodeName();
                x.CreatedBy = _defaultAdmin;
            }
        }
    }

    private async Task SeedWebsiteTextsAsync()
    {
        if (!await _dbContext.WebsiteTexts.AnyAsync())
        {
            var phoneNumber = new WebsiteText { Key = "PhoneNumber" };
            await _dbContext.WebsiteTexts.AddAsync(phoneNumber);

            List<WebsiteTextTranslation> phoneNumberTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = phoneNumber, Language = _polish, Text = "+48 777 321 321" },
                new WebsiteTextTranslation { WebsiteText = phoneNumber, Language = _english, Text = "+48 777 321 321" },
            };
            phoneNumber.WebsiteTextTranslations = phoneNumberTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(phoneNumberTranslations);


            var emailSmellIt = new WebsiteText { Key = "EmailSmellIt" };
            await _dbContext.WebsiteTexts.AddAsync(emailSmellIt);

            List<WebsiteTextTranslation> emailSmellItTranslations = new()
            {
                new WebsiteTextTranslation
                    { WebsiteText = emailSmellIt, Language = _polish, Text = "info@smellit.com" },
                new WebsiteTextTranslation
                    { WebsiteText = emailSmellIt, Language = _english, Text = "info@smellit.com" },
            };
            emailSmellIt.WebsiteTextTranslations = emailSmellItTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(emailSmellItTranslations);


            var total = new WebsiteText { Key = "Total" };
            await _dbContext.WebsiteTexts.AddAsync(total);

            List<WebsiteTextTranslation> totalTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = total, Language = _polish, Text = "Razem" },
                new WebsiteTextTranslation { WebsiteText = total, Language = _english, Text = "Total" },
            };
            total.WebsiteTextTranslations = totalTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(totalTranslations);


            var cart = new WebsiteText { Key = "Cart" };
            await _dbContext.WebsiteTexts.AddAsync(cart);

            List<WebsiteTextTranslation> cartTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = cart, Language = _polish, Text = "Koszyk" },
                new WebsiteTextTranslation { WebsiteText = cart, Language = _english, Text = "Cart" },
            };
            cart.WebsiteTextTranslations = cartTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(cartTranslations);


            var checkout = new WebsiteText { Key = "Checkout" };
            await _dbContext.WebsiteTexts.AddAsync(checkout);

            List<WebsiteTextTranslation> checkoutTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = checkout, Language = _polish, Text = "Kasa" },
                new WebsiteTextTranslation { WebsiteText = checkout, Language = _english, Text = "Checkout" },
            };
            checkout.WebsiteTextTranslations = checkoutTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(checkoutTranslations);


            var delivery = new WebsiteText { Key = "Delivery" };
            await _dbContext.WebsiteTexts.AddAsync(delivery);

            List<WebsiteTextTranslation> deliveryTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = delivery, Language = _polish, Text = "Dostawa" },
                new WebsiteTextTranslation { WebsiteText = delivery, Language = _english, Text = "Delivery" },
            };
            delivery.WebsiteTextTranslations = deliveryTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(deliveryTranslations);


            var payment = new WebsiteText { Key = "Payment" };
            await _dbContext.WebsiteTexts.AddAsync(payment);

            List<WebsiteTextTranslation> paymentTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = payment, Language = _polish, Text = "Płatność" },
                new WebsiteTextTranslation { WebsiteText = payment, Language = _english, Text = "Payment" },
            };
            payment.WebsiteTextTranslations = paymentTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(paymentTranslations);


            var address = new WebsiteText { Key = "Address" };
            await _dbContext.WebsiteTexts.AddAsync(address);

            List<WebsiteTextTranslation> addressTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = address, Language = _polish, Text = "Adres" },
                new WebsiteTextTranslation { WebsiteText = address, Language = _english, Text = "Address" },
            };
            address.WebsiteTextTranslations = addressTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(addressTranslations);


            var firstLine = new WebsiteText { Key = "FirstLine" };
            await _dbContext.WebsiteTexts.AddAsync(firstLine);

            List<WebsiteTextTranslation> firstLineTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = firstLine, Language = _polish, Text = "Pierwsza linia" },
                new WebsiteTextTranslation { WebsiteText = firstLine, Language = _english, Text = "First Line" },
            };
            firstLine.WebsiteTextTranslations = firstLineTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(firstLineTranslations);


            var secondLine = new WebsiteText { Key = "SecondLine" };
            await _dbContext.WebsiteTexts.AddAsync(secondLine);

            List<WebsiteTextTranslation> secondLineTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = secondLine, Language = _polish, Text = "Druga linia" },
                new WebsiteTextTranslation { WebsiteText = secondLine, Language = _english, Text = "Second Line" },
            };
            secondLine.WebsiteTextTranslations = secondLineTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(secondLineTranslations);


            var postalCode = new WebsiteText { Key = "PostalCode" };
            await _dbContext.WebsiteTexts.AddAsync(postalCode);

            List<WebsiteTextTranslation> postalCodeTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = postalCode, Language = _polish, Text = "Kod pocztowy" },
                new WebsiteTextTranslation { WebsiteText = postalCode, Language = _english, Text = "Postal Code" },
            };
            postalCode.WebsiteTextTranslations = postalCodeTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(postalCodeTranslations);


            var city = new WebsiteText { Key = "City" };
            await _dbContext.WebsiteTexts.AddAsync(city);

            List<WebsiteTextTranslation> cityTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = city, Language = _polish, Text = "Miasto" },
                new WebsiteTextTranslation { WebsiteText = city, Language = _english, Text = "City" },
            };
            city.WebsiteTextTranslations = cityTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(cityTranslations);


            var country = new WebsiteText { Key = "Country" };
            await _dbContext.WebsiteTexts.AddAsync(country);

            List<WebsiteTextTranslation> countryTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = country, Language = _polish, Text = "Kraj" },
                new WebsiteTextTranslation { WebsiteText = country, Language = _english, Text = "Country" },
            };
            country.WebsiteTextTranslations = countryTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(countryTranslations);


            var phone = new WebsiteText { Key = "Phone" };
            await _dbContext.WebsiteTexts.AddAsync(phone);

            List<WebsiteTextTranslation> phoneTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = phone, Language = _polish, Text = "Telefon" },
                new WebsiteTextTranslation { WebsiteText = phone, Language = _english, Text = "Phone" },
            };
            phone.WebsiteTextTranslations = phoneTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(phoneTranslations);


            var orderSummary = new WebsiteText { Key = "OrderSummary" };
            await _dbContext.WebsiteTexts.AddAsync(orderSummary);

            List<WebsiteTextTranslation> orderSummaryTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = orderSummary, Language = _polish, Text = "Podsumowanie zamówienia" },
                new WebsiteTextTranslation { WebsiteText = orderSummary, Language = _english, Text = "Order Summary" },
            };
            orderSummary.WebsiteTextTranslations = orderSummaryTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(orderSummaryTranslations);


            var remove = new WebsiteText { Key = "Remove" };
            await _dbContext.WebsiteTexts.AddAsync(remove);

            List<WebsiteTextTranslation> removeTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = remove, Language = _polish, Text = "Usuń" },
                new WebsiteTextTranslation { WebsiteText = remove, Language = _english, Text = "Remove" },
            };
            remove.WebsiteTextTranslations = removeTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(removeTranslations);


            var placeOrder = new WebsiteText { Key = "PlaceOrder" };
            await _dbContext.WebsiteTexts.AddAsync(placeOrder);

            List<WebsiteTextTranslation> placeOrderTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = placeOrder, Language = _polish, Text = "Złóż zamówienie" },
                new WebsiteTextTranslation { WebsiteText = placeOrder, Language = _english, Text = "Place Order" },
            };
            placeOrder.WebsiteTextTranslations = placeOrderTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(placeOrderTranslations);


            var productsPrice = new WebsiteText { Key = "ProductsPrice" };
            await _dbContext.WebsiteTexts.AddAsync(productsPrice);

            List<WebsiteTextTranslation> productsPriceTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = productsPrice, Language = _polish, Text = "Cena produktów" },
                new WebsiteTextTranslation { WebsiteText = productsPrice, Language = _english, Text = "Products Price" },
            };
            productsPrice.WebsiteTextTranslations = productsPriceTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(productsPriceTranslations);


            var orderConfirmationTitle = new WebsiteText { Key = "OrderConfirmationTitle" };
            await _dbContext.WebsiteTexts.AddAsync(productsPrice);

            List<WebsiteTextTranslation> orderConfirmationTitleTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = orderConfirmationTitle, Language = _polish, Text = "Dziękujemy za zakupy w naszym sklepie" },
                new WebsiteTextTranslation { WebsiteText = orderConfirmationTitle, Language = _english, Text = "Thank you for shopping at our store" },
            };
            orderConfirmationTitle.WebsiteTextTranslations = orderConfirmationTitleTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(orderConfirmationTitleTranslations);


            var orderConfirmationText = new WebsiteText { Key = "OrderConfirmationText" };
            await _dbContext.WebsiteTexts.AddAsync(productsPrice);

            List<WebsiteTextTranslation> orderConfirmationTextTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = orderConfirmationText, Language = _polish, Text = "Twoje zamówienie zostało przyjęte do realizacji. W najbliższym czasie wyślemy Ci wiadomość z potwierdzeniem wysyłki wraz z numerem do śledzenia paczki. Mamy nadzieję, że nasze produkty przyniosą Ci wiele radości i zadowolenia" },
                new WebsiteTextTranslation { WebsiteText = orderConfirmationText, Language = _english, Text = "Your order has been accepted for processing. In the near future, we will send you a message with shipping confirmation along with a tracking number for your package. We hope that our products will bring you much joy and satisfaction" },
            };
            orderConfirmationText.WebsiteTextTranslations = orderConfirmationTextTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(orderConfirmationTextTranslations);


            var continueShopping = new WebsiteText { Key = "ContinueShopping" };
            await _dbContext.WebsiteTexts.AddAsync(continueShopping);

            List<WebsiteTextTranslation> continueShoppingTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = continueShopping, Language = _polish, Text = "Kontynuuj zakupy" },
                new WebsiteTextTranslation { WebsiteText = continueShopping, Language = _english, Text = "Continue Shopping" },
            };
            continueShopping.WebsiteTextTranslations = continueShoppingTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(continueShoppingTranslations);


            var myAccount = new WebsiteText { Key = "MyAccount" };
            await _dbContext.WebsiteTexts.AddAsync(myAccount);

            List<WebsiteTextTranslation> myAccountTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = myAccount, Language = _polish, Text = "Moje konto" },
                new WebsiteTextTranslation { WebsiteText = myAccount, Language = _english, Text = "My account" },
            };
            myAccount.WebsiteTextTranslations = myAccountTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(myAccountTranslations);


            var logout = new WebsiteText { Key = "Logout" };
            await _dbContext.WebsiteTexts.AddAsync(logout);

            List<WebsiteTextTranslation> logoutTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = logout, Language = _polish, Text = "Wyloguj" },
                new WebsiteTextTranslation { WebsiteText = logout, Language = _english, Text = "Logout" },
            };
            logout.WebsiteTextTranslations = logoutTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(logoutTranslations);


            var manage = new WebsiteText { Key = "Manage" };
            await _dbContext.WebsiteTexts.AddAsync(manage);

            List<WebsiteTextTranslation> manageTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = manage, Language = _polish, Text = "Zarządzaj" },
                new WebsiteTextTranslation { WebsiteText = manage, Language = _english, Text = "Manage" },
            };
            manage.WebsiteTextTranslations = manageTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(manageTranslations);


            var search = new WebsiteText { Key = "Search" };
            await _dbContext.WebsiteTexts.AddAsync(search);

            List<WebsiteTextTranslation> searchTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = search, Language = _polish, Text = "Szukaj" },
                new WebsiteTextTranslation { WebsiteText = search, Language = _english, Text = "Search" },
            };
            search.WebsiteTextTranslations = searchTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(searchTranslations);


            var home = new WebsiteText { Key = "Home" };
            await _dbContext.WebsiteTexts.AddAsync(home);

            List<WebsiteTextTranslation> homeTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = home, Language = _polish, Text = "Strona główna" },
                new WebsiteTextTranslation { WebsiteText = home, Language = _english, Text = "Home" },
            };
            home.WebsiteTextTranslations = homeTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(homeTranslations);


            var products = new WebsiteText { Key = "Products" };
            await _dbContext.WebsiteTexts.AddAsync(products);

            List<WebsiteTextTranslation> productsTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = products, Language = _polish, Text = "Produkty" },
                new WebsiteTextTranslation { WebsiteText = products, Language = _english, Text = "Products" },
            };
            products.WebsiteTextTranslations = productsTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(productsTranslations);


            var all = new WebsiteText { Key = "All" };
            await _dbContext.WebsiteTexts.AddAsync(all);

            List<WebsiteTextTranslation> allTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = all, Language = _polish, Text = "Wszystko" },
                new WebsiteTextTranslation { WebsiteText = all, Language = _english, Text = "All" },
            };
            all.WebsiteTextTranslations = allTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(allTranslations);


            var allProducts = new WebsiteText { Key = "AllProducts" };
            await _dbContext.WebsiteTexts.AddAsync(allProducts);

            List<WebsiteTextTranslation> allProductsTranslations = new()
            {
                new WebsiteTextTranslation
                    { WebsiteText = allProducts, Language = _polish, Text = "Wszystkie produkty" },
                new WebsiteTextTranslation { WebsiteText = allProducts, Language = _english, Text = "All Products" },
            };
            allProducts.WebsiteTextTranslations = allProductsTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(allProductsTranslations);


            var contact = new WebsiteText { Key = "Contact" };
            await _dbContext.WebsiteTexts.AddAsync(contact);

            List<WebsiteTextTranslation> contactTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = contact, Language = _polish, Text = "Kontakt" },
                new WebsiteTextTranslation { WebsiteText = contact, Language = _english, Text = "Contact" },
            };
            contact.WebsiteTextTranslations = contactTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(contactTranslations);


            var aboutUs = new WebsiteText { Key = "AboutUs" };
            await _dbContext.WebsiteTexts.AddAsync(aboutUs);

            List<WebsiteTextTranslation> aboutUsTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = aboutUs, Language = _polish, Text = "O nas" },
                new WebsiteTextTranslation { WebsiteText = aboutUs, Language = _english, Text = "About Us" },
            };
            aboutUs.WebsiteTextTranslations = aboutUsTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(aboutUsTranslations);


            var confirmPassword = new WebsiteText { Key = "ConfirmPassword" };
            await _dbContext.WebsiteTexts.AddAsync(confirmPassword);

            List<WebsiteTextTranslation> confirmPasswordTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = confirmPassword, Language = _polish, Text = "Potwierdź hasło" },
                new WebsiteTextTranslation { WebsiteText = confirmPassword, Language = _english, Text = "Confirm Password" },
            };
            confirmPassword.WebsiteTextTranslations = confirmPasswordTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(confirmPasswordTranslations);


            var password = new WebsiteText { Key = "Password" };
            await _dbContext.WebsiteTexts.AddAsync(password);

            List<WebsiteTextTranslation> passwordTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = password, Language = _polish, Text = "Hasło" },
                new WebsiteTextTranslation { WebsiteText = password, Language = _english, Text = "Password" },
            };
            password.WebsiteTextTranslations = passwordTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(passwordTranslations);


            var alreadyHaveAnAccount = new WebsiteText { Key = "AlreadyHaveAnAccount" };
            await _dbContext.WebsiteTexts.AddAsync(alreadyHaveAnAccount);

            List<WebsiteTextTranslation> alreadyHaveAnAccountTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = alreadyHaveAnAccount, Language = _polish, Text = "Masz już konto?" },
                new WebsiteTextTranslation { WebsiteText = alreadyHaveAnAccount, Language = _english, Text = "Already have an account?" },
            };
            alreadyHaveAnAccount.WebsiteTextTranslations = alreadyHaveAnAccountTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(alreadyHaveAnAccountTranslations);


            var forgotYourPassword = new WebsiteText { Key = "ForgotYourPassword" };
            await _dbContext.WebsiteTexts.AddAsync(forgotYourPassword);

            List<WebsiteTextTranslation> forgotYourPasswordTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = forgotYourPassword, Language = _polish, Text = "Zapomniałeś hasła?" },
                new WebsiteTextTranslation { WebsiteText = forgotYourPassword, Language = _english, Text = "Forgot your password?" },
            };
            forgotYourPassword.WebsiteTextTranslations = forgotYourPasswordTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(forgotYourPasswordTranslations);


            var backToLoginPage = new WebsiteText { Key = "BackToLoginPage" };
            await _dbContext.WebsiteTexts.AddAsync(backToLoginPage);

            List<WebsiteTextTranslation> backToLoginPageTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = backToLoginPage, Language = _polish, Text = "Powrót do strony logowania" },
                new WebsiteTextTranslation { WebsiteText = backToLoginPage, Language = _english, Text = "Back to login page" },
            };
            backToLoginPage.WebsiteTextTranslations = backToLoginPageTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(backToLoginPageTranslations);


            var welcomeBack = new WebsiteText { Key = "WelcomeBack" };
            await _dbContext.WebsiteTexts.AddAsync(welcomeBack);

            List<WebsiteTextTranslation> welcomeBackTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = welcomeBack, Language = _polish, Text = "Witaj ponownie" },
                new WebsiteTextTranslation { WebsiteText = welcomeBack, Language = _english, Text = "Welcome back" },
            };
            welcomeBack.WebsiteTextTranslations = welcomeBackTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(welcomeBackTranslations);


            var noAccountYet = new WebsiteText { Key = "NoAccountYet" };
            await _dbContext.WebsiteTexts.AddAsync(noAccountYet);

            List<WebsiteTextTranslation> noAccountYetTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = noAccountYet, Language = _polish, Text = "Nie masz jeszcze konta?" },
                new WebsiteTextTranslation { WebsiteText = noAccountYet, Language = _english, Text = "No account yet?" },
            };
            noAccountYet.WebsiteTextTranslations = noAccountYetTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(noAccountYetTranslations);


            var resetPassword = new WebsiteText { Key = "ResetPassword" };
            await _dbContext.WebsiteTexts.AddAsync(resetPassword);

            List<WebsiteTextTranslation> resetPasswordTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = resetPassword, Language = _polish, Text = "Zresetuj hasło" },
                new WebsiteTextTranslation { WebsiteText = resetPassword, Language = _english, Text = "Reset password" },
            };
            resetPassword.WebsiteTextTranslations = resetPasswordTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(resetPasswordTranslations);


            var signIn = new WebsiteText { Key = "SignIn" };
            await _dbContext.WebsiteTexts.AddAsync(signIn);

            List<WebsiteTextTranslation> signInTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = signIn, Language = _polish, Text = "Zaloguj się" },
                new WebsiteTextTranslation { WebsiteText = signIn, Language = _english, Text = "Sign in" },
            };
            signIn.WebsiteTextTranslations = signInTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(signInTranslations);


            var register = new WebsiteText { Key = "Register" };
            await _dbContext.WebsiteTexts.AddAsync(register);

            List<WebsiteTextTranslation> registerTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = register, Language = _polish, Text = "Zarejestruj się" },
                new WebsiteTextTranslation { WebsiteText = register, Language = _english, Text = "Register" },
            };
            register.WebsiteTextTranslations = registerTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(registerTranslations);


            var subscribeToNewsletter = new WebsiteText { Key = "SubscribeToNewsletter" };
            await _dbContext.WebsiteTexts.AddAsync(subscribeToNewsletter);

            List<WebsiteTextTranslation> subscribeToNewsletterTranslations = new()
            {
                new WebsiteTextTranslation
                    { WebsiteText = subscribeToNewsletter, Language = _polish, Text = "Zapisz się do newsletter'a" },
                new WebsiteTextTranslation
                    { WebsiteText = subscribeToNewsletter, Language = _english, Text = "Subscribe to Newsletter" },
            };
            subscribeToNewsletter.WebsiteTextTranslations = subscribeToNewsletterTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(subscribeToNewsletterTranslations);


            var subscribeToNewsletterDesc = new WebsiteText { Key = "SubscribeToNewsletterDesc" };
            await _dbContext.WebsiteTexts.AddAsync(subscribeToNewsletterDesc);

            List<WebsiteTextTranslation> subscribeToNewsletterDescTranslations = new()
            {
                new WebsiteTextTranslation
                {
                    WebsiteText = subscribeToNewsletterDesc, Language = _polish,
                    Text = "Jako pierwszy dowiesz się o najnowszych promocjach i produktach"
                },
                new WebsiteTextTranslation
                {
                    WebsiteText = subscribeToNewsletterDesc, Language = _english,
                    Text = "Be the first to find out about the latest promotions and products"
                },
            };
            subscribeToNewsletterDesc.WebsiteTextTranslations = subscribeToNewsletterDescTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(subscribeToNewsletterDescTranslations);


            var enterYourEmail = new WebsiteText { Key = "EnterYourEmail" };
            await _dbContext.WebsiteTexts.AddAsync(enterYourEmail);

            List<WebsiteTextTranslation> enterYourEmailTranslations = new()
            {
                new WebsiteTextTranslation
                    { WebsiteText = enterYourEmail, Language = _polish, Text = "Podaj swój adres e-mail" },
                new WebsiteTextTranslation
                    { WebsiteText = enterYourEmail, Language = _english, Text = "Enter your e-mail" },
            };
            enterYourEmail.WebsiteTextTranslations = enterYourEmailTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(enterYourEmailTranslations);


            var subscribeNow = new WebsiteText { Key = "SubscribeNow" };
            await _dbContext.WebsiteTexts.AddAsync(subscribeNow);

            List<WebsiteTextTranslation> subscribeNowTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = subscribeNow, Language = _polish, Text = "Subskrybuj!" },
                new WebsiteTextTranslation { WebsiteText = subscribeNow, Language = _english, Text = "Subscribe Now!" },
            };
            subscribeNow.WebsiteTextTranslations = subscribeNowTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(subscribeNowTranslations);


            var privacyPolicy = new WebsiteText { Key = "PrivacyPolicy" };
            await _dbContext.WebsiteTexts.AddAsync(privacyPolicy);

            List<WebsiteTextTranslation> privacyPolicyTranslations = new()
            {
                new WebsiteTextTranslation
                    { WebsiteText = privacyPolicy, Language = _polish, Text = "Polityka prywatności" },
                new WebsiteTextTranslation
                    { WebsiteText = privacyPolicy, Language = _english, Text = "Privacy Policy" },
            };
            privacyPolicy.WebsiteTextTranslations = privacyPolicyTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(privacyPolicyTranslations);


            var popularProducts = new WebsiteText { Key = "PopularProducts" };
            await _dbContext.WebsiteTexts.AddAsync(popularProducts);

            List<WebsiteTextTranslation> popularProductsTranslations = new()
            {
                new WebsiteTextTranslation
                    { WebsiteText = popularProducts, Language = _polish, Text = "Popularne produkty" },
                new WebsiteTextTranslation
                    { WebsiteText = popularProducts, Language = _english, Text = "Popular Products" },
            };
            popularProducts.WebsiteTextTranslations = popularProductsTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(popularProductsTranslations);


            var sortBy = new WebsiteText { Key = "SortBy" };
            await _dbContext.WebsiteTexts.AddAsync(sortBy);

            List<WebsiteTextTranslation> sortByTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = sortBy, Language = _polish, Text = "Sortuj według" },
                new WebsiteTextTranslation { WebsiteText = sortBy, Language = _english, Text = "Sort by" },
            };
            sortBy.WebsiteTextTranslations = sortByTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(sortByTranslations);


            var newest = new WebsiteText { Key = "Newest" };
            await _dbContext.WebsiteTexts.AddAsync(newest);

            List<WebsiteTextTranslation> newestTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = newest, Language = _polish, Text = "Najnowsze" },
                new WebsiteTextTranslation { WebsiteText = newest, Language = _english, Text = "Newest" },
            };
            newest.WebsiteTextTranslations = newestTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(newestTranslations);


            var oldest = new WebsiteText { Key = "Oldest" };
            await _dbContext.WebsiteTexts.AddAsync(oldest);

            List<WebsiteTextTranslation> oldestTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = oldest, Language = _polish, Text = "Najstarsze" },
                new WebsiteTextTranslation { WebsiteText = oldest, Language = _english, Text = "Oldest" },
            };
            oldest.WebsiteTextTranslations = oldestTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(oldestTranslations);


            var priceAscending = new WebsiteText { Key = "PriceAscending" };
            await _dbContext.WebsiteTexts.AddAsync(priceAscending);

            List<WebsiteTextTranslation> priceAscendingTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = priceAscending, Language = _polish, Text = "Cena rosnąco" },
                new WebsiteTextTranslation
                    { WebsiteText = priceAscending, Language = _english, Text = "Price ascending" },
            };
            priceAscending.WebsiteTextTranslations = priceAscendingTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(priceAscendingTranslations);


            var priceDescending = new WebsiteText { Key = "PriceDescending" };
            await _dbContext.WebsiteTexts.AddAsync(priceDescending);

            List<WebsiteTextTranslation> priceDescendingTranslations = new()
            {
                new WebsiteTextTranslation
                    { WebsiteText = priceDescending, Language = _polish, Text = "Cena malejąco" },
                new WebsiteTextTranslation
                    { WebsiteText = priceDescending, Language = _english, Text = "Price descending" },
            };
            priceDescending.WebsiteTextTranslations = priceDescendingTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(priceDescendingTranslations);


            var filters = new WebsiteText { Key = "Filters" };
            await _dbContext.WebsiteTexts.AddAsync(filters);

            List<WebsiteTextTranslation> filtersTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = filters, Language = _polish, Text = "Filtry" },
                new WebsiteTextTranslation { WebsiteText = filters, Language = _english, Text = "Filters" },
            };
            filters.WebsiteTextTranslations = filtersTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(filtersTranslations);


            var category = new WebsiteText { Key = "Category" };
            await _dbContext.WebsiteTexts.AddAsync(category);

            List<WebsiteTextTranslation> categoryTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = category, Language = _polish, Text = "Kategoria" },
                new WebsiteTextTranslation { WebsiteText = category, Language = _english, Text = "Category" },
            };
            category.WebsiteTextTranslations = categoryTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(categoryTranslations);


            var gender = new WebsiteText { Key = "Gender" };
            await _dbContext.WebsiteTexts.AddAsync(gender);

            List<WebsiteTextTranslation> genderTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = gender, Language = _polish, Text = "Płeć" },
                new WebsiteTextTranslation { WebsiteText = gender, Language = _english, Text = "Gender" },
            };
            gender.WebsiteTextTranslations = genderTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(genderTranslations);


            var brand = new WebsiteText { Key = "Brand" };
            await _dbContext.WebsiteTexts.AddAsync(brand);

            List<WebsiteTextTranslation> brandTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = brand, Language = _polish, Text = "Marka" },
                new WebsiteTextTranslation { WebsiteText = brand, Language = _english, Text = "Brand" },
            };
            brand.WebsiteTextTranslations = brandTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(brandTranslations);


            var clearAll = new WebsiteText { Key = "ClearAll" };
            await _dbContext.WebsiteTexts.AddAsync(clearAll);

            List<WebsiteTextTranslation> clearAllTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = clearAll, Language = _polish, Text = "Wyczyść wszystkie" },
                new WebsiteTextTranslation { WebsiteText = clearAll, Language = _english, Text = "Clear All" },
            };
            clearAll.WebsiteTextTranslations = clearAllTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(clearAllTranslations);


            var fragranceCategory = new WebsiteText { Key = "FragranceCategory" };
            await _dbContext.WebsiteTexts.AddAsync(fragranceCategory);

            List<WebsiteTextTranslation> fragranceCategoryTranslations = new()
            {
                new WebsiteTextTranslation
                    { WebsiteText = fragranceCategory, Language = _polish, Text = "Kategoria zapachu" },
                new WebsiteTextTranslation
                    { WebsiteText = fragranceCategory, Language = _english, Text = "Fragrance category" },
            };
            fragranceCategory.WebsiteTextTranslations = fragranceCategoryTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(fragranceCategoryTranslations);


            var addToCart = new WebsiteText { Key = "AddToCart" };
            await _dbContext.WebsiteTexts.AddAsync(addToCart);

            List<WebsiteTextTranslation> addToCartTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = addToCart, Language = _polish, Text = "Dodaj do koszyka" },
                new WebsiteTextTranslation { WebsiteText = addToCart, Language = _english, Text = "Add To Card" },
            };
            addToCart.WebsiteTextTranslations = addToCartTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(addToCartTranslations);


            var viewProductDetails = new WebsiteText { Key = "ViewProductDetails" };
            await _dbContext.WebsiteTexts.AddAsync(viewProductDetails);

            List<WebsiteTextTranslation> viewProductDetailsTranslations = new()
            {
                new WebsiteTextTranslation
                    { WebsiteText = viewProductDetails, Language = _polish, Text = "Zobacz szczegóły produktu" },
                new WebsiteTextTranslation
                    { WebsiteText = viewProductDetails, Language = _english, Text = "View Product Details" },
            };
            viewProductDetails.WebsiteTextTranslations = viewProductDetailsTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(viewProductDetailsTranslations);


            var quantity = new WebsiteText { Key = "Quantity" };
            await _dbContext.WebsiteTexts.AddAsync(quantity);

            List<WebsiteTextTranslation> quantityTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = quantity, Language = _polish, Text = "Ilość" },
                new WebsiteTextTranslation { WebsiteText = quantity, Language = _english, Text = "Quantity" },
            };
            quantity.WebsiteTextTranslations = quantityTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(quantityTranslations);


            var capacity = new WebsiteText { Key = "Capacity" };
            await _dbContext.WebsiteTexts.AddAsync(capacity);

            List<WebsiteTextTranslation> capacityTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = capacity, Language = _polish, Text = "Pojemność" },
                new WebsiteTextTranslation { WebsiteText = capacity, Language = _english, Text = "Capacity" },
            };
            capacity.WebsiteTextTranslations = capacityTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(capacityTranslations);


            var last30DaysLowestPrice = new WebsiteText { Key = "Last30DaysLowestPrice" };
            await _dbContext.WebsiteTexts.AddAsync(last30DaysLowestPrice);

            List<WebsiteTextTranslation> last30DaysLowestPriceTranslations = new()
            {
                new WebsiteTextTranslation
                {
                    WebsiteText = last30DaysLowestPrice, Language = _polish,
                    Text = "Najniższa cena w ciągu ostatnich 30 dni przed obniżką"
                },
                new WebsiteTextTranslation
                {
                    WebsiteText = last30DaysLowestPrice, Language = _english, Text = "Lowest price from last 30 days before reduction"
                },
            };
            last30DaysLowestPrice.WebsiteTextTranslations = last30DaysLowestPriceTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(last30DaysLowestPriceTranslations);


            var yourName = new WebsiteText { Key = "YourName" };
            await _dbContext.WebsiteTexts.AddAsync(yourName);

            List<WebsiteTextTranslation> yourNameTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = yourName, Language = _polish, Text = "Twoje imię" },
                new WebsiteTextTranslation { WebsiteText = yourName, Language = _english, Text = "Your name" },
            };
            yourName.WebsiteTextTranslations = yourNameTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(yourNameTranslations);


            var yourEmail = new WebsiteText { Key = "YourEmail" };
            await _dbContext.WebsiteTexts.AddAsync(yourEmail);

            List<WebsiteTextTranslation> yourEmailTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = yourEmail, Language = _polish, Text = "Twój email" },
                new WebsiteTextTranslation { WebsiteText = yourEmail, Language = _english, Text = "Your email" },
            };
            yourEmail.WebsiteTextTranslations = yourEmailTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(yourEmailTranslations);


            var subject = new WebsiteText { Key = "Subject" };
            await _dbContext.WebsiteTexts.AddAsync(subject);

            List<WebsiteTextTranslation> subjectTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = subject, Language = _polish, Text = "Temat" },
                new WebsiteTextTranslation { WebsiteText = subject, Language = _english, Text = "Subject" },
            };
            subject.WebsiteTextTranslations = subjectTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(subjectTranslations);


            var message = new WebsiteText { Key = "Message" };
            await _dbContext.WebsiteTexts.AddAsync(message);

            List<WebsiteTextTranslation> messageTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = message, Language = _polish, Text = "Wiadomość" },
                new WebsiteTextTranslation { WebsiteText = message, Language = _english, Text = "Message" },
            };
            message.WebsiteTextTranslations = messageTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(messageTranslations);


            var send = new WebsiteText { Key = "Send" };
            await _dbContext.WebsiteTexts.AddAsync(send);

            List<WebsiteTextTranslation> sendTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = send, Language = _polish, Text = "Wyślij" },
                new WebsiteTextTranslation { WebsiteText = send, Language = _english, Text = "Send" },
            };
            send.WebsiteTextTranslations = sendTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(sendTranslations);


            var thanksForMessage = new WebsiteText { Key = "ThanksForMessage" };
            await _dbContext.WebsiteTexts.AddAsync(thanksForMessage);

            List<WebsiteTextTranslation> thanksForMessageTranslations = new()
            {
                new WebsiteTextTranslation
                    { WebsiteText = thanksForMessage, Language = _polish, Text = "Dziękujemy za wiadomość!" },
                new WebsiteTextTranslation
                    { WebsiteText = thanksForMessage, Language = _english, Text = "Thanks for message!" },
            };
            thanksForMessage.WebsiteTextTranslations = thanksForMessageTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(thanksForMessageTranslations);


            var somethingWentWrong = new WebsiteText { Key = "SomethingWentWrong" };
            await _dbContext.WebsiteTexts.AddAsync(somethingWentWrong);

            List<WebsiteTextTranslation> somethingWentWrongTranslations = new()
            {
                new WebsiteTextTranslation
                    { WebsiteText = somethingWentWrong, Language = _polish, Text = "Coś poszło nie tak" },
                new WebsiteTextTranslation
                    { WebsiteText = somethingWentWrong, Language = _english, Text = "Something went wrong" },
            };
            somethingWentWrong.WebsiteTextTranslations = somethingWentWrongTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(somethingWentWrongTranslations);


            var smellItAddress = new WebsiteText { Key = "SmellItAddress" };
            await _dbContext.WebsiteTexts.AddAsync(smellItAddress);

            List<WebsiteTextTranslation> smellItAddressTranslations = new()
            {
                new WebsiteTextTranslation
                    { WebsiteText = smellItAddress, Language = _polish, Text = "Floriańska 1, 31-019 Kraków" },
                new WebsiteTextTranslation
                    { WebsiteText = smellItAddress, Language = _english, Text = "Florianska 1, 31-019 Cracow" },
            };
            smellItAddress.WebsiteTextTranslations = smellItAddressTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(smellItAddressTranslations);


            var seeNow = new WebsiteText { Key = "SeeNow" };
            await _dbContext.WebsiteTexts.AddAsync(seeNow);

            List<WebsiteTextTranslation> seeNowTranslations = new()
            {
                new WebsiteTextTranslation { WebsiteText = seeNow, Language = _polish, Text = "Zobacz teraz" },
                new WebsiteTextTranslation { WebsiteText = seeNow, Language = _english, Text = "See now" },
            };
            seeNow.WebsiteTextTranslations = seeNowTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(seeNowTranslations);


            var privacyTitle = new WebsiteText { Key = "PrivacyTitle" };
            await _dbContext.WebsiteTexts.AddAsync(privacyTitle);

            List<WebsiteTextTranslation> privacyTitleTranslations = new()
            {
                new WebsiteTextTranslation
                {
                    WebsiteText = privacyTitle, Language = _polish,
                    Text = "Polityka prywatności sklepu internetowego \"Smell it\""
                },
                new WebsiteTextTranslation
                {
                    WebsiteText = privacyTitle, Language = _english,
                    Text = "Privacy Policy of the online store \"Smell it\""
                },
            };
            privacyTitle.WebsiteTextTranslations = privacyTitleTranslations;
            await _dbContext.WebsiteTextTranslations.AddRangeAsync(privacyTitleTranslations);

            await _dbContext.SaveChangesAsync();
            var websiteTextList = await _dbContext.WebsiteTexts.ToListAsync();
            foreach (var x in websiteTextList)
            {
                x.EncodeName();
                x.CreatedBy = _defaultAdmin;
            }
        }
    }

    private async Task SeedProductsAsync()
    {
        if (!await _dbContext.Products.AnyAsync())
        {
            #region ProductCategories

            var devices = new ProductCategory();
            await _dbContext.ProductCategories.AddAsync(devices);

            List<ProductCategoryTranslation> devicesTranslations = new()
            {
                new ProductCategoryTranslation { ProductCategory = devices, Language = _polish, Name = "Urządzenia" },
                new ProductCategoryTranslation { ProductCategory = devices, Language = _english, Name = "Devices" },
            };
            devices.ProductCategoryTranslations = devicesTranslations;
            await _dbContext.ProductCategoryTranslations.AddRangeAsync(devicesTranslations);


            var fragrance = new ProductCategory();
            await _dbContext.ProductCategories.AddAsync(fragrance);

            List<ProductCategoryTranslation> fragranceTranslations = new()
            {
                new ProductCategoryTranslation { ProductCategory = fragrance, Language = _polish, Name = "Perfumy" },
                new ProductCategoryTranslation { ProductCategory = fragrance, Language = _english, Name = "Fragrance" },
            };

            fragrance.ProductCategoryTranslations = fragranceTranslations;
            await _dbContext.ProductCategoryTranslations.AddRangeAsync(fragranceTranslations);


            var parfum = new ProductCategory { ParentCategory = fragrance };
            await _dbContext.ProductCategories.AddAsync(parfum);

            List<ProductCategoryTranslation> parfumTranslations = new()
            {
                new ProductCategoryTranslation { ProductCategory = parfum, Language = _polish, Name = "Parfum" },
                new ProductCategoryTranslation { ProductCategory = parfum, Language = _english, Name = "Parfum" },
            };

            parfum.ProductCategoryTranslations = parfumTranslations;
            await _dbContext.ProductCategoryTranslations.AddRangeAsync(parfumTranslations);


            var eauDeParfum = new ProductCategory { ParentCategory = fragrance };
            await _dbContext.ProductCategories.AddAsync(eauDeParfum);

            List<ProductCategoryTranslation> eauDeParfumTranslations = new()
            {
                new ProductCategoryTranslation
                    { ProductCategory = eauDeParfum, Language = _polish, Name = "Eau de Parfum" },
                new ProductCategoryTranslation
                    { ProductCategory = eauDeParfum, Language = _english, Name = "Eau de Parfum" },
            };

            eauDeParfum.ProductCategoryTranslations = eauDeParfumTranslations;
            await _dbContext.ProductCategoryTranslations.AddRangeAsync(eauDeParfumTranslations);


            var eauDeToilette = new ProductCategory { ParentCategory = fragrance };
            await _dbContext.ProductCategories.AddAsync(eauDeToilette);

            List<ProductCategoryTranslation> eauDeToiletteTranslations = new()
            {
                new ProductCategoryTranslation
                    { ProductCategory = eauDeToilette, Language = _polish, Name = "Eau de Toilette" },
                new ProductCategoryTranslation
                    { ProductCategory = eauDeToilette, Language = _english, Name = "Eau de Toilette" },
            };

            eauDeToilette.ProductCategoryTranslations = eauDeToiletteTranslations;
            await _dbContext.ProductCategoryTranslations.AddRangeAsync(eauDeToiletteTranslations);


            var eauDeCologne = new ProductCategory { ParentCategory = fragrance };
            await _dbContext.ProductCategories.AddAsync(eauDeCologne);

            List<ProductCategoryTranslation> eauDeCologneTranslations = new()
            {
                new ProductCategoryTranslation
                    { ProductCategory = eauDeCologne, Language = _polish, Name = "Eau de Cologne" },
                new ProductCategoryTranslation
                    { ProductCategory = eauDeCologne, Language = _english, Name = "Eau de Cologne" },
            };

            eauDeCologne.ProductCategoryTranslations = eauDeCologneTranslations;
            await _dbContext.ProductCategoryTranslations.AddRangeAsync(eauDeCologneTranslations);


            var homeFragrance = new ProductCategory();
            await _dbContext.ProductCategories.AddAsync(homeFragrance);

            List<ProductCategoryTranslation> homeFragranceTranslations = new()
            {
                new ProductCategoryTranslation
                    { ProductCategory = homeFragrance, Language = _polish, Name = "Zapachy do domu" },
                new ProductCategoryTranslation
                    { ProductCategory = homeFragrance, Language = _english, Name = "Home fragrances" },
            };
            homeFragrance.ProductCategoryTranslations = homeFragranceTranslations;
            await _dbContext.ProductCategoryTranslations.AddRangeAsync(homeFragranceTranslations);


            var others = new ProductCategory();
            await _dbContext.ProductCategories.AddAsync(others);

            List<ProductCategoryTranslation> othersTranslations = new()
            {
                new ProductCategoryTranslation { ProductCategory = others, Language = _polish, Name = "Inne" },
                new ProductCategoryTranslation { ProductCategory = others, Language = _english, Name = "Others" },
            };
            others.ProductCategoryTranslations = othersTranslations;
            await _dbContext.ProductCategoryTranslations.AddRangeAsync(othersTranslations);


            var diffusers = new ProductCategory { ParentCategory = devices };
            await _dbContext.ProductCategories.AddAsync(diffusers);

            List<ProductCategoryTranslation> diffusersTranslations = new()
            {
                new ProductCategoryTranslation { ProductCategory = diffusers, Language = _polish, Name = "Dyfuzory" },
                new ProductCategoryTranslation { ProductCategory = diffusers, Language = _english, Name = "Diffusers" },
            };
            diffusers.ProductCategoryTranslations = diffusersTranslations;
            await _dbContext.ProductCategoryTranslations.AddRangeAsync(diffusersTranslations);


            var fresheners = new ProductCategory { ParentCategory = devices };
            await _dbContext.ProductCategories.AddAsync(fresheners);

            List<ProductCategoryTranslation> freshenersTranslations = new()
            {
                new ProductCategoryTranslation
                    { ProductCategory = fresheners, Language = _polish, Name = "Odświeżacze powietrza" },
                new ProductCategoryTranslation
                    { ProductCategory = fresheners, Language = _english, Name = "Fresheners" },
            };
            fresheners.ProductCategoryTranslations = freshenersTranslations;
            await _dbContext.ProductCategoryTranslations.AddRangeAsync(freshenersTranslations);


            var scentedCandles = new ProductCategory { ParentCategory = homeFragrance };
            await _dbContext.ProductCategories.AddAsync(scentedCandles);

            List<ProductCategoryTranslation> scentedCandlesTranslations = new()
            {
                new ProductCategoryTranslation
                    { ProductCategory = scentedCandles, Language = _polish, Name = "Świeczki zapachowe" },
                new ProductCategoryTranslation
                    { ProductCategory = scentedCandles, Language = _english, Name = "Scented candles" },
            };
            scentedCandles.ProductCategoryTranslations = scentedCandlesTranslations;
            await _dbContext.ProductCategoryTranslations.AddRangeAsync(scentedCandlesTranslations);


            var essentialOils = new ProductCategory { ParentCategory = homeFragrance };
            await _dbContext.ProductCategories.AddAsync(essentialOils);

            List<ProductCategoryTranslation> essentialOilsTranslations = new()
            {
                new ProductCategoryTranslation
                    { ProductCategory = essentialOils, Language = _polish, Name = "Olejki zapachowe" },
                new ProductCategoryTranslation
                    { ProductCategory = essentialOils, Language = _english, Name = "Essential oils" },
            };
            essentialOils.ProductCategoryTranslations = essentialOilsTranslations;
            await _dbContext.ProductCategoryTranslations.AddRangeAsync(essentialOilsTranslations);


            var carFresheners = new ProductCategory { ParentCategory = others };
            await _dbContext.ProductCategories.AddAsync(carFresheners);

            List<ProductCategoryTranslation> carFreshenersTranslations = new()
            {
                new ProductCategoryTranslation
                    { ProductCategory = carFresheners, Language = _polish, Name = "Odświeżacze do samochodu" },
                new ProductCategoryTranslation
                    { ProductCategory = carFresheners, Language = _english, Name = "Car fresheners" },
            };
            carFresheners.ProductCategoryTranslations = carFreshenersTranslations;
            await _dbContext.ProductCategoryTranslations.AddRangeAsync(carFreshenersTranslations);

            await _dbContext.SaveChangesAsync();
            var productCategoryList = await _dbContext.ProductCategories.ToListAsync();
            foreach (var x in productCategoryList)
            {
                x.EncodeName();
                x.CreatedBy = _defaultAdmin;
            }

            #endregion

            #region Brands

            var smellIt = new Brand { Name = "Smell it" };
            List<BrandTranslation> smellItTranslations = new()
            {
                new BrandTranslation
                {
                    Brand = smellIt, Language = _polish,
                    Description =
                        "Nowatorska firma, która zasłynęła z wypuszczenia na rynek produktu Smell It Diffuser, który potrafi imitować zapachy, wystarczy tylko połączyć to urządzenie z komputerem lub smartfonem, mieć uzupełnione aromaty w urządzeniu i wybrać zapach, który chce się poczuć."
                },
                new BrandTranslation
                {
                    Brand = smellIt, Language = _english,
                    Description =
                        "Innovative company, which became famous for releasing the product Smell It Diffuser on the market, capable of imitating scents, you just need to connect this device to a computer or smartphone, have the fragrances refilled in the device, and choose the scent you want to experience."
                },
            };
            smellIt.BrandTranslations = smellItTranslations;
            await _dbContext.Brands.AddAsync(smellIt);
            await _dbContext.BrandTranslations.AddRangeAsync(smellItTranslations);


            var carolinaHerrera = new Brand { Name = "Carolina Herrera" };
            List<BrandTranslation> carolinaHerreraTranslations = new()
            {
                new BrandTranslation
                {
                    Brand = carolinaHerrera, Language = _polish,
                    Description =
                        "Perfumy Carolina Herrera to linia luksusowych zapachów dla kobiet i mężczyzn. Firma oferuje wiele różnych kompozycji, które są cenione za swoją oryginalność, elegancję i trwałość. Wśród najpopularniejszych zapachów marki znajdują się: \"Good Girl\", \"212\", \"CH\", \"Bad Boy\" oraz \"Very Good Girl\". Każdy zapach jest starannie opracowany i skomponowany z wykorzystaniem najwyższej jakości składników, co czyni go unikalnym i niepowtarzalnym. Carolina Herrera zapachy są bardzo rozpoznawalne dzięki swoim charakterystycznym flakonom w kształcie butów lub kapsli."
                },
                new BrandTranslation
                {
                    Brand = carolinaHerrera, Language = _english,
                    Description =
                        "Carolina Herrera perfumes are a line of luxury fragrances for women and men. The company offers many different compositions that are valued for their originality, elegance, and longevity. Among the most popular scents of the brand are \"Good Girl,\" \"212,\" \"CH,\" \"Bad Boy,\" and \"Very Good Girl.\" Each fragrance is carefully developed and composed using the highest quality ingredients, making it unique and unparalleled. Carolina Herrera perfumes are highly recognizable thanks to their distinctive shoe or capsule-shaped bottles."
                },
            };
            carolinaHerrera.BrandTranslations = carolinaHerreraTranslations;
            await _dbContext.Brands.AddAsync(smellIt);
            await _dbContext.BrandTranslations.AddRangeAsync(carolinaHerreraTranslations);



            var dior = new Brand { Name = "Dior" };
            List<BrandTranslation> diorTranslations = new()
            {
                new BrandTranslation
                {
                    Brand = dior, Language = _polish,
                    Description =
                        "Dior to luksusowa marka perfum, która oferuje wiele różnych zapachów dla kobiet i mężczyzn. Wśród najpopularniejszych zapachów marki są \"J'adore\", \"Miss Dior\", \"Sauvage\", \"Poison\", \"Hypnotic Poison\" i \"Fahrenheit\". Perfumy Dior wyróżniają się eleganckimi i zmysłowymi kompozycjami zapachowymi, które zawierają najwyższej jakości składniki. Flakony zapachów są zwykle proste, eleganckie i nowoczesne, odzwierciedlając francuski styl i klasykę. Zapachy Dior są cenione za swoją wyjątkowość, jakość i trwałość."
                },
                new BrandTranslation
                {
                    Brand = dior, Language = _english,
                    Description =
                        "Dior is a luxury perfume brand that offers many different fragrances for women and men. Among the most popular scents are \"J'adore\", \"Miss Dior\", \"Sauvage\", \"Poison\", \"Hypnotic Poison\", and \"Fahrenheit\". Dior perfumes stand out for their elegant and sensual fragrance compositions that contain the highest quality ingredients. The fragrance bottles are usually simple, elegant, and modern, reflecting French style and classicism. Dior fragrances are valued for their uniqueness, quality, and longevity."
                },
            };
            dior.BrandTranslations = diorTranslations;
            await _dbContext.Brands.AddAsync(dior);
            await _dbContext.BrandTranslations.AddRangeAsync(diorTranslations);


            var giorgioArmani = new Brand { Name = "Giorgio Armani" };
            List<BrandTranslation> giorgioArmaniTranslations = new()
            {
                new BrandTranslation
                {
                    Brand = giorgioArmani, Language = _polish,
                    Description =
                        "Giorgio Armani to marka, która oferuje luksusowe perfumy dla kobiet i mężczyzn. W ofercie znajduje się wiele różnych zapachów, które są cenione za swoją jakość, elegancję i oryginalność. Wśród najpopularniejszych zapachów marki znajdują się: \"Acqua di Gio\", \"Armani Code\", \"Si\", \"Emporio Armani Stronger With You\", oraz \"Armani Privé Rose d'Arabie\". Perfumy Giorgio Armani są skomponowane z najwyższej jakości składników, dzięki czemu zapachy są trwałe i intensywne. Flakony perfum są zwykle proste, eleganckie i modne, nawiązujące do charakterystycznego minimalizmu marki."
                },
                new BrandTranslation
                {
                    Brand = giorgioArmani, Language = _english,
                    Description =
                        "Giorgio Armani is a brand that offers luxury perfumes for women and men. The brand offers many different scents that are valued for their quality, elegance, and originality. Among the most popular scents of the brand are \"Acqua di Gio,\" \"Armani Code,\" \"Si,\" \"Emporio Armani Stronger With You,\" and \"Armani Privé Rose d'Arabie.\" Giorgio Armani perfumes are composed of the highest quality ingredients, making the scents long-lasting and intense. The perfume bottles are usually simple, elegant, and fashionable, reflecting the brand's characteristic minimalism."
                },
            };
            giorgioArmani.BrandTranslations = giorgioArmaniTranslations;
            await _dbContext.Brands.AddAsync(giorgioArmani);
            await _dbContext.BrandTranslations.AddRangeAsync(giorgioArmaniTranslations);


            var pacoRabanne = new Brand { Name = "Paco Rabanne" };
            List<BrandTranslation> pacoRabanneTranslations = new()
            {
                new BrandTranslation
                {
                    Brand = pacoRabanne, Language = _polish,
                    Description =
                        "Paco Rabanne to marka luksusowych perfum dla kobiet i mężczyzn, która oferuje wiele różnych zapachów. Najbardziej popularnymi zapachami marki są \"1 Million\", \"Lady Million\", \"Invictus\" i \"Olympéa\". Perfumy Paco Rabanne wyróżniają się zmysłowymi i intrygującymi kompozycjami, które są skomponowane z najwyższej jakości składników. Flakony perfum są często awangardowe, nowoczesne i oryginalne, nawiązujące do charakterystycznego stylu marki. Perfumy Paco Rabanne są cenione za swoją wyjątkowość, jakość i trwałość."
                },
                new BrandTranslation
                {
                    Brand = pacoRabanne, Language = _english,
                    Description =
                        "Paco Rabanne is a luxury perfume brand for women and men that offers many different fragrances. The most popular scents of the brand are \"1 Million,\" \"Lady Million,\" \"Invictus,\" and \"Olympéa.\" Paco Rabanne perfumes stand out with sensual and intriguing compositions that are composed of the highest quality ingredients. The perfume bottles are often avant-garde, modern, and original, reflecting the brand's characteristic style. Paco Rabanne perfumes are valued for their uniqueness, quality, and longevity."
                },
            };
            pacoRabanne.BrandTranslations = pacoRabanneTranslations;
            await _dbContext.Brands.AddAsync(pacoRabanne);
            await _dbContext.BrandTranslations.AddRangeAsync(pacoRabanneTranslations);


            var versace = new Brand { Name = "Versace" };
            List<BrandTranslation> versaceTranslations = new()
            {
                new BrandTranslation
                {
                    Brand = versace, Language = _polish,
                    Description =
                        "Versace to marka luksusowych perfum dla kobiet i mężczyzn, która oferuje wiele różnych zapachów. Wśród najbardziej popularnych zapachów marki znajdują się \"Bright Crystal\", \"Eros\", \"Dylan Blue\", \"Versace Pour Homme\", \"Yellow Diamond\" i \"Versace Man Eau Fraîche\". Perfumy Versace wyróżniają się zmysłowymi i niezwykle intensywnymi kompozycjami, które są skomponowane z najwyższej jakości składników. Flakony perfum są często ozdobione charakterystycznymi wzorami, nawiązującymi do stylu i estetyki marki. Perfumy Versace są cenione za swoją wyjątkowość, jakość i trwałość."
                },
                new BrandTranslation
                {
                    Brand = versace, Language = _english,
                    Description =
                        "Versace is a luxury perfume brand for women and men that offers many different fragrances. Among the most popular scents of the brand are \"Bright Crystal,\" \"Eros,\" \"Dylan Blue,\" \"Versace Pour Homme,\" \"Yellow Diamond,\" and \"Versace Man Eau Fraîche.\" Versace perfumes stand out with sensual and extremely intense compositions that are composed of the highest quality ingredients. The perfume bottles are often adorned with characteristic patterns, reflecting the brand's style and aesthetics. Versace perfumes are valued for their uniqueness, quality, and longevity."
                },
            };
            versace.BrandTranslations = versaceTranslations;
            await _dbContext.Brands.AddAsync(versace);
            await _dbContext.BrandTranslations.AddRangeAsync(versaceTranslations);


            var yvesSaintLaurent = new Brand { Name = "Yves Saint Laurent" };
            List<BrandTranslation> yvesSaintLaurentTranslations = new()
            {
                new BrandTranslation
                {
                    Brand = yvesSaintLaurent, Language = _polish,
                    Description =
                        "Yves Saint Laurent to marka luksusowych perfum dla kobiet i mężczyzn, która oferuje wiele różnych zapachów. Wśród najbardziej popularnych zapachów marki znajdują się \"Opium\", \"Black Opium\", \"Y\", \"L'Homme\", \"La Nuit de L'Homme\" i \"Mon Paris\". Perfumy Yves Saint Laurent wyróżniają się eleganckimi i zmysłowymi kompozycjami, które są skomponowane z najwyższej jakości składników. Flakony perfum są często proste, eleganckie i nowoczesne, nawiązujące do francuskiego stylu i klasyki. Perfumy Yves Saint Laurent są cenione za swoją wyjątkowość, jakość i trwałość."
                },
                new BrandTranslation
                {
                    Brand = yvesSaintLaurent, Language = _english,
                    Description =
                        "Yves Saint Laurent is a luxury perfume brand for women and men that offers many different fragrances. Among the most popular scents of the brand are \"Opium,\" \"Black Opium,\" \"Y,\" \"L'Homme,\" \"La Nuit de L'Homme,\" and \"Mon Paris.\" Yves Saint Laurent perfumes stand out with elegant and sensual compositions that are composed of the highest quality ingredients. The perfume bottles are often simple, elegant, and modern, reflecting French style and classicism. Yves Saint Laurent perfumes are valued for their uniqueness, quality, and longevity."
                },
            };
            yvesSaintLaurent.BrandTranslations = yvesSaintLaurentTranslations;
            await _dbContext.Brands.AddAsync(yvesSaintLaurent);
            await _dbContext.BrandTranslations.AddRangeAsync(yvesSaintLaurentTranslations);

            await _dbContext.SaveChangesAsync();
            var brandList = await _dbContext.Brands.ToListAsync();
            foreach (var x in brandList)
            {
                x.EncodeName();
                x.CreatedBy = _defaultAdmin;
            }

            #endregion

            #region FragranceCategories

            var aromatic = new FragranceCategory();
            await _dbContext.FragranceCategories.AddAsync(aromatic);

            List<FragranceCategoryTranslation> aromaticTranslations = new()
            {
                new FragranceCategoryTranslation
                {
                    FragranceCategory = aromatic, Language = _polish, Name = "Aromatyczne",
                    Description =
                        "Perfumy aromatyczne charakteryzują się zapachami ziołowymi i drzewnymi. Najczęściej zawierają nuty takie jak rozmaryn, kolendra, mięta, drzewo sandałowe i cedr. Są one często stosowane w zapachach dla mężczyzn."
                },
                new FragranceCategoryTranslation
                {
                    FragranceCategory = aromatic, Language = _english, Name = "Aromatic",
                    Description =
                        "Aromatic perfumes are characterized by herbal and woody scents. They often contain notes such as rosemary, coriander, mint, sandalwood, and cedar. They are commonly used in men's fragrances."
                },
            };
            aromatic.FragranceCategoryTranslations = aromaticTranslations;
            await _dbContext.FragranceCategoryTranslations.AddRangeAsync(aromaticTranslations);


            var citrus = new FragranceCategory();
            await _dbContext.FragranceCategories.AddAsync(citrus);

            List<FragranceCategoryTranslation> citrusTranslations = new()
            {
                new FragranceCategoryTranslation
                {
                    FragranceCategory = citrus, Language = _polish, Name = "Cytrusowe",
                    Description =
                        "Perfumy cytrusowe charakteryzują się orzeźwiającymi i energicznymi zapachami, które zawierają nuty takie jak pomarańcza, cytryna, bergamotka i grejpfrut. Są one często stosowane w zapachach letnich i sportowych."
                },
                new FragranceCategoryTranslation
                {
                    FragranceCategory = citrus, Language = _english, Name = "Citrus",
                    Description =
                        "Citrus perfumes are characterized by refreshing and energetic scents that contain notes such as orange, lemon, bergamot, and grapefruit. They are commonly used in summer and sports fragrances."
                },
            };
            citrus.FragranceCategoryTranslations = citrusTranslations;
            await _dbContext.FragranceCategoryTranslations.AddRangeAsync(citrusTranslations);


            var floral = new FragranceCategory();
            await _dbContext.FragranceCategories.AddAsync(floral);

            List<FragranceCategoryTranslation> floralTranslations = new()
            {
                new FragranceCategoryTranslation
                {
                    FragranceCategory = floral, Language = _polish, Name = "Kwiatowe",
                    Description =
                        "Perfumy kwiatowe charakteryzują się słodkimi i romantycznymi zapachami, które zawierają nuty takie jak róża, jaśmin, fiołek, piwonia i magnolia. Są one często stosowane w zapachach dla kobiet."
                },
                new FragranceCategoryTranslation
                {
                    FragranceCategory = floral, Language = _english, Name = "Floral",
                    Description =
                        "Floral perfumes are characterized by sweet and romantic scents that contain notes such as rose, jasmine, violet, peony, and magnolia. They are commonly used in women's fragrances."
                },
            };
            floral.FragranceCategoryTranslations = floralTranslations;
            await _dbContext.FragranceCategoryTranslations.AddRangeAsync(floralTranslations);


            var fruity = new FragranceCategory();
            await _dbContext.FragranceCategories.AddAsync(fruity);

            List<FragranceCategoryTranslation> fruityTranslations = new()
            {
                new FragranceCategoryTranslation
                {
                    FragranceCategory = fruity, Language = _polish, Name = "Owocowe",
                    Description =
                        "Perfumy owocowe charakteryzują się słodkimi i soczystymi zapachami, które zawierają nuty takie jak truskawka, malina, brzoskwinia, gruszka i jabłko. Są one często stosowane w zapachach letnich i na co dzień."
                },
                new FragranceCategoryTranslation
                {
                    FragranceCategory = fruity, Language = _english, Name = "Fruity",
                    Description =
                        "Fruity perfumes are characterized by sweet and juicy scents that contain notes such as strawberry, raspberry, peach, pear, and apple. They are commonly used in summer and everyday fragrances."
                },
            };
            fruity.FragranceCategoryTranslations = fruityTranslations;
            await _dbContext.FragranceCategoryTranslations.AddRangeAsync(fruityTranslations);


            var oriental = new FragranceCategory();
            await _dbContext.FragranceCategories.AddAsync(oriental);

            List<FragranceCategoryTranslation> orientalTranslations = new()
            {
                new FragranceCategoryTranslation
                {
                    FragranceCategory = oriental, Language = _polish, Name = "Orientalne",
                    Description =
                        "Perfumy orientalne charakteryzują się zmysłowymi i intensywnymi zapachami, które zawierają nuty takie jak wanilia, paczula, kardamon, goździk i drzewo sandałowe. Są one często stosowane w zapachach wieczorowych i na specjalne okazje."
                },
                new FragranceCategoryTranslation
                {
                    FragranceCategory = oriental, Language = _english, Name = "Oriental",
                    Description =
                        "Oriental perfumes are characterized by sensual and intense scents that contain notes such as vanilla, patchouli, cardamom, clove, and sandalwood. They are commonly used in evening and special occasion fragrances."
                },
            };
            oriental.FragranceCategoryTranslations = orientalTranslations;
            await _dbContext.FragranceCategoryTranslations.AddRangeAsync(orientalTranslations);


            var other = new FragranceCategory();
            await _dbContext.FragranceCategories.AddAsync(other);

            List<FragranceCategoryTranslation> otherTranslations = new()
            {
                new FragranceCategoryTranslation { FragranceCategory = other, Language = _polish, Name = "Inne" },
                new FragranceCategoryTranslation { FragranceCategory = other, Language = _english, Name = "Other" },
            };
            other.FragranceCategoryTranslations = otherTranslations;
            await _dbContext.FragranceCategoryTranslations.AddRangeAsync(otherTranslations);


            var spicy = new FragranceCategory();
            await _dbContext.FragranceCategories.AddAsync(spicy);

            List<FragranceCategoryTranslation> spicyTranslations = new()
            {
                new FragranceCategoryTranslation
                {
                    FragranceCategory = spicy, Language = _polish, Name = "Ostre",
                    Description =
                        "Perfumy ostre charakteryzują się mocnymi i intensywnymi zapachami, które zawierają nuty takie jak pieprz, imbir, cynamon, anyż i gałka muszkatołowa. Są one często stosowane w zapachach dla mężczyzn."
                },
                new FragranceCategoryTranslation
                {
                    FragranceCategory = spicy, Language = _english, Name = "Spicy",
                    Description =
                        "Spicy perfumes are characterized by strong and intense scents that contain notes such as pepper, ginger, cinnamon, anise, and nutmeg. They are commonly used in men's fragrances."
                },
            };
            spicy.FragranceCategoryTranslations = spicyTranslations;
            await _dbContext.FragranceCategoryTranslations.AddRangeAsync(spicyTranslations);

            await _dbContext.SaveChangesAsync();
            var fragranceCategoryList = await _dbContext.FragranceCategories.ToListAsync();
            foreach (var x in fragranceCategoryList)
            {
                x.EncodeName();
                x.CreatedBy = _defaultAdmin;
            }

            #endregion

            #region Genders

            var men = new Gender();
            await _dbContext.Genders.AddAsync(men);

            List<GenderTranslation> menTranslations = new()
            {
                new GenderTranslation { Gender = men, Language = _polish, Name = "Męskie" },
                new GenderTranslation { Gender = men, Language = _english, Name = "Men" },
            };
            men.GenderTranslations = menTranslations;
            await _dbContext.GenderTranslations.AddRangeAsync(menTranslations);


            var women = new Gender();
            await _dbContext.Genders.AddAsync(women);

            List<GenderTranslation> womenTranslations = new()
            {
                new GenderTranslation { Gender = women, Language = _polish, Name = "Damskie" },
                new GenderTranslation { Gender = women, Language = _english, Name = "Women" },
            };
            women.GenderTranslations = womenTranslations;
            await _dbContext.GenderTranslations.AddRangeAsync(womenTranslations);


            var unisex = new Gender();
            await _dbContext.Genders.AddAsync(unisex);

            List<GenderTranslation> unisexTranslations = new()
            {
                new GenderTranslation { Gender = unisex, Language = _polish, Name = "Unisex" },
                new GenderTranslation { Gender = unisex, Language = _english, Name = "Unisex" },
            };
            unisex.GenderTranslations = unisexTranslations;
            await _dbContext.GenderTranslations.AddRangeAsync(unisexTranslations);

            await _dbContext.SaveChangesAsync();
            var genderList = await _dbContext.Genders.ToListAsync();
            foreach (var x in genderList)
            {
                x.EncodeName();
                x.CreatedBy = _defaultAdmin;
            }

            #endregion

            #region Products

            var smellItDiffuser = new Product
            {
                Brand = smellIt,
                ProductCategory = diffusers
            };
            await _dbContext.Products.AddAsync(smellItDiffuser);

            var smellItDiffuserPrice = new ProductPrice
            {
                Product = smellItDiffuser,
                Value = 1099,
                StartDateTime = DateTime.ParseExact("1900-01-01 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            };
            await _dbContext.ProductPrices.AddAsync(smellItDiffuserPrice);

            var smellItDiffuserPricePromotion = new ProductPrice
            {
                Product = smellItDiffuser,
                Value = 899,
                IsPromotion = true,
                StartDateTime = DateTime.Now
            };
            await _dbContext.ProductPrices.AddAsync(smellItDiffuserPricePromotion);

            List<ProductTranslation> smellItDiffuserTranslations = new()
            {
                new ProductTranslation
                {
                    Product = smellItDiffuser, Language = _polish, Name = "Dyfuzor Smell It",
                    Description =
                        "Nowoczesny dyfuzor zapachów, który dzięki zaawansowanej technologii jest w stanie odwzorować 99% zapachów dostrzeganych przez człowieka. Urządzenie to łączy się bezprzewodowo z komputerem lub telefonem za pomocą Bluetooth. Dzięki Smell it sprawdzisz zapach perfum bez wychodzenia z domu, a także doświadczysz niesamowitych wrażeń sensorycznych podczas oglądania filmów."
                },
                new ProductTranslation
                {
                    Product = smellItDiffuser, Language = _english, Name = "Smell It diffuser",
                    Description =
                        "The modern scent diffuser, which, thanks to advanced technology, is able to replicate 99% of scents perceived by humans. This device connects wirelessly to a computer or phone via Bluetooth. With Smell it, you can test a perfume's scent without leaving your home and also experience incredible sensory experiences while watching movies."
                },
            };
            smellItDiffuser.ProductTranslations = smellItDiffuserTranslations;
            await _dbContext.ProductTranslations.AddRangeAsync(smellItDiffuserTranslations);


            var goodGirl = new Product
            {
                Brand = carolinaHerrera,
                ProductCategory = eauDeParfum,
                FragranceCategory = oriental,
                Gender = women,
                Capacity = 80
            };
            await _dbContext.Products.AddAsync(goodGirl);

            var goodGirlPriceHistory = new ProductPrice
            {
                Product = goodGirl,
                Value = 489,
                StartDateTime = DateTime.ParseExact("1900-01-01 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            };
            await _dbContext.ProductPrices.AddAsync(goodGirlPriceHistory);

            List<ProductTranslation> goodGirlTranslations = new()
            {
                new ProductTranslation
                {
                    Product = goodGirl, Language = _polish, Name = "Good Girl",
                    Description =
                        "\"Good Girl\" to popularny zapach marki Carolina Herrera, który jest dostępny w wersjach dla kobiet i mężczyzn. Kompozycja zapachu to mieszanka zmysłowych i intensywnych nut, w tym bergamotki, jaśminu, tuberozy, kawy, paczuli i wanilii. Flakon zapachu w kształcie szklanej szpilki, symbolizuje kobiecość, elegancję i pewność siebie. \"Good Girl\" to zapach z charakterem, który jest idealny na wieczorne wyjścia i specjalne okazje. Zapach jest ceniony za swoją trwałość i oryginalność, a jego aromat jest jednocześnie słodki, zmysłowy i uwodzicielski."
                },
                new ProductTranslation
                {
                    Product = goodGirl, Language = _english, Name = "Good Girl",
                    Description =
                        "\"Good Girl\" is a popular fragrance by Carolina Herrera, available in versions for women and men. The fragrance composition is a mixture of sensual and intense notes, including bergamot, jasmine, tuberose, coffee, patchouli, and vanilla. The fragrance bottle in the shape of a glass stiletto symbolizes femininity, elegance, and confidence. \"Good Girl\" is a fragrance with character, perfect for evening outings and special occasions. The fragrance is valued for its longevity and originality, and its aroma is simultaneously sweet, sensual, and seductive."
                },
            };
            goodGirl.ProductTranslations = goodGirlTranslations;
            await _dbContext.ProductTranslations.AddRangeAsync(goodGirlTranslations);


            _sauvage = new Product
            {
                Brand = dior,
                ProductCategory = eauDeParfum,
                FragranceCategory = aromatic,
                Gender = men,
                Capacity = 100
            };
            await _dbContext.Products.AddAsync(_sauvage);

            var sauvagePriceHistory = new ProductPrice
            {
                Product = _sauvage,
                Value = 479,
                StartDateTime = DateTime.ParseExact("1900-01-01 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            };
            await _dbContext.ProductPrices.AddAsync(sauvagePriceHistory);

            List<ProductTranslation> savuageTranslations = new()
            {
                new ProductTranslation
                {
                    Product = _sauvage, Language = _polish, Name = "Sauvage",
                    Description =
                        "\"Dior Sauvage\" to luksusowy męski zapach marki Dior, który został wprowadzony na rynek w 2015 roku. Kompozycja zapachu to mieszanka zmysłowych nut bergamotki, ambrowych akordów, paczuli, jałowca i cedru wirginijskiego. Zapach jest orzeźwiający, a jednocześnie intrygujący i zmysłowy. Flakon zapachu jest prosty i elegancki, wykonany z grubego, niebieskiego szkła, nawiązujący do nieba i morza. \"Dior Sauvage\" to zapach idealny na co dzień, który wyróżnia się swoją wyjątkowością i trwałością. Jest to zapach, który pasuje do mężczyzn o silnym charakterze, którzy cenią sobie klasykę i elegancję."
                },
                new ProductTranslation
                {
                    Product = _sauvage, Language = _english, Name = "Sauvage",
                    Description =
                        "\"Dior Sauvage\" is a luxury men's fragrance by Dior that was introduced in 2015. The fragrance composition is a mixture of sensual notes of bergamot, amber accords, patchouli, juniper, and Virginia cedar. The fragrance is refreshing, yet intriguing and sensual. The fragrance bottle is simple and elegant, made of thick blue glass, reminiscent of the sky and sea. \"Dior Sauvage\" is a perfect fragrance for everyday wear that stands out for its uniqueness and longevity. It is a fragrance that suits men with strong character who appreciate classic and elegance."
                },
            };
            _sauvage.ProductTranslations = savuageTranslations;
            await _dbContext.ProductTranslations.AddRangeAsync(savuageTranslations);


            _si = new Product
            {
                Brand = giorgioArmani,
                ProductCategory = eauDeParfum,
                FragranceCategory = fruity,
                Gender = women,
                Capacity = 100
            };
            await _dbContext.Products.AddAsync(_si);

            var siPriceHistory = new ProductPrice
            {
                Product = _si,
                Value = 491,
                StartDateTime = DateTime.ParseExact("1900-01-01 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            };
            await _dbContext.ProductPrices.AddAsync(siPriceHistory);

            List<ProductTranslation> siTranslations = new()
            {
                new ProductTranslation
                {
                    Product = _si, Language = _polish, Name = "Si",
                    Description =
                        "\"Armani Si\" to zapach dla kobiet marki Armani, który został wprowadzony na rynek w 2013 roku. Kompozycja zapachu to połączenie nut owocowych, kwiatowych i drzewnych, w tym cassis, frezji, róż, paczuli, ambry i wanilii. \"Si\" to zapach elegancki, zmysłowy i kobiecy, idealny na wieczorne wyjścia i specjalne okazje. Flakon zapachu jest prosty i elegancki, wykonany z grubego, przezroczystego szkła, a na jego szyi umieszczona jest ozdobna zawieszka. Zapach \"Si\" jest ceniony za swoją trwałość i intensywność, a jego aromat jest jednocześnie słodki, zmysłowy i delikatny."
                },
                new ProductTranslation
                {
                    Product = _si, Language = _english, Name = "Si",
                    Description =
                        "\"Giorgio Armani Si\" is a fragrance for women by the Armani brand that was introduced in 2013. The fragrance composition is a combination of fruity, floral, and woody notes, including cassis, freesia, rose, patchouli, amber, and vanilla. \"Si\" is an elegant, sensual, and feminine fragrance, ideal for evening outings and special occasions. The fragrance bottle is simple and elegant, made of thick, transparent glass, and features a decorative pendant on its neck. \"Si\" fragrance is valued for its longevity and intensity, and its aroma is simultaneously sweet, sensual, and delicate."
                },
            };
            _si.ProductTranslations = siTranslations;
            await _dbContext.ProductTranslations.AddRangeAsync(siTranslations);


            var oneMillion = new Product
            {
                Brand = pacoRabanne,
                ProductCategory = eauDeToilette,
                FragranceCategory = spicy,
                Gender = men,
                Capacity = 100
            };
            await _dbContext.Products.AddAsync(oneMillion);

            var oneMillionPriceHistory = new ProductPrice
            {
                Product = oneMillion,
                Value = 332,
                StartDateTime = DateTime.ParseExact("1900-01-01 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            };
            await _dbContext.ProductPrices.AddAsync(oneMillionPriceHistory);

            List<ProductTranslation> oneMillionTranslations = new()
            {
                new ProductTranslation
                {
                    Product = oneMillion, Language = _polish, Name = "1 Million",
                    Description =
                        "\"Paco Rabanne 1 Million\" to popularny męski zapach marki Paco Rabanne, który został wprowadzony na rynek w 2008 roku. Kompozycja zapachu to mieszanka nut drzewnych, przyprawowych i owocowych, w tym mięty pieprzowej, paczuli, cynamonu, skóry i grejpfruta. \"1 Million\" to zapach świeży, orzeźwiający i energetyzujący. Flakon zapachu w kształcie złotej monety nawiązuje do luksusu i bogactwa, symbolizując styl i klasę marki. \"Paco Rabanne 1 Million\" jest ceniony za swoją oryginalność, trwałość i intensywność zapachu, który jest jednocześnie zmysłowy, męski i uwodzicielski."
                },
                new ProductTranslation
                {
                    Product = oneMillion, Language = _english, Name = "1 Million",
                    Description =
                        "\"Paco Rabanne 1 Million\" is a popular men's fragrance by Paco Rabanne that was introduced in 2008. The fragrance composition is a mixture of woody, spicy, and fruity notes, including peppermint, patchouli, cinnamon, leather, and grapefruit. \"1 Million\" is a fresh, refreshing, and energizing fragrance. The fragrance bottle in the shape of a golden coin refers to luxury and wealth, symbolizing the style and class of the brand. \"Paco Rabanne 1 Million\" is valued for its originality, longevity, and intensity of fragrance, which is simultaneously sensual, masculine, and seductive."
                },
            };
            oneMillion.ProductTranslations = oneMillionTranslations;
            await _dbContext.ProductTranslations.AddRangeAsync(oneMillionTranslations);


            var eros = new Product
            {
                Brand = versace,
                ProductCategory = eauDeToilette,
                FragranceCategory = aromatic,
                Gender = men,
                Capacity = 100
            };
            await _dbContext.Products.AddAsync(eros);

            var erosPriceHistory = new ProductPrice
            {
                Product = eros,
                Value = 255,
                StartDateTime = DateTime.ParseExact("1900-01-01 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            };
            await _dbContext.ProductPrices.AddAsync(erosPriceHistory);

            List<ProductTranslation> erosTranslations = new()
            {
                new ProductTranslation
                {
                    Product = eros, Language = _polish, Name = "Eros",
                    Description =
                        "\"Versace Eros\" to popularny zapach marki Versace dla mężczyzn, który został wprowadzony na rynek w 2012 roku. Kompozycja zapachu zawiera nuty drzewne, przyprawowe i kwiatowe, w tym mięty, cytrusów, zielonej jabłk i wanilii. \"Eros\" to zapach męski, zmysłowy i intensywny, idealny na wieczorne wyjścia i specjalne okazje. Flakon zapachu w kształcie greckiej kolumny nawiązuje do klasycznej estetyki i symbolizuje siłę i męskość. \"Versace Eros\" jest ceniony za swoją oryginalność, trwałość i intensywność zapachu, który jest jednocześnie intrygujący, zmysłowy i uwodzicielski."
                },
                new ProductTranslation
                {
                    Product = eros, Language = _english, Name = "Eros",
                    Description =
                        "\"Versace Eros\" is a popular fragrance by Versace for men that was introduced in 2012. The fragrance composition contains woody, spicy, and floral notes, including mint, citrus, green apple, and vanilla. \"Eros\" is a masculine, sensual, and intense fragrance, ideal for evening outings and special occasions. The fragrance bottle in the shape of a Greek column refers to classical aesthetics and symbolizes strength and masculinity. \"Versace Eros\" is valued for its originality, longevity, and intensity of fragrance, which is simultaneously intriguing, sensual, and seductive."
                },
            };
            eros.ProductTranslations = erosTranslations;
            await _dbContext.ProductTranslations.AddRangeAsync(erosTranslations);


            var blackOpium = new Product
            {
                Brand = yvesSaintLaurent,
                ProductCategory = fragrance,
                FragranceCategory = oriental,
                Gender = women,
                Capacity = 90,
            };
            await _dbContext.Products.AddAsync(blackOpium);

            var blackOpiumPriceHistory = new ProductPrice
            {
                Product = blackOpium,
                Value = 459,
                StartDateTime = DateTime.ParseExact("1900-01-01 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            };
            await _dbContext.ProductPrices.AddAsync(blackOpiumPriceHistory);

            List<ProductTranslation> blackOpiumTranslations = new()
            {
                new ProductTranslation
                {
                    Product = blackOpium, Language = _polish, Name = "Black Opium",
                    Description =
                        "\"Yves Saint Laurent Black Opium\" to popularny zapach dla kobiet marki Yves Saint Laurent, który został wprowadzony na rynek w 2014 roku. Kompozycja zapachu to mieszanka nut kwiatowych, kawowych, drzewnych i waniliowych, w tym róży, jaśminu, kawy, paczuli i wanilii. \"Black Opium\" to zapach zmysłowy, mocny i wyrazisty, idealny na wieczorne wyjścia i specjalne okazje. Flakon zapachu jest prosty, ale elegancki, wykonany z czarnego, matowego szkła, co nadaje mu niepowtarzalnego charakteru. \"Yves Saint Laurent Black Opium\" jest ceniony za swoją trwałość i intensywność zapachu, który jest jednocześnie słodki, zmysłowy i uwodzicielski."
                },
                new ProductTranslation
                {
                    Product = blackOpium, Language = _english, Name = "Black Opium",
                    Description =
                        "\"Yves Saint Laurent Black Opium\" is a popular fragrance for women by the Yves Saint Laurent brand that was introduced in 2014. The fragrance composition is a mixture of floral, coffee, woody, and vanilla notes, including rose, jasmine, coffee, patchouli, and vanilla. \"Black Opium\" is a sensual, strong, and distinctive fragrance, ideal for evening outings and special occasions. The fragrance bottle is simple but elegant, made of black matte glass, which gives it a unique character. \"Yves Saint Laurent Black Opium\" is valued for its longevity and intensity of fragrance, which is simultaneously sweet, sensual, and seductive."
                },
            };
            blackOpium.ProductTranslations = blackOpiumTranslations;
            await _dbContext.ProductTranslations.AddRangeAsync(blackOpiumTranslations);

            await _dbContext.SaveChangesAsync();
            var productList = await _dbContext.Products.ToListAsync();
            foreach (var x in productList)
            {
                x.EncodeName();
                x.CreatedBy = _defaultAdmin;
            }

            #endregion

            #region ProductImages

            List<ProductImage> productImages = new()
            {
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/smell-it/dyfuzor-smell-it1.jpg",
                    ImageAlt = "dyfuzor-smell-it1",
                    Product = smellItDiffuser,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/smell-it/dyfuzor-smell-it1-1.jpg",
                    ImageAlt = "dyfuzor-smell-it1-1",
                    Product = smellItDiffuser,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/women/Giorgio Armani Si/armani-si1.png",
                    ImageAlt = "armani-si1",
                    Product = _si,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/women/Giorgio Armani Si/armani-si2.png",
                    ImageAlt = "armani-si2",
                    Product = _si,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/women/Giorgio Armani Si/armani-si3.png",
                    ImageAlt = "armani-si3",
                    Product = _si,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/men/Dior Savuage/dior-savuage1.png",
                    ImageAlt = "dior-savuage1",
                    Product = _sauvage,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/men/Dior Savuage/dior-savuage2.png",
                    ImageAlt = "dior-savuage2",
                    Product = _sauvage,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/men/Dior Savuage/dior-savuage3.png",
                    ImageAlt = "dior-savuage3",
                    Product = _sauvage,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/women/YSL Black Opium/ysl-black-opium1.png",
                    ImageAlt = "ysl-black-opium1",
                    Product = blackOpium,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/women/YSL Black Opium/ysl-black-opium2.png",
                    ImageAlt = "ysl-black-opium2",
                    Product = blackOpium,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/women/YSL Black Opium/ysl-black-opium3.png",
                    ImageAlt = "ysl-black-opium3",
                    Product = blackOpium,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/women/Carolina Herrera Good Girl/ch-good-girl1.png",
                    ImageAlt = "ch-good-girl1",
                    Product = goodGirl,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/women/Carolina Herrera Good Girl/ch-good-girl2.png",
                    ImageAlt = "ch-good-girl2",
                    Product = goodGirl,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/women/Carolina Herrera Good Girl/ch-good-girl3.png",
                    ImageAlt = "ch-good-girl3",
                    Product = goodGirl,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/men/Paco Rabanne 1 Million/pr-1million1.png",
                    ImageAlt = "pr-1million1",
                    Product = oneMillion,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/men/Paco Rabanne 1 Million/pr-1million2.png",
                    ImageAlt = "pr-1million2",
                    Product = oneMillion,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/men/Paco Rabanne 1 Million/pr-1million3.png",
                    ImageAlt = "pr-1million3",
                    Product = oneMillion,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/men/Versace Eros/versace-eros1.png",
                    ImageAlt = "versace-eros1",
                    Product = eros,
                    CreatedBy = _defaultAdmin
                },
                new ProductImage
                {
                    ImageUrl = "/images/shop/products/perfumes/men/Versace Eros/versace-eros2.png",
                    ImageAlt = "versace-eros2",
                    Product = eros,
                    CreatedBy = _defaultAdmin
                },
            };
            await _dbContext.ProductImages.AddRangeAsync(productImages);
            #endregion
        }
    }

    private async Task SeedAddressesAsync()
    {
        if (!await _dbContext.Addresses.AnyAsync())
        {
            var address = new Address
            {
                FullName = "Smell It sp. z o.o.",
                FirstLine = "Floriańska 1",
                PostalCode = "31-042",
                City = "Kraków"
            };
            await _dbContext.Addresses.AddAsync(address);
        }
    }
}