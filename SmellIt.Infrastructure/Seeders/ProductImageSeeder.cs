using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Domain.Entities;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Seeders
{
    public class ProductImageSeeder : ISeeder
    {
        private readonly SmellItDbContext _dbContext;

        public ProductImageSeeder(SmellItDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (!_dbContext.ProductImages.Any())
            {
                List<ProductImage> data = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/smell-it/dyfuzor-smell-it1.jpg",
                        ImageAlt = "SmellItDiffuser",
                        ProductId = _dbContext.Products.Where(p=>p.Name.Equals("SmellItDiffuser")).Single().Id
                        
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/women/Giorgio Armani Si/armani-si1.png",
                        ImageAlt = "Si",
                        ProductId = _dbContext.Products.Where(p=>p.Name.Equals("Si")).Single().Id
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/men/Dior Savuage/dior-savuage1.png",
                        ImageAlt = "Sauvage",
                        ProductId = _dbContext.Products.Where(p=>p.Name.Equals("Sauvage")).Single().Id
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/women/YSL Black Opium/ysl-black-opium1.png",
                        ImageAlt = "Black Opium",
                        ProductId = _dbContext.Products.Where(p=>p.Name.Equals("Black Opium")).Single().Id
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/women/Carolina Herrera Good Girl/ch-good-girl1.png",
                        ImageAlt = "Good Girl",
                        ProductId = _dbContext.Products.Where(p=>p.Name.Equals("Good Girl")).Single().Id
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/men/Paco Rabanne 1 Million/pr-1million1.png",
                        ImageAlt = "1 Million",
                        ProductId = _dbContext.Products.Where(p=>p.Name.Equals("1 Million")).Single().Id
                    },
                    new ProductImage()
                    {
                        ImagePath = "~/images/shop/products/perfumes/men/Versace Eros/versace-eros1.png",
                        ImageAlt = "Eros",
                        ProductId = _dbContext.Products.Where(p=>p.Name.Equals("Eros")).Single().Id
                    },
                };
                await _dbContext.ProductImages.AddRangeAsync(data);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
