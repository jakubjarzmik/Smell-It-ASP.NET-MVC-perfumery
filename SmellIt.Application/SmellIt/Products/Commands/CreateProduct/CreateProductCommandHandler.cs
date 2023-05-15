using AutoMapper;
using MediatR;
using SmellIt.Application.Helpers.Images;
using SmellIt.Application.SmellIt.Brands;
using SmellIt.Application.SmellIt.FragranceCategories;
using SmellIt.Application.SmellIt.Genders;
using SmellIt.Application.SmellIt.ProductCategories;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Products.Commands.CreateProduct;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly IFragranceCategoryRepository _fragranceCategoryRepository;
    private readonly IGenderRepository _genderRepository;
    private readonly IProductPriceRepository _productPriceRepository;
    private readonly IProductImageRepository _productImageRepository;
    private readonly IMapper _mapper;
    private readonly IImageUploader _imageUploader;

    public CreateProductCommandHandler(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository,
        IBrandRepository brandRepository, IFragranceCategoryRepository fragranceCategoryRepository,
        IGenderRepository genderRepository, IProductPriceRepository productPriceRepository, IProductImageRepository productImageRepository,
        IMapper mapper, IImageUploader imageUploader)
    {
        _productRepository = productRepository;
        _productCategoryRepository = productCategoryRepository;
        _brandRepository = brandRepository;
        _fragranceCategoryRepository = fragranceCategoryRepository;
        _genderRepository = genderRepository;
        _productPriceRepository = productPriceRepository;
        _productImageRepository = productImageRepository;
        _mapper = mapper;
        _imageUploader = imageUploader;
    }
    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(request.ProductCategoryEncodedName))
        {
            var productCategory = await _productCategoryRepository.GetByEncodedName(request.ProductCategoryEncodedName!);
            request.ProductCategory = _mapper.Map<ProductCategoryDto>(productCategory);
        }
        if (!string.IsNullOrWhiteSpace(request.BrandEncodedName))
        {
            var brand = await _brandRepository.GetByEncodedName(request.BrandEncodedName!);
            request.Brand = _mapper.Map<BrandDto>(brand);
        }
        if (!string.IsNullOrWhiteSpace(request.FragranceCategoryEncodedName))
        {
            var fragranceCategory = await _fragranceCategoryRepository.GetByEncodedName(request.FragranceCategoryEncodedName!);
            request.FragranceCategory = _mapper.Map<FragranceCategoryDto>(fragranceCategory);
        }
        if (request.GenderId != null)
        {
            var gender = await _genderRepository.GetById(request.GenderId.Value);
            request.Gender = _mapper.Map<GenderDto>(gender);
        }
        var product = _mapper.Map<Product>(request);
        await _productRepository.Create(product);

        if (request.ImageFiles != null && request.ImageFiles.Count > 0)
        {
            int i = 1;
            foreach (var file in request.ImageFiles)
            {
                string imagePath = await _imageUploader.UploadImageAsync($"products/{product.ProductCategory!.EncodedName}/{product.EncodedName}", file, $"image{i}");
                await _productImageRepository.Create(new ProductImage { ImageAlt = $"image{i}", ImageUrl = imagePath, Product = product });
                i++;
            }
        }

        await _productPriceRepository.Create(new ProductPrice { Product = product, Value = request.PriceValue});

        if (request.PromotionalPriceValue != null)
        {
            await _productPriceRepository.Create(new ProductPrice { Product = product, Value = (decimal)request.PromotionalPriceValue!, IsPromotion = true});
        }

        return Unit.Value;
    }
}