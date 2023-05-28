using MediatR;
using SmellIt.Application.Features.WebsiteTexts.DTOs;

namespace SmellIt.Application.Features.WebsiteTexts.Commands.CreateWebsiteText;

public class CreateWebsiteTextCommand : WebsiteTextForAdminDto, IRequest
{

}