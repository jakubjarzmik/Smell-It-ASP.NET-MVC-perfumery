using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.FragranceCategories.Commands.DeleteFragranceCategoryByEncodedName
{
    public class DeleteFragranceCategoryByEncodedNameCommandHandler : IRequestHandler<DeleteFragranceCategoryByEncodedNameCommand>
    {
        private readonly IFragranceCategoryRepository _fragranceCategoryRepository;

        public DeleteFragranceCategoryByEncodedNameCommandHandler(IFragranceCategoryRepository fragranceCategoryRepository)
        {
            _fragranceCategoryRepository = fragranceCategoryRepository;
        }

        public async Task<Unit> Handle(DeleteFragranceCategoryByEncodedNameCommand request, CancellationToken cancellationToken)
        {
            await _fragranceCategoryRepository.DeleteByEncodedNameAsync(request.EncodedName);
            return Unit.Value;
        }
    }
}
