using SmellIt.Application.Services.Interfaces;
using SmellIt.Application.Validators;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Services;
public class TranslationEngbService : ITranslationEngbService
{
    private readonly ITranslationEngbRepository _translationEngbRepository;
    private readonly TranslationEngbValidator _translationEngbValidator;

    public TranslationEngbService(ITranslationEngbRepository translationEngbRepository, TranslationEngbValidator translationEngbValidator)
    {
        _translationEngbRepository = translationEngbRepository;
        _translationEngbValidator = translationEngbValidator;
    }
    public async Task Create(TranslationEngb translationEngb)
    {
        if (_translationEngbValidator.Validate(translationEngb).IsValid)
            await _translationEngbRepository.Create(translationEngb);
    }

    public Task<TranslationEngb?> GetByKey(string key)
        => _translationEngbRepository.GetByKey(key);
}