using BookRental.Api.Contracts;
using BookRental.Api.Contracts.Requests.Parameters;
using BookRental.Api.Extensions;
using BookRental.Api.Models;
using BookRental.Api.Validation;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace BookRental.Api.Data;

public interface IBookRepository
{
    Task<IEnumerable<Book>> Get(PaginationParameters paginationParams, SortingParameters sortingParams);
    Task<Book?> GetById(Guid id);

    Task<Result<Book, ValidationFailed>> Create(Book book);
    Task<Result<Book, ValidationFailed>> Update(Book book);
    Task<bool> Delete(Guid id);

    Task<int> SaveChangesAsync();
}

internal sealed class BookRepository : IBookRepository
{
    private readonly BookContext _context;
    private readonly IValidator<BookStatusChange> _statusChangeValidator;

    public BookRepository(BookContext context, IValidator<BookStatusChange> statusChangeValidator)
    {
        _context = context;
        _statusChangeValidator = statusChangeValidator;
    }

    public async Task<IEnumerable<Book>> Get(PaginationParameters paginationParams, SortingParameters sortingParams)
    {
        IQueryable<Book> query = _context.Books;
        query = ApplySorting(query, sortingParams.SortBy, sortingParams.SortOrder);
        query = ApplyPagination(query, paginationParams.Page, paginationParams.PerPage);

        return await query.ToListAsync();
    }

    public async Task<Book?> GetById(Guid id)
    {
        return await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
    }

    public async Task<Result<Book, ValidationFailed>> Create(Book book)
    {
        var bookWithSameIsbn = await GetByIsbn(book.ISBN);
        if (bookWithSameIsbn is not null)
        {
            var failure = new ValidationFailure(nameof(Book.ISBN), "Book with given ISBN number already exists in the database.", book.ISBN);
            return new ValidationFailed(failure);
        }

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<Result<Book, ValidationFailed>> Update(Book book)
    {
        var existingBook = await _context.Books.FindAsync(book.Id);
        if (existingBook is null)
        {
            // Caller (Controller) must ensure only update of existing book is attempted
            throw new InvalidOperationException("Book with given id does not exist.");
        }

        // Status change check
        var validationFailures = new List<ValidationFailure>();
        var statusChange = new BookStatusChange()
        {
            CurrentStatus = existingBook.Status,
            NewStatus = book.Status
        };
        var statusChangeValidationResult = _statusChangeValidator.Validate(statusChange);
        if (!statusChangeValidationResult.IsValid)
        {
            validationFailures.AddRange(statusChangeValidationResult.Errors);
        }

        // ISBN uniqueness check
        if (existingBook.ISBN != book.ISBN)
        {
            var bookWithSameIsbn = GetByIsbn(book.ISBN);
            if (bookWithSameIsbn is not null)
            {
                validationFailures.Add(new ValidationFailure(nameof(Book.ISBN), "Book with given ISBN number already exists in the database.", book.ISBN));
            }
        }

        if (validationFailures.Count > 0)
        {
            return new ValidationFailed(validationFailures[0]);
        }

        _context.Books.Update(book);
        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<bool> Delete(Guid id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book is null)
        {
            return false;
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    private async Task<Book?> GetByIsbn(string isbn)
    {
        return await _context.Books.FirstOrDefaultAsync(x => x.ISBN == isbn);
    }

    public static IQueryable<Book> ApplySorting(IQueryable<Book> query, string sortBy, string sortOrder)
    {
        if (string.IsNullOrWhiteSpace(sortBy))
        {
            return query;
        }

        var isDescending = sortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase);
        return sortBy.ToLower() switch
        {
            "title" => query.OrderBy(isDescending, x => x.Title),
            "author" => query.OrderBy(isDescending, x => x.Author),
            "isbn" => query.OrderBy(isDescending, x => x.ISBN),
            "status" => query.OrderBy(isDescending, x => x.Status),
            _ => throw new ArgumentOutOfRangeException(nameof(sortBy)),
        };
    }

    public static IQueryable<Book> ApplyPagination(IQueryable<Book> query, int pageNumber, int pageSize)
    {
        if (pageNumber < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber, "Page number cannot be lower than 1");
        }
        if (pageSize < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "Page size cannot be lower than 1");
        }
        return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
}
