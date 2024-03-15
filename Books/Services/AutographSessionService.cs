using AutoMapper;
using Books.Data;
using Books.Data.Dtos.AutographSession;
using Books.Data.Dtos.Book;
using Books.Models;

namespace Books.Services;

public class AutographSessionService
{
    private BookContext _context;
    private IMapper _mapper;

    public AutographSessionService(BookContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadAutographSessionDto? AddAutographSession(CreateAutographSessionDto createAutographSessionDto)
    {
        AutographSessionViewModel autographSession = _mapper.Map<AutographSessionViewModel>(createAutographSessionDto);
        _context.AutographSession.Add(autographSession);
        _context.SaveChanges();

        return _mapper.Map<ReadAutographSessionDto>(autographSession);
    }

    public ReadAutographSessionDto? GetAutographSessionById(int id)
    {
        var autographSession = _context.Books.FirstOrDefault(autographSession => autographSession.Id == id);

        if (autographSession != null)
            return _mapper.Map<ReadAutographSessionDto>(autographSession);

        return null;
    }
}
