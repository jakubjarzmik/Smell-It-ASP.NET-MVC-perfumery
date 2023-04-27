using AutoMapper;
using SmellIt.Application.Mappings.HomeBannerMapping;
using SmellIt.Application.SmellIt.PrivacyPolicies;
using SmellIt.Application.SmellIt.PrivacyPolicies.Commands.EditPrivacyPolicy;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.PrivacyPolicyMapping;
public class PrivacyPolicyMappingProfile : Profile
{
    public PrivacyPolicyMappingProfile()
    {
        CreateMap<PrivacyPolicyDto, PrivacyPolicy>()
            .ForMember(pp => pp.Language,
                opt => opt.MapFrom<LanguageResolver>());
        CreateMap<PrivacyPolicy, PrivacyPolicyDto>()
            .ForMember(pp => pp.LanguageCode,
                opt => opt.MapFrom<LanguageCodeResolver>());

        CreateMap<PrivacyPolicyDto, EditPrivacyPolicyCommand>();
    }
}