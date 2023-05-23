using AutoMapper;
using SmellIt.Application.Features.PrivacyPolicies;
using SmellIt.Application.Features.PrivacyPolicies.Commands.EditPrivacyPolicy;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.PrivacyPolicyMapping;
public class PrivacyPolicyMappingProfile : Profile
{
    public PrivacyPolicyMappingProfile()
    {
        CreateMap<PrivacyPolicyDto, PrivacyPolicy>()
            .ForMember(pp => pp.Language,
                opt => opt.MapFrom<PrivacyPolicyLanguageResolver>());
        CreateMap<PrivacyPolicy, PrivacyPolicyDto>()
            .ForMember(pp => pp.LanguageCode,
                opt => opt.MapFrom(src=>src.Language.Code));

        CreateMap<PrivacyPolicyDto, EditPrivacyPolicyCommand>();
    }
}