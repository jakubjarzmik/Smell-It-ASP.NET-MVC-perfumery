using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.Features.PrivacyPolicies.Commands.CreatePrivacyPolicy;
using SmellIt.Application.Features.PrivacyPolicies.Commands.DeletePrivacyPolicyByEncodedName;
using SmellIt.Application.Features.PrivacyPolicies.Commands.EditPrivacyPolicy;
using SmellIt.Application.Features.PrivacyPolicies.Queries.GetAllPrivacyPolicies;
using SmellIt.Application.Features.PrivacyPolicies.Queries.GetPrivacyPolicyByEncodedName;
using SmellIt.Application.Features.Languages.Queries.GetAllLanguages;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace SmellIt.Admin.Controllers;

[Route("privacy-policies")]
public class PrivacyPoliciesController : BaseController
{
    public PrivacyPoliciesController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    public async Task<IActionResult> Index([FromQuery(Name = "page-number")] int? pageNumber)
    {
        var privacyPolicies = await Mediator.Send(new GetAllPrivacyPoliciesQuery());

        return View(privacyPolicies);
    }

    [Authorize(Roles = "Admin")]
    [Route("create")]
    public async Task<IActionResult> Create()
    {
        var languages = new SelectList(await Mediator.Send(new GetAllLanguagesQuery()), "Code", "Name");

        ViewBag.Languages = languages;
        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreatePrivacyPolicyCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Authorize(Roles = "Admin")]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await Mediator.Send(new GetPrivacyPolicyByEncodedNameQuery(encodedName));
        EditPrivacyPolicyCommand model = Mapper.Map<EditPrivacyPolicyCommand>(dto);
        return View(model);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditPrivacyPolicyCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }


    [Authorize(Roles = "Admin")]
    [Route("{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeletePrivacyPolicyByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}