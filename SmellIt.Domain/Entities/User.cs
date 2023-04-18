using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
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
        public string Login { get; set; } = default!;
        [MaxLength(50)]
        public string Password { get; set; } = default!;
        public bool IsAdmin { get; set; } = false;

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }

        public virtual ICollection<Address> CreatedAddresses { get; set; } = default!;
        public virtual ICollection<Brand> CreatedBrands { get; set; } = default!;
        public virtual ICollection<BrandTranslation> CreatedBrandTranslations { get; set; } = default!;
        public virtual ICollection<FragranceCategory> CreatedFragranceCategories { get; set; } = default!;
        public virtual ICollection<FragranceCategoryTranslation> CreatedFragranceCategoryTranslations { get; set; } = default!;
        public virtual ICollection<Gender> CreatedGenders { get; set; } = default!;
        public virtual ICollection<GenderTranslation> CreatedGenderTranslations { get; set; } = default!;
        public virtual ICollection<Language> CreatedLanguages { get; set; } = default!;
        public virtual ICollection<Product> CreatedProducts { get; set; } = default!;
        public virtual ICollection<ProductTranslation> CreatedProductTranslations { get; set; } = default!;
        public virtual ICollection<ProductCategory> CreatedProductCategories { get; set; } = default!;
        public virtual ICollection<ProductCategoryTranslation> CreatedProductCategoryTranslations { get; set; } = default!;
        public virtual ICollection<ProductImage> CreatedProductImages{ get; set; } = default!;
        public virtual ICollection<User> CreatedUsers { get; set; } = default!;

        public virtual ICollection<Address>? ModifiedAddresses { get; set; } = default!;
        public virtual ICollection<Brand>? ModifiedBrands { get; set; } = default!;
        public virtual ICollection<BrandTranslation>? ModifiedBrandTranslations { get; set; } = default!;
        public virtual ICollection<FragranceCategory>? ModifiedFragranceCategories { get; set; } = default!;
        public virtual ICollection<FragranceCategoryTranslation>? ModifiedFragranceCategoryTranslations { get; set; } = default!;
        public virtual ICollection<Gender>? ModifiedGenders { get; set; } = default!;
        public virtual ICollection<GenderTranslation>? ModifiedGenderTranslations { get; set; } = default!;
        public virtual ICollection<Language> ModifiedLanguages { get; set; } = default!;
        public virtual ICollection<Product> ModifiedProducts { get; set; } = default!;
        public virtual ICollection<ProductTranslation> ModifiedProductTranslations { get; set; } = default!;
        public virtual ICollection<ProductCategory>? ModifiedProductCategories { get; set; } = default!;
        public virtual ICollection<ProductCategoryTranslation>? ModifiedProductCategoryTranslations { get; set; } = default!;
        public virtual ICollection<ProductImage>? ModifiedProductImages { get; set; } = default!;
        public virtual ICollection<User>? ModifiedUsers { get; set; } = default!;

        public virtual ICollection<Address>? DeletedAddresses { get; set; } = default!;
        public virtual ICollection<Brand>? DeletedBrands { get; set; } = default!;
        public virtual ICollection<BrandTranslation>? DeletedBrandTranslations { get; set; } = default!;
        public virtual ICollection<FragranceCategory>? DeletedFragranceCategories { get; set; } = default!;
        public virtual ICollection<FragranceCategoryTranslation>? DeletedFragranceCategoryTranslations { get; set; } = default!;
        public virtual ICollection<Gender>? DeletedGenders { get; set; } = default!;
        public virtual ICollection<GenderTranslation>? DeletedGenderTranslations { get; set; } = default!;
        public virtual ICollection<Language> DeletedLanguages { get; set; } = default!;
        public virtual ICollection<Product> DeletedProducts { get; set; } = default!;
        public virtual ICollection<ProductTranslation> DeletedProductTranslations { get; set; } = default!;
        public virtual ICollection<ProductCategory>? DeletedProductCategories { get; set; } = default!;
        public virtual ICollection<ProductCategoryTranslation>? DeletedProductCategoryTranslations { get; set; } = default!;
        public virtual ICollection<ProductImage>? DeletedProductImages { get; set; } = default!;
        public virtual ICollection<User>? DeletedUsers { get; set; } = default!;
        
        public override void EncodeName() => EncodedName = Login;
    }
}
