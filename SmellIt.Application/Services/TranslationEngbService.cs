using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Application.Services.Interfaces;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Services;
public class TranslationEngbService : ITranslationEngbService
{
    private readonly ITranslationEngbRepository _translationEngbRepository;

    public TranslationEngbService(ITranslationEngbRepository translationEngbRepository)
    {
        _translationEngbRepository = translationEngbRepository;
    }
    public async Task Create(TranslationEngb translationEngb)
    {
        await _translationEngbRepository.Create(translationEngb);
    }
}