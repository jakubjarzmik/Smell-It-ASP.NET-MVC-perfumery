using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Helpers;
using SmellIt.Application.SmellIt.Brands.Queries.GetAllBrands;
using SmellIt.Application.SmellIt.FragranceCategories.Queries.GetAllFragranceCategories;
using SmellIt.Application.SmellIt.Genders.Queries.GetAllGenders;
using SmellIt.Application.SmellIt.ProductCategories.Queries.GetAllProductCategories;
using SmellIt.Application.SmellIt.Products.Commands.CreateProduct;
using SmellIt.Application.SmellIt.Products.Commands.DeleteProductByEncodedName;
using SmellIt.Application.SmellIt.Products.Commands.EditProduct;
using SmellIt.Application.SmellIt.Products.Queries.GetPaginatedProducts;
using SmellIt.Application.SmellIt.Products.Queries.GetProductByEncodedName;

namespace SmellIt.Admin.Controllers;
public class ProductsController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IProductCategoryPrefixGenerator _prefixGenerator;

    public ProductsController(IMediator mediator, IMapper mapper, IProductCategoryPrefixGenerator prefixGenerator)
    {
        _mediator = mediator;
        _mapper = mapper;
        _prefixGenerator = prefixGenerator;
    }
    private async Task LoadViewData()
    {
        ViewData["PrefixGenerator"] = _prefixGenerator;
        ViewData["ProductCategories"] = await _mediator.Send(new GetAllProductCategoriesQuery());
        ViewData["Brands"] = await _mediator.Send(new GetAllBrandsQuery());
        ViewData["FragranceCategories"] = await _mediator.Send(new GetAllFragranceCategoriesQuery());
        ViewData["Genders"] = await _mediator.Send(new GetAllGendersQuery());
    }
    public async Task<IActionResult> Index(int? page)
    {
        await LoadViewData();

        var viewModel = await _mediator.Send(new GetPaginatedProductsQuery(page, 7));
        return View(viewModel);
    }

    public async Task<IActionResult> Create()
    {
        await LoadViewData();

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("Products/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        await LoadViewData();

        var dto = await _mediator.Send(new GetProductByEncodedNameQuery(encodedName));
        EditProductCommand model = _mapper.Map<EditProductCommand>(dto);
        return View(model);
    }

    public async Task<IActionResult> Delete(string encodedName)
    {
        await _mediator.Send(new DeleteProductByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Route("Products/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName, EditProductCommand command)
    {
        command.EncodedName = encodedName;
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
}