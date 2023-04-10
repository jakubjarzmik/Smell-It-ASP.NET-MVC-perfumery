using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Application.Services.Interfaces;
using SmellIt.Application.Validators;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Services;
public class TranslationPlplService : ITranslationPlplService
{
    private readonly ITranslationPlplRepository _translationPlplRepository;
    private readonly TranslationPlplValidator _translationPlplValidator;

    public TranslationPlplService(ITranslationPlplRepository translationPlplRepository, TranslationPlplValidator translationPlplValidator)
    {
        _translationPlplRepository = translationPlplRepository;
        _translationPlplValidator = translationPlplValidator;
    }
    public async Task Create(TranslationPlpl translationPlpl)
    {
        if (_translationPlplValidator.Validate(translationPlpl).IsValid)
            await _translationPlplRepository.Create(translationPlpl);
    }
}