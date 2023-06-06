using MediatR;
using SmellIt.Application.ViewModels.Website;

namespace SmellIt.Application.Features.CartItems.Queries.GetAllCartItemsBySession;

public class GetAllCartItemsBySessionQuery : IRequest<CartViewModel>
{
    public string Session { get; set; }
    public string LanguageCode { get; set; }


    public GetAllCartItemsBySessionQuery(string session, string languageCode)
    {
        Session = session;
        LanguageCode = languageCode;
    }
}