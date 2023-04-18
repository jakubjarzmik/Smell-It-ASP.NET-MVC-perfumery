using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public DbSet<Language> Languages { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<ProductTranslation> ProductTranslations { get; set; } = default!;
        public DbSet<ProductCategory> ProductCategories { get; set; } = default!;
        public DbSet<ProductCategoryTranslation> ProductCategoryTranslations { get; set; } = default!;
        public DbSet<ProductImage> ProductImages { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u => u.CreatedAddresses)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Address>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedAddresses)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Address>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedAddresses)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Brand>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u => u.CreatedBrands)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Brand>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedBrands)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Brand>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedBrands)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BrandTranslation>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u => u.CreatedBrandTranslations)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BrandTranslation>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedBrandTranslations)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BrandTranslation>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedBrandTranslations)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BrandTranslation>()
                .HasOne(u => u.Brand)
                .WithMany(u => u.BrandTranslations)
                .HasForeignKey(u => u.BrandId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BrandTranslation>()
                .HasOne(u => u.Language)
                .WithMany(u => u.BrandTranslations)
                .HasForeignKey(u => u.LanguageId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FragranceCategory>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u => u.CreatedFragranceCategories)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<FragranceCategory>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedFragranceCategories)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<FragranceCategory>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedFragranceCategories)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FragranceCategoryTranslation>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u => u.CreatedFragranceCategoryTranslations)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<FragranceCategoryTranslation>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedFragranceCategoryTranslations)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<FragranceCategoryTranslation>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedFragranceCategoryTranslations)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<FragranceCategoryTranslation>()
                .HasOne(u => u.FragranceCategory)
                .WithMany(u => u.FragranceCategoryTranslations)
                .HasForeignKey(u => u.FragranceCategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<FragranceCategoryTranslation>()
                .HasOne(u => u.Language)
                .WithMany(u => u.FragranceCategoryTranslations)
                .HasForeignKey(u => u.LanguageId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Gender>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u => u.CreatedGenders)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Gender>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedGenders)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Gender>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedGenders)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GenderTranslation>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u => u.CreatedGenderTranslations)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<GenderTranslation>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedGenderTranslations)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<GenderTranslation>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedGenderTranslations)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<GenderTranslation>()
                .HasOne(u => u.Gender)
                .WithMany(u => u.GenderTranslations)
                .HasForeignKey(u => u.GenderId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<GenderTranslation>()
                .HasOne(u => u.Language)
                .WithMany(u => u.GenderTranslations)
                .HasForeignKey(u => u.LanguageId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Language>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u => u.CreatedLanguages)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Language>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedLanguages)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Language>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedLanguages)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u => u.CreatedProducts)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedProducts)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedProducts)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>()
                .HasOne(u => u.Category)
                .WithMany(u => u.Products)
                .HasForeignKey(u => u.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>()
                .HasOne(u => u.Brand)
                .WithMany(u => u.Products)
                .HasForeignKey(u => u.BrandId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>()
                .HasOne(u => u.FragranceCategory)
                .WithMany(u => u.Products)
                .HasForeignKey(u => u.FragranceCategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>()
                .HasOne(u => u.Gender)
                .WithMany(u => u.Products)
                .HasForeignKey(u => u.GenderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductTranslation>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u => u.CreatedProductTranslations)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductTranslation>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedProductTranslations)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductTranslation>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedProductTranslations)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductTranslation>()
                .HasOne(u => u.Product)
                .WithMany(u => u.ProductTranslations)
                .HasForeignKey(u => u.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductTranslation>()
                .HasOne(u => u.Language)
                .WithMany(u => u.ProductTranslations)
                .HasForeignKey(u => u.LanguageId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u => u.CreatedProductCategories)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedProductCategories)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedProductCategories)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(u => u.ParentCategory)
                .WithMany(u => u.ProductCategories)
                .HasForeignKey(u => u.ParentCategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductCategoryTranslation>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u => u.CreatedProductCategoryTranslations)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductCategoryTranslation>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedProductCategoryTranslations)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductCategoryTranslation>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedProductCategoryTranslations)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductCategoryTranslation>()
                .HasOne(u => u.ProductCategory)
                .WithMany(u => u.ProductCategoryTranslations)
                .HasForeignKey(u => u.ProductCategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductCategoryTranslation>()
                .HasOne(u => u.Language)
                .WithMany(u => u.ProductCategoryTranslations)
                .HasForeignKey(u => u.LanguageId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductImage>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u => u.CreatedProductImages)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductImage>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedProductImages)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductImage>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedProductImages)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductImage>()
                .HasOne(u => u.Product)
                .WithMany(u => u.ProductImages)
                .HasForeignKey(u => u.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u => u.CreatedUsers)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedUsers)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedUsers)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.AddressId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
