using BookRental.Api.Contracts.Requests;
using BookRental.Api.Contracts.Responses;
using BookRental.Api.Models;
using BookRental.Api.Validation;

namespace BookRental.Api.Contracts;

public static class ContractMapping
{
    public static Book MapToBook(this CreateBookRequest request)
    {
        return new Book()
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Author = request.Author,
            ISBN = request.ISBN,
            Status = request.Status
        };
    }

    public static Book MapToBook(this UpdateBookRequest request, Guid id)
    {
        return new Book()
        {
            Id = id,
            Title = request.Title,
            Author = request.Author,
            ISBN = request.ISBN,
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

    public static ValidationFailureResponse MapToResponse(this ValidationFailed failed)
    {
        return new ValidationFailureResponse()
        {
            Errors = failed.Errors.Select(x => new ValidationFailureEntry()
            {
                PropertyName = x.PropertyName,
                Message = x.ErrorMessage
            })
        };
    }
}
