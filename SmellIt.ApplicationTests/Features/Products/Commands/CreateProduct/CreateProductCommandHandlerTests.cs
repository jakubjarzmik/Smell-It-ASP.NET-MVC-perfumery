using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using SmellIt.Application.Features.ProductPrices.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Models;
using SmellIt.Application.Features.Products.Commands.CreateProduct;
using SmellIt.Application.Helpers.Images;
using SmellIt.Domain.Interfaces;
using Xunit;

namespace SmellIt.ApplicationTests.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandlerTests
{
    [Fact]
    public async Task Handle_CreatesProduct_WhenUserHasAdminRole()
    {
        // Arrange
        var command = new CreateProductCommand
        {
            EncodedName = "test",
            NamePl = "Test",
            NameEn = "Test",
            Price = new ProductPriceDto { Value = 123 },
        };

        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(c => c.GetCurrentUser())
            .Returns(new CurrentUser("1", "test@test.com", new List<string>() { "Admin" }));

        var productRepositoryMock = new Mock<IProductRepository>();
        var productCategoryRepositoryMock = new Mock<IProductCategoryRepository>();
        var brandRepositoryMock = new Mock<IBrandRepository>();
        var fragranceCategoryRepositoryMock = new Mock<IFragranceCategoryRepository>();
        var productPriceRepositoryMock = new Mock<IProductPriceRepository>();
        var productImageRepositoryMock = new Mock<IProductImageRepository>();
        var languageRepositoryMock = new Mock<ILanguageRepository>();
        var mapperMock = new Mock<IMapper>();
        var imageUploaderMock = new Mock<IImageUploader>();

        var handler = new CreateProductCommandHandler(userContextMock.Object, productRepositoryMock.Object, productCategoryRepositoryMock.Object,
            brandRepositoryMock.Object, fragranceCategoryRepositoryMock.Object, productPriceRepositoryMock.Object,
            productImageRepositoryMock.Object, languageRepositoryMock.Object, mapperMock.Object, imageUploaderMock.Object);


        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().Be(Unit.Value);
        productRepositoryMock.Verify(m=>m.CreateAsync(It.IsAny<Product>()), Times.Once);
    }

    [Theory]
    [InlineData("Employee")]
    [InlineData("Client")]
    [InlineData(null)]
    public async Task Handle_NotCreatesProduct_WhenUserHaveNotAdminRole(string role)
    {
        // Arrange
        var command = new CreateProductCommand
        {
            EncodedName = "test",
            NamePl = "Test",
            NameEn = "Test",
            Price = new ProductPriceDto { Value = 123 },
        };

        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(c => c.GetCurrentUser())
            .Returns(new CurrentUser("1", "test@test.com", new List<string>() { role }));

        var productRepositoryMock = new Mock<IProductRepository>();
        var productCategoryRepositoryMock = new Mock<IProductCategoryRepository>();
        var brandRepositoryMock = new Mock<IBrandRepository>();
        var fragranceCategoryRepositoryMock = new Mock<IFragranceCategoryRepository>();
        var productPriceRepositoryMock = new Mock<IProductPriceRepository>();
        var productImageRepositoryMock = new Mock<IProductImageRepository>();
        var languageRepositoryMock = new Mock<ILanguageRepository>();
        var mapperMock = new Mock<IMapper>();
        var imageUploaderMock = new Mock<IImageUploader>();

        var handler = new CreateProductCommandHandler(userContextMock.Object, productRepositoryMock.Object, productCategoryRepositoryMock.Object,
            brandRepositoryMock.Object, fragranceCategoryRepositoryMock.Object, productPriceRepositoryMock.Object,
            productImageRepositoryMock.Object, languageRepositoryMock.Object, mapperMock.Object, imageUploaderMock.Object);


        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().Be(Unit.Value);
        productRepositoryMock.Verify(m=>m.CreateAsync(It.IsAny<Product>()), Times.Never);
    }
}