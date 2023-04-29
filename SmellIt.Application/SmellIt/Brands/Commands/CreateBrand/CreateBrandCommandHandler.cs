using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IBrandTranslationRepository _brandTranslationRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        public CreateBrandCommandHandler(IBrandRepository brandRepository, IBrandTranslationRepository brandTranslationRepository, ILanguageRepository languageRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _brandTranslationRepository = brandTranslationRepository;
            _languageRepository = languageRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<Brand>(request);
            brand.EncodeName();

            foreach (var translation in brand.BrandTranslations!)
            {
                translation.Brand = brand;
                translation.Language = (await _languageRepository.GetAll()).FirstOrDefault(l => l.Id == translation.LanguageId)!;
                translation.EncodeName();
            }

            await _brandRepository.Create(brand);

            return Unit.Value;
        }
    }
}
