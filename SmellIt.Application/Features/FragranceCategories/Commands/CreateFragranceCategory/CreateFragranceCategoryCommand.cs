using MediatR;
using SmellIt.Application.Features.FragranceCategories.DTOs;

namespace SmellIt.Application.Features.FragranceCategories.Commands.CreateFragranceCategory;

public class CreateFragranceCategoryCommand : FragranceCategoryDto, IRequest
{

}