using AutoMapper;
using SmellIt.Application.SmellIt.TranslationsEngb;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings
{
    public class TranslationEngbProfile : Profile
    {
        public TranslationEngbProfile()
        {
            CreateMap<TranslationEngb, TranslationEngbDto>();
            CreateMap<TranslationEngbDto, TranslationEngb>();
        }
    }
}
