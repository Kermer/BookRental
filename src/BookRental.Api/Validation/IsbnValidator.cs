using BookRental.Api.Data;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BookRental.Api.Validation;

public interface IIsbnValidator : IValidator<string>
{ }

internal sealed class IsbnValidator : AbstractValidator<string>, IIsbnValidator
{
    public IsbnValidator()
    {
        RuleFor(x => x)
            .NotEmpty().WithMessage("ISBN cannot be empty")
            .Must(BeAValidISBN).WithMessage("Invalid ISBN format");
    }

    private bool BeAValidISBN(string isbn)
    {
        if (string.IsNullOrEmpty(isbn)) return false;

        isbn = isbn.Replace("-", "").Replace(" ", ""); // Remove hyphens and spaces

        // Validate ISBN-10
        if (isbn.Length == 10 && IsValidISBN10(isbn))
            return true;

        // Validate ISBN-13
        if (isbn.Length == 13 && IsValidISBN13(isbn))
            return true;

        return false;
    }

    private bool IsValidISBN10(string isbn10)
    {
        if (!Regex.IsMatch(isbn10, @"^\d{9}[\dXx]$")) return false;

        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += (isbn10[i] - '0') * (10 - i);
        }

        // Check if last character is 'X' (representing 10)
        char lastChar = isbn10[9];
        sum += lastChar == 'X' || lastChar == 'x' ? 10 : (lastChar - '0');

        return sum % 11 == 0;
    }

    private bool IsValidISBN13(string isbn13)
    {
        if (!Regex.IsMatch(isbn13, @"^\d{13}$")) return false;

        int sum = 0;
        for (int i = 0; i < 12; i++)
        {
            sum += (isbn13[i] - '0') * (i % 2 == 0 ? 1 : 3);
        }

        int checksum = (10 - (sum % 10)) % 10;
        return checksum == (isbn13[12] - '0');
    }
}
