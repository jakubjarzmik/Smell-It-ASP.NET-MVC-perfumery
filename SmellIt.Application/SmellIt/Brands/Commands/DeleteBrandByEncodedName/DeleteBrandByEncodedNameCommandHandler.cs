using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Brands.Commands.DeleteBrandByEncodedName
{
    public class DeleteBrandByEncodedNameCommandHandler : IRequestHandler<DeleteBrandByEncodedNameCommand>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IBrandTranslationRepository _brandTranslationRepository;

        public DeleteBrandByEncodedNameCommandHandler(IBrandRepository brandRepository, IBrandTranslationRepository brandTranslationRepository)
        {
            _brandRepository = brandRepository;
            _brandTranslationRepository = brandTranslationRepository;
        }

        public async Task<Unit> Handle(DeleteBrandByEncodedNameCommand request, CancellationToken cancellationToken)
        {
            var brand = (await _brandRepository.GetByEncodedName(request.EncodedName))!;
            brand.IsActive = false;
            brand.DeletedAt = DateTime.UtcNow;

            var brandTranslations = await _brandTranslationRepository.GetBrandTranslations(brand.Id);
            foreach (var brandTranslation in brandTranslations)
            {
                brandTranslation.IsActive = false;
                brandTranslation.DeletedAt = DateTime.UtcNow;
            }

            await _brandRepository.Commit();
            return Unit.Value;
        }
    }
}
