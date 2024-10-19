using BookRental.Api.Models;
using FluentValidation;

namespace BookRental.Api.Validation;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
    }
}
