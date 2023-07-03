using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Brands.DTOs;
using SmellIt.Application.Features.FragranceCategories.DTOs;
using SmellIt.Application.Features.Genders.DTOs;
using SmellIt.Application.Features.ProductCategories.DTOs;
using SmellIt.Application.Helpers.Images;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using System.Globalization;

namespace SmellIt.Application.Features.Products.Commands.CreateProduct;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly IFragranceCategoryRepository _fragranceCategoryRepository;
    private readonly IGenderRepository _genderRepository;
    private readonly IProductPriceRepository _productPriceRepository;
    private readonly IProductImageRepository _productImageRepository;
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    private readonly IImageUploader _imageUploader;

    public CreateProductCommandHandler(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository,
        IBrandRepository brandRepository, IFragranceCategoryRepository fragranceCategoryRepository,
        IGenderRepository genderRepository, IProductPriceRepository productPriceRepository, IProductImageRepository productImageRepository,
        ILanguageRepository languageRepository, IMapper mapper, IImageUploader imageUploader)
    {
        _productRepository = productRepository;
        _productCategoryRepository = productCategoryRepository;
        _brandRepository = brandRepository;
        _fragranceCategoryRepository = fragranceCategoryRepository;
        _genderRepository = genderRepository;
        _productPriceRepository = productPriceRepository;
        _productImageRepository = productImageRepository;
        _languageRepository = languageRepository;
        _mapper = mapper;
        _imageUploader = imageUploader;
    }
    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var plLanguage = await _languageRepository.GetByCodeAsync("pl-PL");
        var enLanguage = await _languageRepository.GetByCodeAsync("en-GB");

        var product = _mapper.Map<Product>(request);

        if (plLanguage != null && enLanguage != null)
        {
            product.ProductTranslations = new List<ProductTranslation>
            {
                new ProductTranslation { Language = plLanguage, Name = request.NamePl, Description = request.DescriptionPl },
                new ProductTranslation { Language = enLanguage, Name = request.NameEn, Description = request.DescriptionEn }
            };
        }


        await SetRelatedEntitiesAsync(request, product);

        await _productRepository.CreateAsync(product);

        await ProcessImagesAsync(request, product);
        await ProcessProductPriceAsync(request, product);

        return Unit.Value;
    }

    private async Task SetRelatedEntitiesAsync(CreateProductCommand request, Product product)
    {
        if (!string.IsNullOrWhiteSpace(request.ProductCategoryEncodedName))
        {
            product.ProductCategory = await _productCategoryRepository.GetAsync(request.ProductCategoryEncodedName);
        }
        if (!string.IsNullOrWhiteSpace(request.BrandEncodedName))
        {
            product.Brand = await _brandRepository.GetAsync(request.BrandEncodedName);
        }
        if (!string.IsNullOrWhiteSpace(request.FragranceCategoryEncodedName))
        {
            product.FragranceCategory = await _fragranceCategoryRepository.GetAsync(request.FragranceCategoryEncodedName);
        }
        if (request.GenderId != null)
        {
            product.GenderId = request.GenderId;
        }
    }

    private async Task ProcessImagesAsync(CreateProductCommand request, Product product)
    {
        if (request.ImageFiles != null && request.ImageFiles.Count > 0)
        {
            int i = 1;
            foreach (var file in request.ImageFiles)
            {
                string imagePath = await _imageUploader.UploadImageAsync($"products/{product.ProductCategory!.EncodedName}/{product.EncodedName}", file, $"image{i}");
                await _productImageRepository.CreateAsync(new ProductImage { ImageAlt = $"image{i}", ImageUrl = imagePath, Product = product });
                i++;
            }
        }
    }

    private async Task ProcessProductPriceAsync(CreateProductCommand request, Product product)
    {
        await _productPriceRepository.CreateAsync(new ProductPrice { Product = product, Value = request.PriceValue, StartDateTime = DateTime.ParseExact("1900-01-01 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) });

        if (request.PromotionalPriceValue != null)
        {
            await _productPriceRepository.CreateAsync(new ProductPrice { Product = product, Value = (decimal)request.PromotionalPriceValue, IsPromotion = true });
        }
    }
}