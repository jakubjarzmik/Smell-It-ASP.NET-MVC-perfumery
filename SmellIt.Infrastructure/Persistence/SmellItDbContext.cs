using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;

namespace SmellIt.Infrastructure.Persistence
{
    public class SmellItDbContext : DbContext
    {
        public SmellItDbContext(DbContextOptions<SmellItDbContext> options) : base(options)
        {

        }
        public DbSet<Address> Addresses { get; set; } = default!;
        public DbSet<Brand> Brands { get; set; } = default!;
        public DbSet<BrandTranslation> BrandTranslations { get; set; } = default!;
        public DbSet<FragranceCategory> FragranceCategories { get; set; } = default!;
        public DbSet<FragranceCategoryTranslation> FragranceCategoryTranslations { get; set; } = default!;
        public DbSet<Gender> Genders { get; set; } = default!;
        public DbSet<GenderTranslation> GenderTranslations { get; set; } = default!;
        public DbSet<HomeBanner> HomeBanners { get; set; } = default!;
        public DbSet<HomeBannerTranslation> HomeBannerTranslations { get; set; } = default!;
        public DbSet<Language> Languages { get; set; } = default!;
		public DbSet<PrivacyPolicy> PrivacyPolicies { get; set; } = default!;
		public DbSet<Product> Products { get; set; } = default!;
        public DbSet<ProductTranslation> ProductTranslations { get; set; } = default!;
        public DbSet<ProductCategory> ProductCategories { get; set; } = default!;
        public DbSet<ProductCategoryTranslation> ProductCategoryTranslations { get; set; } = default!;
        public DbSet<ProductImage> ProductImages { get; set; } = default!;
        public DbSet<SocialSite> SocialSites { get; set; } = default!;
        public DbSet<WebsiteText> WebsiteTexts { get; set; } = default!;
        public DbSet<WebsiteTextTranslation> WebsiteTextTranslations { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandId);
            modelBuilder.Entity<Brand>()
                .HasMany(b => b.BrandTranslations)
                .WithOne(bt => bt.Brand)
                .HasForeignKey(bt => bt.BrandId);

            modelBuilder.Entity<BrandTranslation>()
                .HasOne(u => u.Brand)
                .WithMany(u => u.BrandTranslations)
                .HasForeignKey(u => u.BrandId);
            modelBuilder.Entity<BrandTranslation>()
                .HasOne(u => u.Language)
                .WithMany(u => u.BrandTranslations)
                .HasForeignKey(u => u.LanguageId);

            modelBuilder.Entity<FragranceCategory>()
                .HasMany(fc => fc.Products)
                .WithOne(p => p.FragranceCategory)
                .HasForeignKey(p => p.FragranceCategoryId);
            modelBuilder.Entity<FragranceCategory>()
                .HasMany(fc => fc.FragranceCategoryTranslations)
                .WithOne(fct => fct.FragranceCategory)
                .HasForeignKey(fct => fct.FragranceCategoryId);

            modelBuilder.Entity<FragranceCategoryTranslation>()
                .HasOne(u => u.FragranceCategory)
                .WithMany(u => u.FragranceCategoryTranslations)
                .HasForeignKey(u => u.FragranceCategoryId);
            modelBuilder.Entity<FragranceCategoryTranslation>()
                .HasOne(u => u.Language)
                .WithMany(u => u.FragranceCategoryTranslations)
                .HasForeignKey(u => u.LanguageId);

            modelBuilder.Entity<Gender>()
                .HasMany(g => g.Products)
                .WithOne(p => p.Gender)
                .HasForeignKey(p => p.GenderId);
            modelBuilder.Entity<Gender>()
                .HasMany(g => g.GenderTranslations)
                .WithOne(gt => gt.Gender)
                .HasForeignKey(gt => gt.GenderId);

            modelBuilder.Entity<HomeBanner>()
                .HasMany(hb => hb.HomeBannerTranslations)
                .WithOne(hbt => hbt.HomeBanner)
                .HasForeignKey(hbt => hbt.HomeBannerId);

            modelBuilder.Entity<HomeBannerTranslation>()
                .HasOne(hbt => hbt.HomeBanner)
                .WithMany(hb => hb.HomeBannerTranslations)
                .HasForeignKey(hbt => hbt.HomeBannerId);
            modelBuilder.Entity<HomeBannerTranslation>()
                .HasOne(hbt => hbt.Language)
                .WithMany(l => l.HomeBannerTranslations)
                .HasForeignKey(hbt => hbt.LanguageId);

            modelBuilder.Entity<GenderTranslation>()
                .HasOne(u => u.Gender)
                .WithMany(u => u.GenderTranslations)
                .HasForeignKey(u => u.GenderId);
            modelBuilder.Entity<GenderTranslation>()
                .HasOne(u => u.Language)
                .WithMany(u => u.GenderTranslations)
                .HasForeignKey(u => u.LanguageId);

            modelBuilder.Entity<Language>()
                .HasMany(l => l.BrandTranslations)
                .WithOne(bt => bt.Language)
                .HasForeignKey(bt => bt.LanguageId);
            modelBuilder.Entity<Language>()
                .HasMany(l => l.FragranceCategoryTranslations)
                .WithOne(fct => fct.Language)
                .HasForeignKey(fct => fct.LanguageId);
            modelBuilder.Entity<Language>()
                .HasMany(l => l.GenderTranslations)
                .WithOne(gt => gt.Language)
                .HasForeignKey(gt => gt.LanguageId);
            modelBuilder.Entity<Language>()
                .HasMany(l => l.PrivacyPolicies)
                .WithOne(pp => pp.Language)
                .HasForeignKey(pp => pp.LanguageId);
            modelBuilder.Entity<Language>()
                .HasMany(l => l.ProductTranslations)
                .WithOne(pt => pt.Language)
                .HasForeignKey(pt => pt.LanguageId);
            modelBuilder.Entity<Language>()
                .HasMany(l => l.ProductCategoryTranslations)
                .WithOne(pct => pct.Language)
                .HasForeignKey(pct => pct.LanguageId);
            modelBuilder.Entity<Language>()
                .HasMany(l => l.WebsiteTexts)
                .WithOne(pct => pct.Language)
                .HasForeignKey(pct => pct.LanguageId);

            modelBuilder.Entity<PrivacyPolicy>()
                .HasOne(pp => pp.Language)
                .WithMany(l => l.PrivacyPolicies)
                .HasForeignKey(pp => pp.LanguageId);

            modelBuilder.Entity<Product>()
                .HasOne(u => u.ProductCategory)
                .WithMany(u => u.Products)
                .HasForeignKey(u => u.ProductCategoryId);
            modelBuilder.Entity<Product>()
                .HasOne(u => u.Brand)
                .WithMany(u => u.Products)
                .HasForeignKey(u => u.BrandId);
            modelBuilder.Entity<Product>()
                .HasOne(u => u.FragranceCategory)
                .WithMany(u => u.Products)
                .HasForeignKey(u => u.FragranceCategoryId);
            modelBuilder.Entity<Product>()
                .HasOne(u => u.Gender)
                .WithMany(u => u.Products)
                .HasForeignKey(u => u.GenderId);
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductImages)
                .WithOne(pi => pi.Product)
                .HasForeignKey(pi => pi.ProductId);
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductTranslations)
                .WithOne(pt => pt.Product)
                .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductTranslation>()
                .HasOne(u => u.Product)
                .WithMany(u => u.ProductTranslations)
                .HasForeignKey(u => u.ProductId);
            modelBuilder.Entity<ProductTranslation>()
                .HasOne(u => u.Language)
                .WithMany(u => u.ProductTranslations)
                .HasForeignKey(u => u.LanguageId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(u => u.ParentCategory)
                .WithMany(u => u.ProductCategories)
                .HasForeignKey(u => u.ParentCategoryId);
            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.ProductCategories)
                .WithOne(pc => pc.ParentCategory)
                .HasForeignKey(pc => pc.ParentCategoryId);
            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.Products)
                .WithOne(p => p.ProductCategory)
                .HasForeignKey(p => p.ProductCategoryId);
            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.ProductCategoryTranslations)
                .WithOne(pct => pct.ProductCategory)
                .HasForeignKey(pct => pct.ProductCategoryId);

            modelBuilder.Entity<ProductCategoryTranslation>()
                .HasOne(u => u.ProductCategory)
                .WithMany(u => u.ProductCategoryTranslations)
                .HasForeignKey(u => u.ProductCategoryId);
            modelBuilder.Entity<ProductCategoryTranslation>()
                .HasOne(u => u.Language)
                .WithMany(u => u.ProductCategoryTranslations)
                .HasForeignKey(u => u.LanguageId);

            modelBuilder.Entity<ProductImage>()
                .HasOne(u => u.Product)
                .WithMany(u => u.ProductImages)
                .HasForeignKey(u => u.ProductId);

            modelBuilder.Entity<WebsiteText>()
                .HasMany(lt => lt.WebsiteTextTranslations)
                .WithOne(ltt => ltt.WebsiteText)
                .HasForeignKey(ltt => ltt.WebsiteTextId);

            modelBuilder.Entity<WebsiteTextTranslation>()
                .HasOne(lt => lt.WebsiteText)
                .WithMany(l => l.WebsiteTextTranslations)
                .HasForeignKey(lt => lt.WebsiteTextId);
            modelBuilder.Entity<WebsiteTextTranslation>()
                .HasOne(lt => lt.Language)
                .WithMany(l => l.WebsiteTexts)
                .HasForeignKey(lt => lt.LanguageId);
        }
    }
}
