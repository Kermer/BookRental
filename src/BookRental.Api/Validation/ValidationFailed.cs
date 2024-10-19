using FluentValidation.Results;

namespace BookRental.Api.Validation;

public record ValidationFailed(IEnumerable<ValidationFailure> Errors)
{
    public ValidationFailed(ValidationFailure error) : this([error])
    {
    }
}
