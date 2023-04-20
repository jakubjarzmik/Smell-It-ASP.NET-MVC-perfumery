using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Brands.Commands.EditBrand
{
    public class EditBrandCommandHandler : IRequestHandler<EditBrandCommand>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IBrandTranslationRepository _brandTranslationRepository;

        public EditBrandCommandHandler(IBrandRepository brandRepository, IBrandTranslationRepository brandTranslationRepository)
        {
            _brandRepository = brandRepository;
            _brandTranslationRepository = brandTranslationRepository;
        }
        public async Task<Unit> Handle(EditBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = (await _brandRepository.GetByEncodedName(request.EncodedName))!;
            brand.ModifiedAt = DateTime.UtcNow;

            var plTranslation = (await _brandTranslationRepository.GetTranslation(brand.Id, "pl-PL"))!;
            plTranslation.Description = request.DescriptionPL;
            plTranslation.ModifiedAt = DateTime.UtcNow;

            var enTranslation = (await _brandTranslationRepository.GetTranslation(brand.Id, "en-GB"))!;
            enTranslation.Description = request.DescriptionEN;
            enTranslation.ModifiedAt = DateTime.UtcNow;

            await _brandRepository.Commit();
            
            return Unit.Value;
        }
    }
}
