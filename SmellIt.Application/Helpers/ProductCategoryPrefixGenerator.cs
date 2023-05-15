using SmellIt.Application.SmellIt.ProductCategories;

namespace SmellIt.Application.Helpers;
public interface IProductCategoryPrefixGenerator : IHelper
{
    string GeneratePrefix(ProductCategoryDto category);
}

public class ProductCategoryPrefixGenerator : IProductCategoryPrefixGenerator
{
    public string GeneratePrefix(ProductCategoryDto category)
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