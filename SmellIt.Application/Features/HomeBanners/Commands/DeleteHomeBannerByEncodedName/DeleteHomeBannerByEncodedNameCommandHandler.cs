using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.HomeBanners.Commands.DeleteHomeBannerByEncodedName;

public class DeleteHomeBannerByEncodedNameCommandHandler : IRequestHandler<DeleteHomeBannerByEncodedNameCommand>
{
    private readonly IUserContext _userContext;
    private readonly IHomeBannerRepository _homeBannerRepository;

    public DeleteHomeBannerByEncodedNameCommandHandler(IUserContext userContext,IHomeBannerRepository homeBannerRepository)
    {
        _userContext = userContext;
        _homeBannerRepository = homeBannerRepository;
    }

    public async Task<Unit> Handle(DeleteHomeBannerByEncodedNameCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        await _homeBannerRepository.DeleteAsync(request.EncodedName);
        return Unit.Value;
    }
}