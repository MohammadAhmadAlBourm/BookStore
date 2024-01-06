using AutoMapper;
using BookStore.Common;
using BookStore.Data.Entities;
using BookStore.DTO;
using BookStore.Repositories;

namespace BookStore.Services.Implementation;

public class BookService(
    IBookRepository _bookRepository,
    ILogger<BookService> _logger,
    IMapper _mapper) : IBookService
{
    public async Task<bool> CreateBook(BookDto book, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Book>(book);

            entity.BookReferenceNumber = BookReferenceNumberGenerator.GenerateBookReferenceNumber();
            return await _bookRepository.CreateBook(entity, cancellationToken);
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
            return await _bookRepository.DeleteBook(id, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<BookDto> GetBookById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _bookRepository.GetBookById(id, cancellationToken);
            return _mapper.Map<BookDto>(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<IEnumerable<BookDto>> GetBooks(CancellationToken cancellationToken)
    {
        try
        {
            var response = await _bookRepository.GetBooks(cancellationToken);
            return _mapper.Map<IEnumerable<BookDto>>(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<bool> UpdateBook(BookDto book, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Book>(book);
            return await _bookRepository.UpdateBook(entity, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }
}