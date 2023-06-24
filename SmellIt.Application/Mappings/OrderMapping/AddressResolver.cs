using AutoMapper;
using SmellIt.Application.Features.Orders.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.OrderMapping;
public class AddressResolver : IValueResolver<OrderCreateDto, Order, Address>
{
    private readonly IAddressRepository _addressRepository;

    public AddressResolver(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public Address Resolve(OrderCreateDto source, Order destination, Address destMember, ResolutionContext context)
    {
        var checkedAddress = _addressRepository.GetAddress(source.FullName, source.FirstLine, source.SecondLine, source.PostalCode, source.City).Result;
        if (checkedAddress != null)
        {
            return checkedAddress;
        }

        var address = new Address
        {
            FullName = source.FullName,
            FirstLine = source.FirstLine,
            SecondLine = source.SecondLine,
            PostalCode = source.PostalCode,
            City = source.City
        };
        _addressRepository.CreateAsync(address);
        return address;
    }
}