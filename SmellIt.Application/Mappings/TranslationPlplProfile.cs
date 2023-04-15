using AutoMapper;
using SmellIt.Application.SmellIt.TranslationsEngb;
using SmellIt.Application.SmellIt.TranslationsPlpl;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings
{
    public class TranslationPlplProfile : Profile
    {
        public TranslationPlplProfile()
        {
            CreateMap<TranslationPlpl, TranslationPlplDto>();
            CreateMap<TranslationPlplDto, TranslationPlpl>();
        }
    }
}
