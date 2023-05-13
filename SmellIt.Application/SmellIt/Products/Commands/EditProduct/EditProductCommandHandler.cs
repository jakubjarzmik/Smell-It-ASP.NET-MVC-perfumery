using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Products.Commands.EditProduct
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IFragranceCategoryRepository _fragranceCategoryRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly IProductPriceRepository _productPriceRepository;
        private readonly IMapper _mapper;

        public EditProductCommandHandler(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository, IBrandRepository brandRepository,
            IFragranceCategoryRepository fragranceCategoryRepository, IGenderRepository genderRepository, IProductPriceRepository productPriceRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _brandRepository = brandRepository;
            _fragranceCategoryRepository = fragranceCategoryRepository;
            _genderRepository = genderRepository;
            _productPriceRepository = productPriceRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = (await _productRepository.GetByEncodedName(request.EncodedName))!;


            if (!string.IsNullOrWhiteSpace(request.ProductCategoryEncodedName))
                product.ProductCategory = (await _productCategoryRepository.GetByEncodedName(request.ProductCategoryEncodedName!))!;

            if (!string.IsNullOrWhiteSpace(request.BrandEncodedName))
                product.Brand = (await _brandRepository.GetByEncodedName(request.BrandEncodedName!))!;

            if (!string.IsNullOrWhiteSpace(request.FragranceCategoryEncodedName))
                product.FragranceCategory = (await _fragranceCategoryRepository.GetByEncodedName(request.FragranceCategoryEncodedName!))!;

            if (request.GenderId != null)
                product.Gender = (await _genderRepository.GetById(request.GenderId.Value))!;

            product.ModifiedAt = DateTime.UtcNow;

            var plTranslation = product.ProductTranslations.First(fct => fct.Language.Code == "pl-PL");
            plTranslation.Name = request.NamePl;
            plTranslation.Description = request.DescriptionPl;
            plTranslation.ModifiedAt = DateTime.UtcNow;

            var enTranslation = product.ProductTranslations.First(fct => fct.Language.Code == "en-GB");
            enTranslation.Name = request.NameEn;
            enTranslation.Description = request.DescriptionEn;
            enTranslation.ModifiedAt = DateTime.UtcNow;


            var productPrices = _productPriceRepository.GetByProduct(product).Result;
            var productPrice = productPrices.First(pp => !pp.IsPromotion);
            if (request.Price != productPrice.Value)
            {
                productPrice.IsActive = false;
                productPrice.DeletedAt = DateTime.UtcNow;
                await _productPriceRepository.Create(new ProductPrice { Product = product, Value = request.Price });
            }

            var promotionalPrice = productPrices.FirstOrDefault(pp => pp.IsPromotion);
            if (request.PromotionalPrice != promotionalPrice?.Value)
            {
                if (promotionalPrice != null)
                {
                    promotionalPrice.IsActive = false;
                    promotionalPrice.DeletedAt = DateTime.UtcNow;
                }
                if(request.PromotionalPrice != null)
                    await _productPriceRepository.Create(new ProductPrice { Product = product, Value = (decimal)request.PromotionalPrice, IsPromotion = true });
            }


            product.EncodeName();
            await _productRepository.Commit();

            return Unit.Value;
        }
    }
}
