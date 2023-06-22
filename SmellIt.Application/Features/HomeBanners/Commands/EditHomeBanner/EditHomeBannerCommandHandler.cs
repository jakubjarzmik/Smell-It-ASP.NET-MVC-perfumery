using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.HomeBanners.Commands.EditHomeBanner;
public class EditHomeBannerCommandHandler : IRequestHandler<EditHomeBannerCommand>
{
    private readonly IHomeBannerRepository _homeBannerRepository;
    private readonly IUserContext _userContext;

    public EditHomeBannerCommandHandler(IHomeBannerRepository homeBannerRepository, IUserContext userContext)
    {
        _homeBannerRepository = homeBannerRepository;
        _userContext = userContext;
    }
    public async Task<Unit> Handle(EditHomeBannerCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        var homeBanner = (await _homeBannerRepository.GetAsync(request.EncodedName))!;
        homeBanner.ModifiedAt = DateTime.Now;
        homeBanner.ModifiedById = currentUser.Id;

        UpdateTranslations(request, homeBanner, currentUser.Id);

        await _homeBannerRepository.CommitAsync();

        return Unit.Value;
    }
    private void UpdateTranslations(EditHomeBannerCommand request, HomeBanner homeBanner, string currentUserId)
    {
        var translations = new Dictionary<string, string>
        {
            { "pl-PL", request.TextPl },
            { "en-GB", request.TextEn }
        };

        foreach (var translation in translations)
        {
            var homeBannerTranslation = homeBanner.HomeBannerTranslations.First(hbt => hbt.Language.Code == translation.Key);
            homeBannerTranslation.Text = translation.Value;
            homeBannerTranslation.ModifiedAt = DateTime.Now;
            homeBannerTranslation.ModifiedById = currentUserId;
        }
    }
}
