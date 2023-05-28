using MediatR;
using SmellIt.Application.Features.FragranceCategories.DTOs;

namespace SmellIt.Application.Features.FragranceCategories.Queries.GetAllFragranceCategories;

public class GetAllFragranceCategoriesQuery : IRequest<IEnumerable<FragranceCategoryDto>>
{
}