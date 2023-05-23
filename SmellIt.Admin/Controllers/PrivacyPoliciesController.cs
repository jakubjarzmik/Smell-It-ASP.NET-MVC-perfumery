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
public class PrivacyPoliciesController : BaseController
{
    public PrivacyPoliciesController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    [Route("privacy-policies")]
    public async Task<IActionResult> Index(int? page)
    {
        var privacyPolicies = await Mediator.Send(new GetAllPrivacyPoliciesQuery());

        return View(privacyPolicies);
    }
    [Route("privacy-policies/create")]
    public async Task<IActionResult> Create()
    {
        var languages = await Mediator.Send(new GetAllLanguagesQuery());
        ViewData["Languages"] = languages;
        return View();
    }

    [HttpPost]
    [Route("privacy-policies/create")]
    public async Task<IActionResult> Create(CreatePrivacyPolicyCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await Mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("privacy-policies/{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await Mediator.Send(new GetPrivacyPolicyByEncodedNameQuery(encodedName));
        EditPrivacyPolicyCommand model = Mapper.Map<EditPrivacyPolicyCommand>(dto);
        return View(model);
    }

    [HttpPost]
    [Route("privacy-policies/{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditPrivacyPolicyCommand command)
    {
        command.EncodedName = encodedName;
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await Mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }


    [Route("privacy-policies/{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeletePrivacyPolicyByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}