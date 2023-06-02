using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.Features.PrivacyPolicies.Commands.CreatePrivacyPolicy;
using SmellIt.Application.Features.PrivacyPolicies.Commands.DeletePrivacyPolicyByEncodedName;
using SmellIt.Application.Features.PrivacyPolicies.Commands.EditPrivacyPolicy;
using SmellIt.Application.Features.PrivacyPolicies.Queries.GetAllPrivacyPolicies;
using SmellIt.Application.Features.PrivacyPolicies.Queries.GetPrivacyPolicyByEncodedName;
using SmellIt.Application.Features.Languages.Queries.GetAllLanguages;

namespace SmellIt.Admin.Controllers;

[Route("privacy-policies")]
public class PrivacyPoliciesController : BaseController
{
    public PrivacyPoliciesController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    public async Task<IActionResult> Index(int? page)
    {
        var privacyPolicies = await Mediator.Send(new GetAllPrivacyPoliciesQuery());

        return View(privacyPolicies);
    }
    [Route("create")]
    public async Task<IActionResult> Create()
    {
        var languages = await Mediator.Send(new GetAllLanguagesQuery());
        ViewBag.Languages = languages;
        return View();
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreatePrivacyPolicyCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await Mediator.Send(new GetPrivacyPolicyByEncodedNameQuery(encodedName));
        EditPrivacyPolicyCommand model = Mapper.Map<EditPrivacyPolicyCommand>(dto);
        return View(model);
    }

    [HttpPost]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditPrivacyPolicyCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }


    [Route("{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeletePrivacyPolicyByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}