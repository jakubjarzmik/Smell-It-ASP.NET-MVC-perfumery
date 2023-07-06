using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.FragranceCategories.Commands.CreateFragranceCategory;
public class CreateFragranceCategoryCommandHandler : IRequestHandler<CreateFragranceCategoryCommand>
{
    private readonly IUserContext _userContext;
    private readonly IFragranceCategoryRepository _fragranceCategoryRepository;
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    public CreateFragranceCategoryCommandHandler(IUserContext userContext, IFragranceCategoryRepository fragranceCategoryRepository, ILanguageRepository languageRepository, IMapper mapper)
    {
        _userContext = userContext;
        _fragranceCategoryRepository = fragranceCategoryRepository;
        _languageRepository = languageRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateFragranceCategoryCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        var plLanguage = await _languageRepository.GetByCodeAsync("pl-PL");
        var enLanguage = await _languageRepository.GetByCodeAsync("en-GB");

        var fragranceCategory = _mapper.Map<FragranceCategory>(request);

        if (plLanguage != null && enLanguage != null)
        {
            fragranceCategory.FragranceCategoryTranslations = new List<FragranceCategoryTranslation>
            {
                new FragranceCategoryTranslation { Language = plLanguage, Name = request.NamePl, Description = request.DescriptionPl },
                new FragranceCategoryTranslation { Language = enLanguage, Name = request.NameEn, Description = request.DescriptionEn }
            };
        }

        await _fragranceCategoryRepository.CreateAsync(fragranceCategory);

        return Unit.Value;
    }
}