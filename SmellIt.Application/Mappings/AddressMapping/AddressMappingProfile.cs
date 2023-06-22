using AutoMapper;
using SmellIt.Application.Features.Addresses.DTOs;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.AddressMapping;
public class AddressMappingProfile : Profile
{
    public AddressMappingProfile()
    {
        CreateMap<Address, AddressDto>();
    }
}