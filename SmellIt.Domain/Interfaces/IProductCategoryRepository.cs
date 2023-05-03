using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IProductCategoryRepository : IBaseRepository<ProductCategory>
{
    Task<IEnumerable<ProductCategory>> GetProductCategoriesByParentCategory(ProductCategory parentCategory);
    Task<ProductCategory?> GetByNameEn(string nameEn);
}
