using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.ProductCategories.Commands.CreateProductCategory;
using SmellIt.Application.SmellIt.ProductCategories.Commands.DeleteProductCategoryByEncodedName;
using SmellIt.Application.SmellIt.ProductCategories.Commands.EditProductCategory;
using SmellIt.Application.SmellIt.ProductCategories.Queries.GetAllProductCategories;
using SmellIt.Application.SmellIt.ProductCategories.Queries.GetPaginatedProductCategories;
using SmellIt.Application.SmellIt.ProductCategories.Queries.GetProductCategoryByEncodedName;

namespace SmellIt.Admin.Controllers;
public class ProductCategoriesController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductCategoriesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index(int? page)
    {
        ViewData["ProductCategories"] = await _mediator.Send(new GetAllProductCategoriesQuery());
        var viewModel = await _mediator.Send(new GetPaginatedProductCategoriesQuery(page, 7));
        return View(viewModel);
    }

    public async Task<IActionResult> Create()
    {
        ViewData["ProductCategories"] = await _mediator.Send(new GetAllProductCategoriesQuery());
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCategoryCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("ProductCategories/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        ViewData["ProductCategories"] = await _mediator.Send(new GetAllProductCategoriesQuery());
        var dto = await _mediator.Send(new GetProductCategoryByEncodedNameQuery(encodedName));
        EditProductCategoryCommand model = _mapper.Map<EditProductCategoryCommand>(dto);
        return View(model);
    }
    
    public async Task<IActionResult> Delete(string encodedName)
    {
        await _mediator.Send(new DeleteProductCategoryByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Route("ProductCategories/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName, EditProductCategoryCommand command)
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