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

namespace SmellIt.Admin.Controllers;
public class ProductCategoriesController : BaseController
{
    private readonly IProductCategoryPrefixGenerator _prefixGenerator;

    public ProductCategoriesController(IMediator mediator, IMapper mapper, IProductCategoryPrefixGenerator prefixGenerator) : base(mediator, mapper)
    {
        _prefixGenerator = prefixGenerator;
    }
    [Route("product-categories")]
    public async Task<IActionResult> Index(int? page)
    {
        ViewData["PrefixGenerator"] = _prefixGenerator;
        ViewData["ProductCategories"] = await Mediator.Send(new GetAllProductCategoriesQuery());
        var viewModel = await Mediator.Send(new GetPaginatedProductCategoriesQuery(page, 7));
        return View(viewModel);
    }

    [Route("product-categories/create")]
    public async Task<IActionResult> Create()
    {
        ViewData["ProductCategories"] = await Mediator.Send(new GetAllProductCategoriesQuery());
        ViewData["PrefixGenerator"] = _prefixGenerator;
        return View();
    }

    [HttpPost]
    [Route("product-categories/create")]
    public async Task<IActionResult> Create(CreateProductCategoryCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await Mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("product-categories/{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        ViewData["PrefixGenerator"] = _prefixGenerator;
        ViewData["ProductCategories"] = await Mediator.Send(new GetAllProductCategoriesQuery());
        var dto = await Mediator.Send(new GetProductCategoryByEncodedNameQuery(encodedName));
        EditProductCategoryCommand model = Mapper.Map<EditProductCategoryCommand>(dto);
        return View(model);
    }

    [HttpPost]
    [Route("product-categories/{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditProductCategoryCommand command)
    {
        command.EncodedName = encodedName;
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await Mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("product-categories/{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteProductCategoryByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}