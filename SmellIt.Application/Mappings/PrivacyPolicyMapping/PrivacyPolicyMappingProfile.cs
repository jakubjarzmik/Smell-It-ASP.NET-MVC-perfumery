﻿using AutoMapper;
using SmellIt.Application.Features.PrivacyPolicies.Commands.EditPrivacyPolicy;
using SmellIt.Application.Features.PrivacyPolicies.DTOs;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.PrivacyPolicyMapping;
public class PrivacyPolicyMappingProfile : Profile
{
    public PrivacyPolicyMappingProfile()
    {
        CreateMap<PrivacyPolicyDto, PrivacyPolicy>();

        CreateMap<PrivacyPolicy, PrivacyPolicyDto>()
            .ForMember(pp => pp.LanguageCode,
                opt => opt.MapFrom(src=>src.Language.Code));

        CreateMap<PrivacyPolicyDto, EditPrivacyPolicyCommand>();
    }
}