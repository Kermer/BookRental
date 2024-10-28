using BookRental.Api.Contracts.Requests;
using BookRental.Api.Contracts.Responses;
using BookRental.Api.Models;
using BookRental.Api.Validation;
using Microsoft.AspNetCore.Mvc;

namespace BookRental.Api.Contracts;

public static class ContractMapping
{
    public static Book MapToBook(this CreateOrUpdateBookRequest request)
    {
        return new Book()
        {
            Id = new Guid(),
            Title = request.Title,
            Author = request.Author,
            ISBN = CleanupIsbn(request.ISBN),
            Status = request.Status
        };
    }

    public static Book MapToBook(this CreateOrUpdateBookRequest request, Guid id)
    {
        return new Book()
        {
            Id = id,
            Title = request.Title,
            Author = request.Author,
            ISBN = CleanupIsbn(request.ISBN),
            Status = request.Status
        };
    }

    public static BookResponse MapToResponse(this Book book)
    {
        return new BookResponse()
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            ISBN = book.ISBN,
            Status = book.Status
        };
    }

    public static BooksResponse MapToResponse(this IEnumerable<Book> books)
    {
        return new BooksResponse()
        {
            Items = books.Select(MapToResponse)
        };
    }

    public static ValidationProblemDetails MapToResponse(this ValidationFailed failed)
    {
        return new ValidationProblemDetails(failed.Errors.ToDictionary(x => x.PropertyName,
            x => new[] { x.ErrorMessage }));
    }

    /// <summary>
    /// Removes non-digit letters from isbn number
    /// </summary>
    /// <param name="isbn"></param>
    /// <returns></returns>
    private static string CleanupIsbn(string isbn)
    {
        return isbn.Replace("-", "").Replace(" ", "");
    }
}
