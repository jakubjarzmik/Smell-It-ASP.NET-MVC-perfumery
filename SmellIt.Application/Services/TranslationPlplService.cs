using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Application.Services.Interfaces;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Services;
public class TranslationPlplService : ITranslationPlplService
{
    private readonly ITranslationPlplRepository _translationPlplRepository;

    public TranslationPlplService(ITranslationPlplRepository translationPlplRepository)
    {
        _translationPlplRepository = translationPlplRepository;
    }
    public async Task Create(TranslationPlpl translationPlpl)
    {
        await _translationPlplRepository.Create(translationPlpl);
    }
}