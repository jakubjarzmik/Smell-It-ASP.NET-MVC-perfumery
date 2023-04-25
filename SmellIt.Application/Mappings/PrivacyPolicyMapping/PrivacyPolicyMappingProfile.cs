using AutoMapper;
using SmellIt.Application.SmellIt.PrivacyPolicies;
using SmellIt.Application.SmellIt.PrivacyPolicies.Commands.EditPrivacyPolicy;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.PrivacyPolicyMapping;
public class PrivacyPolicyMappingProfile : Profile
{
    public PrivacyPolicyMappingProfile()
    {
        CreateMap<PrivacyPolicyDto, PrivacyPolicy>();
        CreateMap<PrivacyPolicy, PrivacyPolicyDto>();

        CreateMap<PrivacyPolicyDto, EditPrivacyPolicyCommand>();
    }
}