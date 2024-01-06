using AutoMapper;
using BookStore.Data.Entities;
using BookStore.DTO;

namespace BookStore.AutoMapper;

public class AMProfile : Profile
{
    public AMProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<BookDto, Book>();
    }
}