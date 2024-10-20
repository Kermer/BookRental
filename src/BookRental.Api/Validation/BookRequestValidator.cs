using BookRental.Api.Contracts.Requests;
using FluentValidation;

namespace BookRental.Api.Validation;

internal sealed class BookRequestValidator : AbstractValidator<CreateOrUpdateBookRequest>
{
    public BookRequestValidator(IIsbnValidator isbnValidator)
    {
        RuleFor(x => x.Title)
            .NotEmpty();

        RuleFor(x => x.Author)
            .NotEmpty();

        RuleFor(x => x.ISBN)
            .SetValidator(isbnValidator);

        RuleFor(x => x.Status)
            .IsInEnum();
    }
}
