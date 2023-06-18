using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.Helpers;
using SmellIt.Application.Features.Brands.Queries.GetAllBrandsForWebsite;
using SmellIt.Application.Features.FragranceCategories.Queries.GetAllFragranceCategoriesForWebsite;
using SmellIt.Application.Features.ProductCategories.Queries.GetAllProductCategories;
using SmellIt.Application.Features.ProductPrices.Queries.GetAllProductPricesByProductEncodedName;
using SmellIt.Application.Features.Products.Commands.CreateProduct;
using SmellIt.Application.Features.Products.Commands.DeleteProductByEncodedName;
using SmellIt.Application.Features.Products.Commands.EditProduct;
using SmellIt.Application.Features.Products.Queries.GetPaginatedProducts;
using SmellIt.Application.Features.Products.Queries.GetProductByEncodedName;
using SmellIt.Application.Features.Genders.Queries.GetAllGendersForWebsite;

namespace SmellIt.Admin.Controllers;

[Route("products")]
public class ProductsController : BaseController
{
    private readonly IProductCategoryPrefixGenerator _prefixGenerator;

    public ProductsController(IMediator mediator, IMapper mapper, IProductCategoryPrefixGenerator prefixGenerator) : base(mediator, mapper)
    {
        _prefixGenerator = prefixGenerator;
    }
    public async Task<IActionResult> Index([FromQuery(Name = "page-number")] int? pageNumber)
    {
        await LoadViewBagsAsync();

        var viewModel = await Mediator.Send(new GetPaginatedProductsQuery(pageNumber, 7));
        return View(viewModel);
    }

    [Authorize(Roles = "Admin")]
    [Route("create")]
    public async Task<IActionResult> Create()
    {
        await LoadViewBagsAsync();

        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Authorize(Roles = "Admin")]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        await LoadViewBagsAsync();

        ViewBag.ProductPrices = await Mediator.Send(new GetAllProductPricesByProductEncodedNameQuery(encodedName));

        var dto = await Mediator.Send(new GetProductByEncodedNameQuery(encodedName));
        EditProductCommand model = Mapper.Map<EditProductCommand>(dto);
        return View(model);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditProductCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Authorize(Roles = "Admin")]
    [Route("{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteProductByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
    private async Task LoadViewBagsAsync()
    {
        ViewBag.PrefixGenerator = _prefixGenerator;
        ViewBag.ProductCategories = await Mediator.Send(new GetAllProductCategoriesQuery());
        ViewBag.Brands = new SelectList(await Mediator.Send(new GetAllBrandsForWebsiteQuery(CurrentCulture)), "EncodedName", "Name");
        ViewBag.FragranceCategories = new SelectList(await Mediator.Send(new GetAllFragranceCategoriesForWebsiteQuery(CurrentCulture)), "EncodedName", "Name");
        ViewBag.Genders = new SelectList(await Mediator.Send(new GetAllGendersForWebsiteQuery(CurrentCulture)), "Id", "Name");
    }
}