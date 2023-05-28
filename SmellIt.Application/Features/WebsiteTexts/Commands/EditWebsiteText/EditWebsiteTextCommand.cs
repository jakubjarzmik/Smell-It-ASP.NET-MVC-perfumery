using MediatR;
using SmellIt.Application.Features.WebsiteTexts.DTOs;

namespace SmellIt.Application.Features.WebsiteTexts.Commands.EditWebsiteText;

public class EditWebsiteTextCommand : WebsiteTextForAdminDto, IRequest
{

}