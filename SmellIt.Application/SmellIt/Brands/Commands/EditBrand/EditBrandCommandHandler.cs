using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Brands.Commands.EditBrand
{
    public class EditBrandCommandHandler : IRequestHandler<EditBrandCommand>
    {
        private readonly ITranslationEngbRepository _translationEngbRepository;
        private readonly ITranslationPlplRepository _translationPlplRepository;

        public EditBrandCommandHandler(ITranslationEngbRepository translationEngbRepository, ITranslationPlplRepository translationPlplRepository)
        {
            _translationEngbRepository = translationEngbRepository;
            _translationPlplRepository = translationPlplRepository;
        }
        public async Task<Unit> Handle(EditBrandCommand request, CancellationToken cancellationToken)
        {
            var nameKey = request.NameKey;
            TranslationEngb nameTranslationEngb = (await _translationEngbRepository.GetByKey(nameKey))!;
            TranslationPlpl nameTranslationPlpl = (await _translationPlplRepository.GetByKey(nameKey))!;
            var descTranslationEngb = await _translationEngbRepository.GetByKey(nameKey+"Desc");
            var descTranslationPlpl = await _translationPlplRepository.GetByKey(nameKey+"Desc");
            
            nameTranslationEngb.Value = request.NameEN;
            nameTranslationPlpl.Value = request.NamePL;

            if (descTranslationEngb != null)
            {
                descTranslationEngb.Value = request.DescriptionEN ?? string.Empty;
            }

            if (descTranslationPlpl != null)
            {
                descTranslationPlpl.Value = request.DescriptionPL ?? string.Empty;
            }

            await _translationEngbRepository.Commit();
            return Unit.Value;
        }
    }
}
