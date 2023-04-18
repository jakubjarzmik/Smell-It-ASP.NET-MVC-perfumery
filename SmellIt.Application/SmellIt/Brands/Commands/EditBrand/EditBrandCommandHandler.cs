using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Brands.Commands.EditBrand
{
    public class EditBrandCommandHandler : IRequestHandler<EditBrandCommand>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IBrandTranslationRepository _brandTranslationRepository;
        private readonly ILanguageRepository _languageRepository;

        public EditBrandCommandHandler(IBrandRepository brandRepository, IBrandTranslationRepository brandTranslationRepository, ILanguageRepository languageRepository)
        {
            _brandRepository = brandRepository;
            _brandTranslationRepository = brandTranslationRepository;
            _languageRepository = languageRepository;
        }
        public async Task<Unit> Handle(EditBrandCommand request, CancellationToken cancellationToken)
        {
            var polishId = _languageRepository.GetByCode("pl-PL").Result!.Id;
            var englishId = _languageRepository.GetByCode("en-GB").Result!.Id;

            var brand = (await _brandRepository.GetByEncodedName(request.EncodedName))!;

            var brandTranslations = await _brandTranslationRepository.GetByBrandId(brand.Id);

            var plTranslation = brandTranslations.FirstOrDefault(bt => bt.LanguageId == polishId)!;
            plTranslation.Description = request.DescriptionPL;

            var enTranslation = brandTranslations.FirstOrDefault(bt => bt.LanguageId == englishId)!;
            enTranslation.Description = request.DescriptionEN;

            await _brandRepository.Commit();
            
            return Unit.Value;
        }
    }
}
