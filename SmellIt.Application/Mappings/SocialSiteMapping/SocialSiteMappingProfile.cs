using AutoMapper;
using SmellIt.Application.SmellIt.SocialSites;
using SmellIt.Application.SmellIt.SocialSites.Commands.EditSocialSite;
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