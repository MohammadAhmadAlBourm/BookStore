using BookStore.Data.Entities;

namespace BookStore.Repositories;

public interface IBookRepository
{
    Task<bool> CreateBook(Book book, CancellationToken cancellationToken);
    Task<bool> UpdateBook(Book book, CancellationToken cancellationToken);
    Task<bool> DeleteBook(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Book>> GetBooks(CancellationToken cancellationToken);
    Task<Book> GetBookById(int id, CancellationToken cancellationToken);
}
