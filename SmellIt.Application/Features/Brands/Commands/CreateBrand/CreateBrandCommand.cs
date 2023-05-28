using MediatR;
using SmellIt.Application.Features.Brands.DTOs;

namespace SmellIt.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommand : BrandDto, IRequest
{

}