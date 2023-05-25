using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IProductCategoryRepository : IBaseRepositoryWithEncodedName<ProductCategory>
{
    Task<IEnumerable<ProductCategory>> GetProductCategoriesByParentCategoryAsync(ProductCategory parentCategory);
}
