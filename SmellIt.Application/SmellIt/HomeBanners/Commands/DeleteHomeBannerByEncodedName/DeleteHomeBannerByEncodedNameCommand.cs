using MediatR;

namespace SmellIt.Application.SmellIt.HomeBanners.Commands.DeleteHomeBannerByEncodedName
{
    public class DeleteHomeBannerByEncodedNameCommand : IRequest
    {
        public string EncodedName { get; set; }

        public DeleteHomeBannerByEncodedNameCommand(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
