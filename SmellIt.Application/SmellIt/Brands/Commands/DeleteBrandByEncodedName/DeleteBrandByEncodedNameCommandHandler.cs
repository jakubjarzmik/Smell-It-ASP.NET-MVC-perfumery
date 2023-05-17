using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Brands.Commands.DeleteBrandByEncodedName
{
    public class DeleteBrandByEncodedNameCommandHandler : IRequestHandler<DeleteBrandByEncodedNameCommand>
    {
        private readonly IBrandRepository _brandRepository;

        public DeleteBrandByEncodedNameCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Unit> Handle(DeleteBrandByEncodedNameCommand request, CancellationToken cancellationToken)
        {
            var brand = (await _brandRepository.GetByEncodedName(request.EncodedName))!;
            brand.IsActive = false;
            brand.DeletedAt = DateTime.Now;

            foreach (var brandTranslation in brand.BrandTranslations)
            {
                brandTranslation.IsActive = false;
                brandTranslation.DeletedAt = DateTime.Now;
            }

            await _brandRepository.Commit();
            return Unit.Value;
        }
    }
}
