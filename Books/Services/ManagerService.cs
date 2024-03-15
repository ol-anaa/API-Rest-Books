using AutoMapper;
using Books.Data;
using Books.Data.Dtos.Manager;
using Books.Models;
using FluentResults;

namespace Books.Services;

public class ManagerService
{
    private BookContext _context;
    private IMapper _mapper;

    public ManagerService(BookContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadManagerDto? AddManager(CreateManagerDto createManagerDto)
    {
        ManagerViewModel manager = _mapper.Map<ManagerViewModel>(createManagerDto);
        _context.Manager.Add(manager);
        _context.SaveChanges();

        return _mapper.Map<ReadManagerDto>(manager);
    }

    public ReadManagerDto? GetManagerById(int id)
    {
        var manager = _context.Manager.FirstOrDefault(manager => manager.Id == id);

        if (manager != null)
        {
            return _mapper.Map<ReadManagerDto>(manager);
        }
        return null;
    }

    public Result DeleteManager(int id)
    {
        ManagerViewModel? manager = _context.Manager.FirstOrDefault(manager => manager.Id == id);

        if (manager != null)
        {
            _context.Manager.Remove(manager);
            _context.SaveChanges();
            return Result.Ok();
        }
        return Result.Fail("Algo deu errado ao deletar um gerente");
    }
}
