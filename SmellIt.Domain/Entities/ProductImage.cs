﻿using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        [MaxLength(255)]
        public string ImagePath { get; set; } = default!;

        [MaxLength(50)] 
        public string ImageAlt { get; set; } = default!;

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;
        
        public override void EncodeName() => 
            EncodedName = ImageAlt.ConvertToEncodedName();
    }
}
