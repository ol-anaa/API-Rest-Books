using AutoMapper;
using Books.Data.Dtos;
using Books.Data.Dtos.Book;
using Books.Models;

namespace Books.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<CreateBookDto, BookViewModel>();
        CreateMap<UpdateBookDto, BookViewModel>();
        CreateMap<BookViewModel, UpdateBookDto>();
        CreateMap<BookViewModel, ReadBookDto>();
    }
}
