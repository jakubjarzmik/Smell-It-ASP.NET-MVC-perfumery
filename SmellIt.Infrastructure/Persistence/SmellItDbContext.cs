using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;

namespace SmellIt.Infrastructure.Persistence;
public class SmellItDbContext : IdentityDbContext
{
    public SmellItDbContext(DbContextOptions<SmellItDbContext> options) : base(options)
    {

    }
    public DbSet<Address> Addresses { get; set; } = default!;
    public DbSet<Brand> Brands { get; set; } = default!;
    public DbSet<BrandTranslation> BrandTranslations { get; set; } = default!;
    public DbSet<CartItem> CartItems { get; set; } = default!;
    public DbSet<Delivery> Deliveries { get; set; } = default!;
    public DbSet<DeliveryTranslation> DeliveryTranslations { get; set; } = default!;
    public DbSet<FragranceCategory> FragranceCategories { get; set; } = default!;
    public DbSet<FragranceCategoryTranslation> FragranceCategoryTranslations { get; set; } = default!;
    public DbSet<Gender> Genders { get; set; } = default!;
    public DbSet<GenderTranslation> GenderTranslations { get; set; } = default!;
    public DbSet<HomeBanner> HomeBanners { get; set; } = default!;
    public DbSet<HomeBannerTranslation> HomeBannerTranslations { get; set; } = default!;
    public DbSet<Language> Languages { get; set; } = default!;
    public DbSet<Payment> Payments { get; set; } = default!;
    public DbSet<PaymentTranslation> PaymentTranslations { get; set; } = default!;
    public DbSet<PrivacyPolicy> PrivacyPolicies { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<ProductTranslation> ProductTranslations { get; set; } = default!;
    public DbSet<ProductCategory> ProductCategories { get; set; } = default!;
    public DbSet<ProductCategoryTranslation> ProductCategoryTranslations { get; set; } = default!;
    public DbSet<ProductImage> ProductImages { get; set; } = default!;
    public DbSet<ProductPrice> ProductPrices { get; set; } = default!;
    public DbSet<SocialSite> SocialSites { get; set; } = default!;
    public DbSet<WebsiteText> WebsiteTexts { get; set; } = default!;
    public DbSet<WebsiteTextTranslation> WebsiteTextTranslations { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CartItem>()
            .Property(p => p.Quantity)
            .HasColumnType("decimal(7,0)");
        modelBuilder.Entity<ProductPrice>()
            .Property(p => p.Value)
            .HasColumnType("decimal(7,2)");
        modelBuilder.Entity<ProductPrice>()
            .Property(p => p.StartDateTime)
            .HasColumnType("smalldatetime");
        modelBuilder.Entity<ProductPrice>()
            .Property(p => p.EndDateTime)
            .HasColumnType("smalldatetime");
        modelBuilder.Entity<Delivery>()
            .Property(p => p.Price)
            .HasColumnType("decimal(7,2)");
    }
}