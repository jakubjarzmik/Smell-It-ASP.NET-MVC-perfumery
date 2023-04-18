using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
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

            var brandTranslations = await _brandTranslationRepository.GetByBrandId(brand.Id);
            foreach (var brandTranslation in brandTranslations)
            {
                brandTranslation.IsActive = false;
            }

            await _brandRepository.Commit();
            return Unit.Value;
        }
    }
}
