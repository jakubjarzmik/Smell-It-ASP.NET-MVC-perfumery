using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Entities;
public class Brand : DictionaryEntity
{
    public virtual ICollection<Product>? Products { get; set; }
}