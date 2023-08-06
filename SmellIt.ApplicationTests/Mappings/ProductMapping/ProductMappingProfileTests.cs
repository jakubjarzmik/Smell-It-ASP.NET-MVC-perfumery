using AutoMapper;
using FluentAssertions;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Application.Mappings.ProductMapping;
using SmellIt.Domain.Entities;
using Xunit;

namespace SmellIt.ApplicationTests.Mappings.ProductMapping;

public class ProductMappingProfileTests
{
    [Fact]
    public void MappingProfile_ShouldMapProductToProductDto()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new ProductMappingProfile()));
        
        var mapper = configuration.CreateMapper();

        var languagePl = new Language
        {
            Id = 1,
            CreatedAt = DateTime.Now,
            IsActive = true,
            EncodedName = "polski",
            Name = "Polski",
            Code = "pl-PL"
        };
        var languageEn = new Language
        {
            Id = 2,
            CreatedAt = DateTime.Now,
            IsActive = true,
            EncodedName = "english",
            Name = "English",
            Code = "en-GB"
        };
        

        var product = new Product
        {
            Id = 1,
            IsActive = true,
            CreatedAt = DateTime.Now,
            CreatedById = "1",
            BrandId = null,
            Brand = null,
            FragranceCategoryId = null,
            FragranceCategory = null,
            GenderId = null,
            Gender = null,
            ProductImages = null,
            ProductTranslations = new List<ProductTranslation>
            {
                new ProductTranslation
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                    Name = "Produkt",
                    Description = "Opis produktu",
                    LanguageId = languagePl.Id,
                    Language = languagePl,
                    ProductId = 1
                },
                new ProductTranslation
                {
                    Id = 2,
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                    Name = "Product",
                    Description = "Product description",
                    LanguageId = languageEn.Id,
                    Language = languageEn,
                    ProductId = 1
                }
            },
            ProductPrices = new List<ProductPrice>
            {
                new ProductPrice
                {
                    Id = 1,
                    IsActive = true,
                    Value = 123,
                    IsPromotion = false,
                    StartDateTime = DateTime.Now.AddDays(-5),
                    ProductId = 1
                },
                new ProductPrice
                {
                    Id = 2,
                    IsActive = true,
                    Value = 100,
                    IsPromotion = true,
                    StartDateTime = DateTime.Now.AddDays(-4),
                    EndDateTime = DateTime.Now.AddDays(-3),
                    ProductId = 1
                },
                new ProductPrice
                {
                    Id = 3,
                    IsActive = true,
                    Value = 115,
                    IsPromotion = true,
                    StartDateTime = DateTime.Now.AddDays(-3),
                    EndDateTime = DateTime.Now.AddDays(-2),
                    ProductId = 1
                },
                new ProductPrice
                {
                    Id = 4,
                    IsActive = true,
                    Value = 110,
                    IsPromotion = true,
                    StartDateTime = DateTime.Now.AddDays(-2),
                    ProductId = 1
                }
            }
        };

        // Act
        var result = mapper.Map<ProductDto>(product);

        // Assert
        result.Should().NotBeNull();
        result.NamePl.Should().Be(product.ProductTranslations.First(pt => pt.Language == languagePl).Name);
        result.NameEn.Should().Be(product.ProductTranslations.First(pt => pt.Language == languageEn).Name);
        result.DescriptionPl.Should().Be(product.ProductTranslations.First(pt => pt.Language == languagePl).Description);
        result.DescriptionEn.Should().Be(product.ProductTranslations.First(pt => pt.Language == languageEn).Description);
        result.Price.Value.Should().Be(product.ProductPrices.First(pp => !pp.IsPromotion).Value);
        result.PromotionalPrice?.Value.Should().Be(110);
        result.Last30DaysLowestPrice?.Should().Be(100);
    }
    [Fact]
    public void MappingProfile_ShouldMapProductToWebsiteProductDto()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new ProductMappingProfile()));
        
        var mapper = configuration.CreateMapper();

        var languagePl = new Language
        {
            Id = 1,
            CreatedAt = DateTime.Now,
            IsActive = true,
            EncodedName = "polski",
            Name = "Polski",
            Code = "pl-PL"
        };
        var languageEn = new Language
        {
            Id = 2,
            CreatedAt = DateTime.Now,
            IsActive = true,
            EncodedName = "english",
            Name = "English",
            Code = "en-GB"
        };
        

        var product = new Product
        {
            Id = 1,
            IsActive = true,
            CreatedAt = DateTime.Now,
            CreatedById = "1",
            BrandId = null,
            Brand = null,
            FragranceCategoryId = null,
            FragranceCategory = null,
            GenderId = null,
            Gender = null,
            ProductImages = null,
            ProductTranslations = new List<ProductTranslation>
            {
                new ProductTranslation
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                    Name = "Produkt",
                    Description = "Opis produktu",
                    LanguageId = languagePl.Id,
                    Language = languagePl,
                    ProductId = 1
                },
                new ProductTranslation
                {
                    Id = 2,
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                    Name = "Product",
                    Description = "Product description",
                    LanguageId = languageEn.Id,
                    Language = languageEn,
                    ProductId = 1
                }
            },
            ProductPrices = new List<ProductPrice>
            {
                new ProductPrice
                {
                    Id = 1,
                    IsActive = true,
                    Value = 123,
                    IsPromotion = false,
                    StartDateTime = DateTime.Now.AddDays(-5),
                    ProductId = 1
                },
                new ProductPrice
                {
                    Id = 2,
                    IsActive = true,
                    Value = 100,
                    IsPromotion = true,
                    StartDateTime = DateTime.Now.AddDays(-4),
                    EndDateTime = DateTime.Now.AddDays(-3),
                    ProductId = 1
                },
                new ProductPrice
                {
                    Id = 3,
                    IsActive = true,
                    Value = 115,
                    IsPromotion = true,
                    StartDateTime = DateTime.Now.AddDays(-3),
                    EndDateTime = DateTime.Now.AddDays(-2),
                    ProductId = 1
                },
                new ProductPrice
                {
                    Id = 4,
                    IsActive = true,
                    Value = 110,
                    IsPromotion = true,
                    StartDateTime = DateTime.Now.AddDays(-2),
                    ProductId = 1
                }
            }
        };

        // Act
        var result = mapper.Map<WebsiteProductDto>(product, opt => { opt.Items["LanguageCode"] = "pl-PL"; });

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(product.ProductTranslations.First(pt => pt.Language == languagePl).Name);
        result.Description.Should().Be(product.ProductTranslations.First(pt => pt.Language == languagePl).Description);
        result.Price.Value.Should().Be(product.ProductPrices.First(pp => !pp.IsPromotion).Value);
        result.PromotionalPrice?.Value.Should().Be(110);
        result.Last30DaysLowestPrice.Should().Be(100);
    }
}