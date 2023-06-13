using FluentAssertions;
using SmellIt.Application.Features.ProductCategories.DTOs;
using SmellIt.Application.Helpers;
using Xunit;

namespace SmellIt.ApplicationTests.Helpers;

public class ProductCategoryPrefixGeneratorTests
{
    private readonly IProductCategoryPrefixGenerator _generator;

    public ProductCategoryPrefixGeneratorTests()
    {
        _generator = new ProductCategoryPrefixGenerator();
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData("--- ", 1)]
    [InlineData("--- --- ", 2)]
    [InlineData("--- --- --- ", 3)]
    public void GeneratePrefix_ShouldReturnCorrectPrefixBasedOnParentCategoryDepth(string expected, int depth)
    {
        // Arrange
        var category = new ProductCategoryDto();
        var currentCategory = category;

        for (int i = 0; i < depth; i++)
        {
            currentCategory.ParentCategory = new ProductCategoryDto();
            currentCategory = currentCategory.ParentCategory;
        }

        // Act
        var result = _generator.GeneratePrefix(category);

        // Assert
        result.Should().Be(expected);
    }
}