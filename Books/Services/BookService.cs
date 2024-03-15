using AutoMapper;
using Books.Data;
using Books.Data.Dtos;
using Books.Data.Dtos.Book;
using Books.Models;
using FluentResults;
using Microsoft.AspNetCore.JsonPatch;

namespace Books.Services;

public class BookService
{
    private BookContext _context;
    private IMapper _mapper;

    public BookService(BookContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadBookDto AddBook(CreateBookDto bookDto)
    {
        BookViewModel book = _mapper.Map<BookViewModel>(bookDto);
        _context.Books.Add(book);
        _context.SaveChanges();

        return _mapper.Map<ReadBookDto>(book);
    }

    public IEnumerable<ReadBookDto> GetBooks(int skip, int take)
    {
        return _mapper.Map<IEnumerable<ReadBookDto>>(_context.Books.Skip(skip).Take(take));
    }

    public ReadBookDto? GetBookById(int id)
    {
        var book = _context.Books.FirstOrDefault(book => book.Id == id);

        if (book != null)
            return _mapper.Map<ReadBookDto>(book);

        return null;
    }

    public Result UpdateBook(int id, UpdateBookDto bookDto)
    {
        var book = _context.Books.FirstOrDefault(book => book.Id == id);

        if (book != null)
        {
            _mapper.Map(bookDto, book);
            _context.SaveChanges();
            return Result.Ok();
        }

        return Result.Fail("Erro ao autualizar o livro");
    }

    public Result UpdatePartialBook(int id, JsonPatchDocument<UpdateBookDto> patch)
    {
        var book = _context.Books.FirstOrDefault(book => book.Id == id);

        if (book != null)
        {
            var bookUpdate = _mapper.Map<UpdateBookDto>(book);

            patch.ApplyTo(bookUpdate);

            try
            {
                _mapper.Map(bookUpdate, book);
                _context.SaveChanges();
                return Result.Ok();

            }
            catch (Exception ex)
            {
                return Result.Fail("Houve um problema! " + ex.ToString());
            }
        }

        return Result.Fail("Erro ao atulizar um book");
    }

    public Result DeleteBook(int id)
    {
        var book = _context.Books.FirstOrDefault(book => book.Id == id);

        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Result.Ok();
        }

        return Result.Fail("Algo deu errado");
    }
}
