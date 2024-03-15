using AutoMapper;
using Books.Models;
using Books.Data.Dtos.Address;

namespace Books.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<CreateAddressDto, AddressViewModel>();
        CreateMap<UpdateAddressDto, AddressViewModel>();
        CreateMap<AddressViewModel, ReadAddressDto>();
    }
}
