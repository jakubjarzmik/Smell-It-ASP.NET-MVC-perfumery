using SmellIt.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmellIt.Domain.Entities
{
    public class ProductCategory : DictionaryEntity
    {
        [ForeignKey("ParentCategory")]
        public int? ParentCategoryId { get; set; }
        public virtual ProductCategory? ParentCategory { get; set; }
    }
}
