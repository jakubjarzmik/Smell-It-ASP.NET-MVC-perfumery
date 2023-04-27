using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.PrivacyPolicies.Commands.CreatePrivacyPolicy;
using SmellIt.Application.SmellIt.PrivacyPolicies.Commands.DeletePrivacyPolicyByEncodedName;
using SmellIt.Application.SmellIt.PrivacyPolicies.Commands.EditPrivacyPolicy;
using SmellIt.Application.SmellIt.PrivacyPolicies.Queries.GetAllPrivacyPolicies;
using SmellIt.Application.SmellIt.PrivacyPolicies.Queries.GetPrivacyPolicyByEncodedName;
using SmellIt.Application.ViewModels;
using System.Drawing.Printing;
using SmellIt.Application.SmellIt.Languages.Queries.GetAllLanguages;

namespace SmellIt.Admin.Controllers;
public class PrivacyPoliciesController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PrivacyPoliciesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index(int? page)
    {
        var privacyPolicies = await _mediator.Send(new GetAllPrivacyPoliciesQuery());

        return View(privacyPolicies);
    }

    public async Task<IActionResult> Create()
    {
        var languages = await _mediator.Send(new GetAllLanguagesQuery());
        ViewData["Languages"] = languages;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePrivacyPolicyCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("PrivacyPolicy/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await _mediator.Send(new GetPrivacyPolicyByEncodedNameQuery(encodedName));
        EditPrivacyPolicyCommand model = _mapper.Map<EditPrivacyPolicyCommand>(dto);
        return View(model);
    }
    
    public async Task<IActionResult> Delete(string encodedName)
    {
        await _mediator.Send(new DeletePrivacyPolicyByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Route("PrivacyPolicy/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName, EditPrivacyPolicyCommand command)
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