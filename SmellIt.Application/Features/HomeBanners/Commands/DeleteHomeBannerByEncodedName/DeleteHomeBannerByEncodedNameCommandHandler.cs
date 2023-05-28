using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.HomeBanners.Commands.DeleteHomeBannerByEncodedName;

public class DeleteHomeBannerByEncodedNameCommandHandler : IRequestHandler<DeleteHomeBannerByEncodedNameCommand>
{
    private readonly IHomeBannerRepository _homeBannerRepository;

    public DeleteHomeBannerByEncodedNameCommandHandler(IHomeBannerRepository homeBannerRepository)
    {
        _homeBannerRepository = homeBannerRepository;
    }

    public async Task<Unit> Handle(DeleteHomeBannerByEncodedNameCommand request, CancellationToken cancellationToken)
    {
        await _homeBannerRepository.DeleteByEncodedNameAsync(request.EncodedName);
        return Unit.Value;
    }
}