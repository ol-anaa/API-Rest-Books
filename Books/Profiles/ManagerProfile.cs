using AutoMapper;
using Books.Data.Dtos.Manager;
using Books.Models;

namespace Books.Profiles;

public class ManagerProfile : Profile
{
    public ManagerProfile()
    {
        CreateMap<CreateManagerDto, ManagerViewModel>();
        CreateMap<ManagerViewModel, ReadManagerDto>()
            .ForMember(manager => manager.Bookstore, opts => opts
            .MapFrom(manager => manager.Bookstore.Select
            (c => new { c.Id, c.Name, c.Address, c.AddressId })));
    }
}
