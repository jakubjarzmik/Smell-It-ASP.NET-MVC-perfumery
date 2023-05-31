using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.Helpers;
using SmellIt.Application.Features.Brands.Queries.GetAllBrands;
using SmellIt.Application.Features.Brands.Queries.GetAllBrandsForWebsite;
using SmellIt.Application.Features.FragranceCategories.Queries.GetAllFragranceCategories;
using SmellIt.Application.Features.FragranceCategories.Queries.GetAllFragranceCategoriesForWebsite;
using SmellIt.Application.Features.Genders.Queries.GetAllGenders;
using SmellIt.Application.Features.ProductCategories.Queries.GetAllProductCategories;
using SmellIt.Application.Features.ProductPrices.Queries.GetAllProductPricesByProductEncodedName;
using SmellIt.Application.Features.Products.Commands.CreateProduct;
using SmellIt.Application.Features.Products.Commands.DeleteProductByEncodedName;
using SmellIt.Application.Features.Products.Commands.EditProduct;
using SmellIt.Application.Features.Products.Queries.GetPaginatedProducts;
using SmellIt.Application.Features.Products.Queries.GetProductByEncodedName;
using SmellIt.Application.Features.Genders.Queries.GetAllGendersForWebsite;

namespace SmellIt.Admin.Controllers;
public class ProductsController : BaseController
{
    private readonly IProductCategoryPrefixGenerator _prefixGenerator;

    public ProductsController(IMediator mediator, IMapper mapper, IProductCategoryPrefixGenerator prefixGenerator) : base(mediator, mapper)
    {
        _prefixGenerator = prefixGenerator;
    }

    [Route("products")]
    public async Task<IActionResult> Index(int? page)
    {
        await LoadViewData();

        var viewModel = await Mediator.Send(new GetPaginatedProductsQuery(page, 7));
        return View(viewModel);
    }

    [Route("products/create")]
    public async Task<IActionResult> Create()
    {
        await LoadViewData();

        return View();
    }

    [HttpPost]
    [Route("products/create")]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await Mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("products/{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        await LoadViewData();

        ViewData["ProductPrices"] = await Mediator.Send(new GetAllProductPricesByProductEncodedNameQuery(encodedName));

        var dto = await Mediator.Send(new GetProductByEncodedNameQuery(encodedName));
        EditProductCommand model = Mapper.Map<EditProductCommand>(dto);
        return View(model);
    }

    [HttpPost]
    [Route("products/{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditProductCommand command)
    {
        command.EncodedName = encodedName;
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await Mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("products/{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteProductByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
    private async Task LoadViewData()
    {
        ViewBag.PrefixGenerator = _prefixGenerator;
        ViewBag.ProductCategories = await Mediator.Send(new GetAllProductCategoriesQuery());
        ViewBag.Brands = new SelectList(await Mediator.Send(new GetAllBrandsForWebsiteQuery(CurrentCulture)), "EncodedName", "Name");
        ViewBag.FragranceCategories = new SelectList(await Mediator.Send(new GetAllFragranceCategoriesForWebsiteQuery(CurrentCulture)), "EncodedName", "Name");
        ViewBag.Genders = new SelectList(await Mediator.Send(new GetAllGendersForWebsiteQuery(CurrentCulture)), "Id", "Name");
    }
}