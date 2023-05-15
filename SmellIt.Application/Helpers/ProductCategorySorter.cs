using SmellIt.Domain.Entities;

namespace SmellIt.Application.Helpers;
public interface IProductCategorySorter : IHelper
{
    IEnumerable<ProductCategory> SortCategories(IEnumerable<ProductCategory> categories, ProductCategory? parent = null);
}

public class ProductCategorySorter : IProductCategorySorter
{
    public IEnumerable<ProductCategory> SortCategories(IEnumerable<ProductCategory> categories, ProductCategory? parent = null)
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
}