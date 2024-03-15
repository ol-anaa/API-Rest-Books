using AutoMapper;
using Books.Data;
using Books.Data.Dtos.Bookstore;
using Books.Models;
using FluentResults;

namespace Books.Services;

public class BookstoreService
{
    private BookContext _context;
    private IMapper _mapper;

    public BookstoreService(BookContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadBookstoreDto AddBookstore(CreateBookstoreDto bookstoreDto)
    {
        BookstoreViewModel bookstore = _mapper.Map<BookstoreViewModel>(bookstoreDto);
        _context.Bookstores.Add(bookstore);
        _context.SaveChanges();

        return _mapper.Map<ReadBookstoreDto>(bookstore);
    }

    public IEnumerable<ReadBookstoreDto> GetBookstores(int skip, int take)
    {
        return _mapper.Map<IEnumerable<ReadBookstoreDto>>(_context.Bookstores.Skip(skip).Take(take));
    }

    public ReadBookstoreDto? GetBookstoreById(int id)
    {
        var bookstore = _context.Bookstores.FirstOrDefault(bookstore => bookstore.Id == id);

        if (bookstore != null)
            return _mapper.Map<ReadBookstoreDto>(bookstore);
        return null;
    }

    public Result UpdateBookstore(int id, UpdateBooksoteDto bookstoreDto)
    {
        var bookstore = _context.Bookstores.FirstOrDefault(bookstore => bookstore.Id == id);

        if (bookstore != null)
        {
            _mapper.Map(bookstoreDto, bookstore);
            _context.SaveChanges();
            return Result.Ok();
        }
        return Result.Fail("Algo deu errado ao atualizar um bookstore");
    }

    public Result DeleteBookstore(int id)
    {
        var bookstore = _context.Bookstores.FirstOrDefault(bookstore => bookstore.Id == id);

        if (bookstore != null)
        {
            _context.Bookstores.Remove(bookstore);
            _context.SaveChanges();
            return Result.Ok();
        }

        return Result.Fail("Algo deu errado ao deletar uma bookstore");
    }
}
