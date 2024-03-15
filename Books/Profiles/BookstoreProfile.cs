using AutoMapper;
using Books.Models;
using Books.Data.Dtos.Bookstore;

namespace Books.Profiles;

public class BookstoreProfile : Profile
{
    public BookstoreProfile()
    {
        CreateMap<CreateBookstoreDto, BookstoreViewModel>();
        CreateMap<UpdateBooksoteDto, BookstoreViewModel>();
        CreateMap<BookstoreViewModel, ReadBookstoreDto>();
    }
}
