using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Brands.Commands.EditBrand
{
    public class EditBrandCommandHandler : IRequestHandler<EditBrandCommand>
    {
        private readonly IBrandRepository _brandRepository;

        public EditBrandCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<Unit> Handle(EditBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = (await _brandRepository.GetByEncodedName(request.EncodedName))!;
            brand.ModifiedAt = DateTime.UtcNow;

            var plTranslation = brand.BrandTranslations.First(bt=>bt.Language.Code == "pl-PL");
            plTranslation.Description = request.DescriptionPl;
            plTranslation.ModifiedAt = DateTime.UtcNow;

            var enTranslation = brand.BrandTranslations.First(bt => bt.Language.Code == "en-GB");
            enTranslation.Description = request.DescriptionEn;
            enTranslation.ModifiedAt = DateTime.UtcNow;

            await _brandRepository.Commit();
            
            return Unit.Value;
        }
    }
}
