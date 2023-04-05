using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmellIt.Domain.Entities.Abstract
{
    public abstract class BaseEntity
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("CreatedBy")]
        public int CreatedByID { get; set; }
        public User CreatedBy { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        [ForeignKey("ModifiedBy")]
        public int? ModifiedById { get; set; }
        public User? ModifiedBy { get; set; } = default!;
        public DateTime? ModifiedDate { get; set; }
        [ForeignKey("DeletedBy")]
        public int? DeletedById { get; set; }
        public User? DeletedBy { get; set; } = default!;
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
