using BookStore.Data;
using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories.Implementation;

public class BookRepository(BookStoreContext _context, ILogger<BookRepository> _logger) : IBookRepository
{
    public async Task<bool> CreateBook(Book book, CancellationToken cancellationToken)
    {
        try
        {
            book.CreatedDate = DateTime.Now;
            
            await _context.Books.AddAsync(book, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<bool> DeleteBook(int id, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _context.Books
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync(cancellationToken: cancellationToken);

            return entity > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<Book> GetBookById(int id, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Books.SingleOrDefaultAsync(b => b.Id == id, cancellationToken)
                ?? throw new Exception("Book was not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Book>> GetBooks(CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Books
                .Where(b => b.IsAvailable == true)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<bool> UpdateBook(Book book, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _context.Books
                .Where(b => b.Id == book.Id)
                .ExecuteUpdateAsync(updates => updates
                    .SetProperty(p => p.Title, book.Title)
                    .SetProperty(p => p.Description, book.Description)
                    .SetProperty(p => p.Author, book.Author)
                    .SetProperty(p => p.Year, book.Year)
                    .SetProperty(p => p.Genre, book.Genre)
                    .SetProperty(p => p.Price, book.Price)
                    .SetProperty(p => p.Publisher, book.Publisher)
                    .SetProperty(p => p.Language, book.Language)
                    .SetProperty(p => p.PageCount, book.PageCount)
                    .SetProperty(p => p.IsAvailable, book.IsAvailable)
                    .SetProperty(p => p.ImageUrl, book.ImageUrl)
                    .SetProperty(p => p.UpdatedDate, DateTime.Now), cancellationToken);

            return entity > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }
}
