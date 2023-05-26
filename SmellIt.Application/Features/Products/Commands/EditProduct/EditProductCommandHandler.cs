using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Products.Commands.EditProduct
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

        public EditProductCommandHandler(
            IProductRepository productRepository,
            IProductCategoryRepository productCategoryRepository,
            IBrandRepository brandRepository,
            IFragranceCategoryRepository fragranceCategoryRepository,
            IGenderRepository genderRepository,
            IProductPriceRepository productPriceRepository,
            IMapper mapper)
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
            var product = await _productRepository.GetByEncodedNameAsync(request.EncodedName);
            product.ModifiedAt = DateTime.Now;

            await UpdateProductDetails(request, product);
            UpdateTranslations(request, product);
            await UpdateProductPrices(request, product);

            product.EncodeName();
            await _productRepository.CommitAsync();

            return Unit.Value;
        }

        private async Task UpdateProductDetails(EditProductCommand request, Product product)
        {
            if (!string.IsNullOrWhiteSpace(request.ProductCategoryEncodedName))
                product.ProductCategory = await _productCategoryRepository.GetByEncodedNameAsync(request.ProductCategoryEncodedName);

            if (!string.IsNullOrWhiteSpace(request.BrandEncodedName))
                product.Brand = await _brandRepository.GetByEncodedNameAsync(request.BrandEncodedName);

            if (!string.IsNullOrWhiteSpace(request.FragranceCategoryEncodedName))
                product.FragranceCategory = await _fragranceCategoryRepository.GetByEncodedNameAsync(request.FragranceCategoryEncodedName);

            if (request.GenderId != null)
                product.Gender = await _genderRepository.GetByIdAsync(request.GenderId.Value);

            product.Capacity = request.Capacity;
        }

        private void UpdateTranslations(EditProductCommand request, Product product)
        {
            var translations = new Dictionary<string, (string Name, string? Description)>
        {
            { "pl-PL", (request.NamePl, request.DescriptionPl) },
            { "en-GB", (request.NameEn, request.DescriptionEn) }
        };

            foreach (var translation in translations)
            {
                var productTranslation = product.ProductTranslations.First(pt => pt.Language.Code == translation.Key);
                productTranslation.Name = translation.Value.Name;
                productTranslation.Description = translation.Value.Description;
                productTranslation.ModifiedAt = DateTime.Now;
            }
        }

        private async Task UpdateProductPrices(EditProductCommand request, Product product)
        {
            var productPrices = await _productPriceRepository.GetByProductAsync(product);

            var standardPrice = productPrices.First(pp => !pp.IsPromotion);
            if (request.PriceValue != standardPrice.Value)
            {
                standardPrice.EndDateTime = DateTime.Now;
                await _productPriceRepository.CreateAsync(
                    new ProductPrice
                    {
                        Product = product,
                        Value = request.PriceValue,
                        StartDateTime = request.PriceStartDateTime,
                        EndDateTime = request.PriceEndDateTime
                    });
            }

            var promotionalPrice = productPrices.FirstOrDefault(pp => pp.IsPromotion);
            if (request.PromotionalPriceValue != promotionalPrice?.Value)
            {
                if (promotionalPrice != null)
                {
                    promotionalPrice.EndDateTime = DateTime.Now;
                }

                if (request.PromotionalPriceValue != null)
                {
                    await _productPriceRepository.CreateAsync(
                        new ProductPrice
                        {
                            Product = product,
                            Value = (decimal)request.PromotionalPriceValue,
                            IsPromotion = true,
                            StartDateTime = (request.PromotionalPriceStartDateTime ?? DateTime.Now),
                            EndDateTime = request.PromotionalPriceEndDateTime
                        });
                }
            }
        }
    }
}
