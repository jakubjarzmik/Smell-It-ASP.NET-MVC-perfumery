using FluentAssertions;
using SmellIt.Application.Helpers;
using SmellIt.Domain.Entities;
using Xunit;

namespace SmellIt.ApplicationTests.Helpers;

public class ProductCategorySorterTests
{
    private readonly ProductCategorySorter _sorter;

    public ProductCategorySorterTests()
    {
        _sorter = new ProductCategorySorter();
    }

    public static IEnumerable<object[]> CategoryData()
    {
        DateTime now = DateTime.Now;

        var grandChild1 = new ProductCategory { Id = 4, ParentCategory = null, CreatedAt = now.AddDays(-4) };
        var grandChild2 = new ProductCategory { Id = 5, ParentCategory = null, CreatedAt = now.AddDays(-3) };
        var child1 = new ProductCategory { Id = 2, ParentCategory = null, ProductCategories = new List<ProductCategory> { grandChild1 }, CreatedAt = now.AddDays(-2) };
        var child2 = new ProductCategory { Id = 3, ParentCategory = null, ProductCategories = new List<ProductCategory> { grandChild2 }, CreatedAt = now.AddDays(-1) };
        var parent = new ProductCategory { Id = 1, ProductCategories = new List<ProductCategory> { child1, child2 }, ParentCategory = null, CreatedAt = now };
        grandChild1.ParentCategory = child1;
        grandChild2.ParentCategory = child2;
        child1.ParentCategory = parent;
        child2.ParentCategory = parent;

        var unsortedCategories1 = new List<ProductCategory> { grandChild1, child1, child2, parent, grandChild2 };
        var sortedCategories1 = new List<ProductCategory> { parent, child1, grandChild1, child2, grandChild2 };

        yield return new object[] { unsortedCategories1, sortedCategories1 };

        var unsortedCategories2 = new List<ProductCategory> { parent, child2, child1, grandChild1, grandChild2 };

        yield return new object[] { unsortedCategories2, sortedCategories1 };

        var unsortedCategories3 = new List<ProductCategory> { grandChild2, grandChild1, child2, child1, parent };

        yield return new object[] { unsortedCategories3, sortedCategories1 };

        var child3 = new ProductCategory { Id = 6, ParentCategory = parent, CreatedAt = now };
        parent.ProductCategories.Add(child3);

        var unsortedCategories4 = new List<ProductCategory> { grandChild2, grandChild1, child2, child3, child1, parent };
        var sortedCategories2 = new List<ProductCategory> { parent, child1, grandChild1, child2, grandChild2, child3 };

        yield return new object[] { unsortedCategories4, sortedCategories2 };
    }


    [Theory]
    [MemberData(nameof(CategoryData))]
    public void SortCategories_ShouldSortCategoriesCorrectly(IEnumerable<ProductCategory> unsortedCategories, IEnumerable<ProductCategory> sortedCategories)
    {
        // Act
        var result = _sorter.SortCategories(unsortedCategories).ToList();

        // Assert
        result.Should().BeEquivalentTo(sortedCategories, options => options.WithStrictOrdering());
    }
}