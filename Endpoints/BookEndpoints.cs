using BookStore.DTO;
using BookStore.Services;

namespace BookStore.Endpoints;

public static class BookEndpoints
{
    public static void RegisterBookEndpoints(this IEndpointRouteBuilder routes)
    {
        var books = routes.MapGroup("/api/v1/books");

        books.MapGet("", async (IBookService bookService, CancellationToken cancellationToken) =>
        {
            var response = await bookService.GetBooks(cancellationToken);
            return Results.Ok(response);
        });

        books.MapGet("/{id}", async (int id, IBookService bookService, CancellationToken cancellationToken) =>
        {
            var response = await bookService.GetBookById(id, cancellationToken);
            return Results.Ok(response);
        });
        books.MapPost("", async (BookDto book, IBookService bookService, CancellationToken cancellationToken) =>
        {
            var response = await bookService.CreateBook(book, cancellationToken);
            return Results.Ok(response);
        });

        books.MapPut("/{id}", async (int id, BookDto book, IBookService bookService, CancellationToken cancellationToken) =>
        {
            var response = await bookService.UpdateBook(book, cancellationToken);
            return Results.Ok(response);
        });

        books.MapDelete("/{id}", async (int id, IBookService bookService, CancellationToken cancellationToken) =>
        {
            var response = await bookService.DeleteBook(id, cancellationToken);
            return Results.Ok(response);
        });
    }
}