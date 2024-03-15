using AutoMapper;
using Books.Models;
using Books.Data.Dtos.AutographSession;

namespace Books.Profiles;
public class AutographSessionProfile : Profile
{
    public AutographSessionProfile()
    {
        CreateMap<CreateAutographSessionDto, AutographSessionViewModel>();
        CreateMap<AutographSessionViewModel, ReadAutographSessionDto>()
            .ForMember(dto => dto.StartTime, opts => opts
            .MapFrom(dto => dto.ClosingSession.AddMinutes(dto.Book.NumberOfPages * (-1))));
    }
}
