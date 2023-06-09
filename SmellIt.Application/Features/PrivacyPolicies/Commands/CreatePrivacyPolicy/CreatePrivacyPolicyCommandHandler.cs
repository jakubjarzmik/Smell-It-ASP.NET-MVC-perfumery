﻿using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.PrivacyPolicies.Commands.CreatePrivacyPolicy;

public class CreatePrivacyPolicyCommandHandler : IRequestHandler<CreatePrivacyPolicyCommand>
{
    private readonly IUserContext _userContext;
    private readonly IPrivacyPolicyRepository _privacyPolicyRepository;
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    public CreatePrivacyPolicyCommandHandler(IUserContext userContext,IPrivacyPolicyRepository privacyPolicyRepository, ILanguageRepository languageRepository, IMapper mapper)
    {
        _userContext = userContext;
        _privacyPolicyRepository = privacyPolicyRepository;
        _languageRepository = languageRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreatePrivacyPolicyCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        var privacyPolicy = _mapper.Map<PrivacyPolicy>(request);

        privacyPolicy.Language = (await _languageRepository.GetByCodeAsync(request.LanguageCode))!;

        await _privacyPolicyRepository.CreateAsync(privacyPolicy);

        return Unit.Value;
    }
}