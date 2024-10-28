using BookRental.Api.Contracts.Requests.Parameters;
using FluentValidation;

namespace BookRental.Api.Validation;

public class PaginationParametersValidator : AbstractValidator<PaginationParameters>
{
    public PaginationParametersValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.PerPage)
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(100);
    }
}