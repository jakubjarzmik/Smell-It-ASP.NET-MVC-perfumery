using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.HomeBanners.Commands.EditHomeBanner;
public class EditHomeBannerCommandHandler : IRequestHandler<EditHomeBannerCommand>
{
    private readonly IHomeBannerRepository _homeBannerRepository;

    public EditHomeBannerCommandHandler(IHomeBannerRepository homeBannerRepository)
    {
        _homeBannerRepository = homeBannerRepository;
    }
    public async Task<Unit> Handle(EditHomeBannerCommand request, CancellationToken cancellationToken)
    {
        var homeBanner = (await _homeBannerRepository.GetByEncodedNameAsync(request.EncodedName))!;
        homeBanner.ModifiedAt = DateTime.Now;

        UpdateTranslations(request, homeBanner);

        await _homeBannerRepository.CommitAsync();

        return Unit.Value;
    }
    private void UpdateTranslations(EditHomeBannerCommand request, HomeBanner homeBanner)
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
        }
    }
}
