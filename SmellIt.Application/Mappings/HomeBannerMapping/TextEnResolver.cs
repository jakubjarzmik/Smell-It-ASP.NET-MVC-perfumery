using AutoMapper;
using SmellIt.Application.SmellIt.HomeBanners;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.HomeBannerMapping
{
    internal class TextEnResolver : IValueResolver<HomeBanner, HomeBannerDto, string>
    {
	    private readonly IHomeBannerTranslationRepository _homeBannerTranslationRepository;

	    public TextEnResolver(IHomeBannerTranslationRepository homeBannerTranslationRepository)
	    {
		    _homeBannerTranslationRepository = homeBannerTranslationRepository;
	    }

        public string Resolve(HomeBanner source, HomeBannerDto destination, string destMember, ResolutionContext context)
        {
            var translation = _homeBannerTranslationRepository.GetTranslation(source.Id, "en-GB").Result;
            return translation!.Text;
        }
    }
}
