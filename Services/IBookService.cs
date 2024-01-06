using BookStore.Data.Entities;
using BookStore.DTO;

namespace BookStore.Services;

public interface IBookService
{
    Task<bool> CreateBook(BookDto book, CancellationToken cancellationToken);
    Task<bool> UpdateBook(BookDto book, CancellationToken cancellationToken);
    Task<bool> DeleteBook(int id, CancellationToken cancellationToken);
    Task<IEnumerable<BookDto>> GetBooks(CancellationToken cancellationToken);
    Task<BookDto> GetBookById(int id, CancellationToken cancellationToken);
}