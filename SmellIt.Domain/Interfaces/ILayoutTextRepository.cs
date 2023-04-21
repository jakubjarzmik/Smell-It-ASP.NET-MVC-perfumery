using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface ILayoutTextRepository
{
    Task Create(LayoutText layoutText);
    Task<LayoutText?> GetByKey(string key);
    Task<LayoutText?> GetByEncodedName(string encodedName);
    Task<IEnumerable<LayoutText>> GetAll();
    Task Commit();
}
