using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; } = default!;
        [MaxLength(50)]
        public string LastName { get; set; } = default!;
        [MaxLength(255)]
        public string Email { get; set; } = default!;
        [MaxLength(50)]
        public string Password { get; set; } = default!;
        public bool IsAdmin { get; set; } = false;

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }

        public virtual ICollection<Address> CreatedAddresses { get; set; } = default!;
        public virtual ICollection<Brand> CreatedBrands { get; set; } = default!;
        public virtual ICollection<FragranceGroup> CreatedFragranceGroups { get; set; } = default!;
        public virtual ICollection<Gender> CreatedGenders { get; set; } = default!;
        public virtual ICollection<Product> CreatedProducts { get; set; } = default!;
        public virtual ICollection<ProductCategory> CreatedProductCategories { get; set; } = default!;
        public virtual ICollection<ProductImage> CreatedProductImages{ get; set; } = default!;
        public virtual ICollection<User> CreatedUsers { get; set; } = default!;
        public virtual ICollection<TranslationEngb> CreatedTranslationsEngbs { get; set; } = default!;
        public virtual ICollection<TranslationPlpl> CreatedTranslationsPlpls { get; set; } = default!;

        public virtual ICollection<Address>? ModifiedAddresses { get; set; } = default!;
        public virtual ICollection<Brand>? ModifiedBrands { get; set; } = default!;
        public virtual ICollection<FragranceGroup>? ModifiedFragranceGroups { get; set; } = default!;
        public virtual ICollection<Gender>? ModifiedGenders { get; set; } = default!;
        public virtual ICollection<Product> ModifiedProducts { get; set; } = default!;
        public virtual ICollection<ProductCategory>? ModifiedProductCategories { get; set; } = default!;
        public virtual ICollection<ProductImage>? ModifiedProductImages { get; set; } = default!;
        public virtual ICollection<User>? ModifiedUsers { get; set; } = default!;
        public virtual ICollection<TranslationEngb>? ModifiedTranslationEngbs { get; set; } = default!;
        public virtual ICollection<TranslationPlpl>? ModifiedTranslationPlpls { get; set; } = default!;

        public virtual ICollection<Address>? DeletedAddresses { get; set; } = default!;
        public virtual ICollection<Brand>? DeletedBrands { get; set; } = default!;
        public virtual ICollection<FragranceGroup>? DeletedFragranceGroups { get; set; } = default!;
        public virtual ICollection<Gender>? DeletedGenders { get; set; } = default!;
        public virtual ICollection<Product> DeletedProducts { get; set; } = default!;
        public virtual ICollection<ProductCategory>? DeletedProductCategories { get; set; } = default!;
        public virtual ICollection<ProductImage>? DeletedProductImages { get; set; } = default!;
        public virtual ICollection<User>? DeletedUsers { get; set; } = default!;
        public virtual ICollection<TranslationEngb>? DeletedTranslationEngbs { get; set; } = default!;
        public virtual ICollection<TranslationPlpl>? DeletedTranslationPlpls { get; set; } = default!;

    }
}
