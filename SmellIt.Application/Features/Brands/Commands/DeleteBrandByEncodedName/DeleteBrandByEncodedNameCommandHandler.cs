using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Brands.Commands.DeleteBrandByEncodedName;

public class DeleteBrandByEncodedNameCommandHandler : IRequestHandler<DeleteBrandByEncodedNameCommand>
{
    private readonly IBrandRepository _brandRepository;

    public DeleteBrandByEncodedNameCommandHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<Unit> Handle(DeleteBrandByEncodedNameCommand request, CancellationToken cancellationToken)
    {
        await _brandRepository.DeleteAsync(request.EncodedName);

        return Unit.Value;
    }
}