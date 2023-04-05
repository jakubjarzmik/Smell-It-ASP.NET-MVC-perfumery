﻿using SmellIt.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmellIt.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        [MaxLength(255)]
        public string ImagePath { get; set; } = default!;
        [MaxLength(20)]
        public string? ImageAlt { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;
    }
}
