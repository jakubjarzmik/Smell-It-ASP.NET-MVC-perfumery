using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.Helpers;
using SmellIt.Application.Features.ProductCategories.Commands.CreateProductCategory;
using SmellIt.Application.Features.ProductCategories.Commands.DeleteProductCategoryByEncodedName;
using SmellIt.Application.Features.ProductCategories.Commands.EditProductCategory;
using SmellIt.Application.Features.ProductCategories.Queries.GetAllProductCategories;
using SmellIt.Application.Features.ProductCategories.Queries.GetPaginatedProductCategories;
using SmellIt.Application.Features.ProductCategories.Queries.GetProductCategoryByEncodedName;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace SmellIt.Admin.Controllers;

[Route("product-categories")]
public class ProductCategoriesController : BaseController
{
    private readonly IProductCategoryPrefixGenerator _prefixGenerator;

    public ProductCategoriesController(IMediator mediator, IMapper mapper, IProductCategoryPrefixGenerator prefixGenerator) : base(mediator, mapper)
    {
        _prefixGenerator = prefixGenerator;
    }

    public async Task<IActionResult> Index([FromQuery(Name = "page-number")] int? pageNumber)
    {
        await LoadViewBags();
        var viewModel = await Mediator.Send(new GetPaginatedProductCategoriesQuery(pageNumber, 7));
        return View(viewModel);
    }

    [Authorize(Roles = "Admin")]
    [Route("create")]
    public async Task<IActionResult> Create()
    {
        await LoadViewBags();
        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateProductCategoryCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Authorize(Roles = "Admin")]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        await LoadViewBags();
        var dto = await Mediator.Send(new GetProductCategoryByEncodedNameQuery(encodedName));
        EditProductCategoryCommand model = Mapper.Map<EditProductCategoryCommand>(dto);
        return View(model);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditProductCategoryCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Authorize(Roles = "Admin")]
    [Route("{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteProductCategoryByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
    private async Task LoadViewBags()
    {
        ViewBag.ProductCategories = await Mediator.Send(new GetAllProductCategoriesQuery());
        ViewBag.PrefixGenerator = _prefixGenerator;
    }
}