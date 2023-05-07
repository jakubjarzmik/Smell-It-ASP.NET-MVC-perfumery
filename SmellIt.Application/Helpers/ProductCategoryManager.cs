using SmellIt.Application.SmellIt.ProductCategories;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Helpers;
public static class ProductCategoryManager
{
    public static IEnumerable<ProductCategory> SortCategories(IEnumerable<ProductCategory> categories, ProductCategory? parent = null)
    {
        List<ProductCategory> sortedCategories = new List<ProductCategory>();

        var productCategories = categories.ToList();

        foreach (var category in productCategories)
        {
            if (category.ParentCategory == parent)
            {
                sortedCategories.Add(category);
                sortedCategories.AddRange(SortCategories(productCategories, category));
            }
        }
        return sortedCategories;
    }

    public static string GeneratePrefix(ProductCategoryDto category)
    {
        if (category.ParentCategory == null)
        {
            return "";
        }
        else
        {
            return "--- " + GeneratePrefix(category.ParentCategory);
        }
    }
}
