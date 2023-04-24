using AutoMapper;
using SmellIt.Application.SmellIt.HomeBanners;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.HomeBannerMapping
{
    internal class TextPlResolver : IValueResolver<HomeBanner, HomeBannerDto, string>
    {
	    private readonly IHomeBannerTranslationRepository _homeBannerTranslationRepository;

	    public TextPlResolver(IHomeBannerTranslationRepository homeBannerTranslationRepository)
	    {
		    _homeBannerTranslationRepository = homeBannerTranslationRepository;
	    }

        public string Resolve(HomeBanner source, HomeBannerDto destination, string destMember, ResolutionContext context)
        {
            var translation = _homeBannerTranslationRepository.GetTranslation(source.Id, "pl-PL").Result;
            return translation!.Text;
        }
    }
}