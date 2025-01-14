﻿using BookRental.Api.Models;
using FluentValidation;

namespace BookRental.Api.Validation;

internal sealed class BookValidator : AbstractValidator<Book>
{
    public BookValidator(IIsbnValidator isbnValidator)
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
