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
                List<Product> data = new List<Product>
                {
                    new Product
                    {
                        Name = "SmellItDiffuser", 
                        Description = "SmellItDiffuserDesc", 
                        CategoryId = _dbContext.ProductCategories.Where(c=>c.Name.Equals("Diffusers")).Single().Id,
                        BrandId = _dbContext.Brands.Where(c=>c.Name.Equals("Smell It")).Single().Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                    new Product
                    {
                        Name = "Good Girl", 
                        Description = "GoodGirlDesc",
                        CategoryId = _dbContext.ProductCategories.Where(c=>c.Name.Equals("Fragrance")).Single().Id,
                        BrandId = _dbContext.Brands.Where(c=>c.Name.Equals("Carolina Herrera")).Single().Id,
                        FragranceGroupId = _dbContext.FragranceGroups.Where(c=>c.Name.Equals("Oriental")).Single().Id,
                        GenderId = _dbContext.Genders.Where(c=>c.Name.Equals("Women")).Single().Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                    new Product { 
                        Name = "Sauvage", 
                        Description = "SauvageDesc",
                        CategoryId = _dbContext.ProductCategories.Where(c=>c.Name.Equals("Fragrance")).Single().Id,
                        BrandId = _dbContext.Brands.Where(c=>c.Name.Equals("Dior")).Single().Id,
                        FragranceGroupId = _dbContext.FragranceGroups.Where(c=>c.Name.Equals("Aromatic")).Single().Id,
                        GenderId = _dbContext.Genders.Where(c=>c.Name.Equals("Men")).Single().Id,
                        CreatedById = _dbContext.Users.FirstOrDefault()!.Id
                    },
                    new Product
                    {
                        Name = "Si", 
                        Description = "SiDesc",
                        CategoryId = _dbContext.ProductCategories.Where(c=>c.Name.Equals("Fragrance")).Single().Id,
                        BrandId = _dbContext.Brands.Where(c=>c.Name.Equals("Giorgio Armani")).Single().Id,
                        FragranceGroupId = _dbContext.FragranceGroups.Where(c=>c.Name.Equals("Fruity")).Single().Id,
                        GenderId = _dbContext.Genders.Where(c=>c.Name.Equals("Women")).Single().Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                    new Product
                    {
                        Name = "1 Million", 
                        Description = "MillionDesc",
                        CategoryId = _dbContext.ProductCategories.Where(c=>c.Name.Equals("Fragrance")).Single().Id,
                        BrandId = _dbContext.Brands.Where(c=>c.Name.Equals("Paco Rabanne")).Single().Id,
                        FragranceGroupId = _dbContext.FragranceGroups.Where(c=>c.Name.Equals("Spicy")).Single().Id,
                        GenderId = _dbContext.Genders.Where(c=>c.Name.Equals("Men")).Single().Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                    new Product
                    {
                        Name = "Eros", 
                        Description = "ErosDesc",
                        CategoryId = _dbContext.ProductCategories.Where(c=>c.Name.Equals("Fragrance")).Single().Id,
                        BrandId = _dbContext.Brands.Where(c=>c.Name.Equals("Versace")).Single().Id,
                        FragranceGroupId = _dbContext.FragranceGroups.Where(c=>c.Name.Equals("Aromatic")).Single().Id,
                        GenderId = _dbContext.Genders.Where(c=>c.Name.Equals("Men")).Single().Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    },
                    new Product
                    {
                        Name = "Black Opium", 
                        Description = "BlackOpiumDesc",
                        CategoryId = _dbContext.ProductCategories.Where(c=>c.Name.Equals("Fragrance")).Single().Id,
                        BrandId = _dbContext.Brands.Where(c=>c.Name.Equals("Yves Saint Laurent")).Single().Id,
                        FragranceGroupId = _dbContext.FragranceGroups.Where(c=>c.Name.Equals("Oriental")).Single().Id,
                        GenderId = _dbContext.Genders.Where(c=>c.Name.Equals("Women")).Single().Id,
                        CreatedById = _dbContext.Users.FirstOrDefault() !.Id
                    }
                };
                await _dbContext.Products.AddRangeAsync(data);
                await _dbContext.SaveChangesAsync();
                List<ProductImage> images = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/smell-it/dyfuzor-smell-it1.jpg",
                        ImageAlt = "SmellItDiffuser"
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/women/Giorgio Armani Si/armani-si1.png",
                        ImageAlt = "Si"
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/men/Dior Savuage/dior-savuage1.png",
                        ImageAlt = "Sauvage"
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/women/YSL Black Opium/ysl-black-opium1.png",
                        ImageAlt = "Black Opium"
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/women/Carolina Herrera Good Girl/ch-good-girl1.png",
                        ImageAlt = "Good Girl"
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/men/Paco Rabanne 1 Million/pr-1million1.png",
                        ImageAlt = "1 Million"
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/men/Versace Eros/versace-eros1.png",
                        ImageAlt = "Eros"
                    }
                };
            }
        }
    }
}
