using AutoMapper;
using SmellIt.Application.Features.SocialSites.Commands.EditSocialSite;
using SmellIt.Application.Features.SocialSites.DTOs;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.SocialSiteMapping;
public class SocialSiteMappingProfile : Profile
{
    public SocialSiteMappingProfile()
    {
        CreateMap<SocialSiteDto, SocialSite>();
        CreateMap<SocialSite, SocialSiteDto>();

        CreateMap<SocialSiteDto, EditSocialSiteCommand>();
    }
}