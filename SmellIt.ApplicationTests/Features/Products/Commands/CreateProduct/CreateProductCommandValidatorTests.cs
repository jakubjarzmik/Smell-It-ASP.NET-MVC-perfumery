using FluentValidation.TestHelper;
using SmellIt.Application.Features.Products.Commands.CreateProduct;
using Xunit;

namespace SmellIt.ApplicationTests.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidatorTests
{
    [Theory]
    [InlineData("Test walidatora", "Validator test", "test", "123", "110")]
    [InlineData("Test 2", "Test 2", "test-2", "10", null)]
    [InlineData("T3", "T3", "t3", "150", "149")]
    public void Validate_WithValidCommand_ShouldNotHaveValidationError(string namePl, string nameEn, string productCategoryEncodedName, string priceValue, string? promotionalPriceValue)
    {
        // Arrange
        var validator = new CreateProductCommandValidator();
        var command = new CreateProductCommand
        {
            NamePl = namePl,
            NameEn = nameEn,
            ProductCategoryEncodedName = productCategoryEncodedName,
            PriceValue = Convert.ToDecimal(priceValue),
            PromotionalPriceValue = promotionalPriceValue != null ? Convert.ToDecimal(promotionalPriceValue) : null
        };

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
    [Theory]
    [InlineData("T", "T", "", "123", "123")]
    [InlineData("T", "T", "", "0", "0")]
    [InlineData("T", "T", "", "0", "-2")]
    [InlineData("T", "T", "", "-5", "-10")]
    public void Validate_WithInvalidCommand_ShouldHaveValidationError(string namePl, string nameEn, string productCategoryEncodedName, string priceValue, string? promotionalPriceValue)
    {
        // Arrange
        var validator = new CreateProductCommandValidator();
        var command = new CreateProductCommand
        {
            NamePl = namePl,
            NameEn = nameEn,
            ProductCategoryEncodedName = productCategoryEncodedName,
            PriceValue = Convert.ToDecimal(priceValue),
            PromotionalPriceValue = Convert.ToDecimal(promotionalPriceValue)
        };

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(c=>c.NamePl);
        result.ShouldHaveValidationErrorFor(c=>c.NameEn);
        result.ShouldHaveValidationErrorFor(c=>c.ProductCategoryEncodedName);
        Assert.Contains(result.Errors, e => e.PropertyName is nameof(command.PriceValue) or nameof(command.PromotionalPriceValue));
    }
}