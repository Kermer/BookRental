using BookRental.Api.Models;
using BookRental.Api.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BookRental.Api.Data;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAll();
    Task<Book?> GetById(Guid id);

    Task<Result<Book, ValidationFailed>> Create(Book book);
    Task<Result<Book, ValidationFailed>> Update(Book book);
    Task<bool> Delete(Guid id);

    Task<int> SaveChangesAsync();
}

internal sealed class BookRepository : IBookRepository
{
    private readonly BookContext _context;
    private readonly IValidator<Book> _validator;

    public BookRepository(BookContext context, IValidator<Book> validator)
    {
        _context = context;
        _validator = validator;
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
        return await _context.Books.ToListAsync();
    }
    public async Task<Book?> GetById(Guid id)
    {
        return await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
    }

    public async Task<Result<Book, ValidationFailed>> Create(Book book)
    {
        var validationResult = await _validator.ValidateAsync(book);
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<Result<Book, ValidationFailed>> Update(Book book)
    {
        var validationResult = await _validator.ValidateAsync(book);
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }

        _context.Books.Update(book);
        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<bool> Delete(Guid id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
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
}
