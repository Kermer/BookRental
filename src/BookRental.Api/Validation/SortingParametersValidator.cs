using BookRental.Api.Contracts.Requests.Parameters;
using FluentValidation;

namespace BookRental.Api.Validation;

public class SortingParametersValidator : AbstractValidator<SortingParameters>
{
    private static readonly string[] _validBookColumns;
    private static readonly string _validBookColumnsString;

    static SortingParametersValidator()
    {
        _validBookColumns = ["title", "author", "isbn", "status"];
        _validBookColumnsString = $"Valid book columns are: {string.Join(", ", _validBookColumns)}";
    }
    
    public SortingParametersValidator()
    {
        RuleFor(x => x.SortBy)
            .Must(BeAValidBookColumn)
            .WithMessage(_validBookColumnsString);
        
        RuleFor(x => x.SortOrder)
            .Must(BeDescOrAsc)
            .WithMessage("Sort order must be either 'desc' or 'asc'");
    }

    private static bool BeDescOrAsc(string value)
    {
        return value.ToLower() switch
        {
            "desc" => true,
            "asc" => true,
            _ => false
        };
    }

    private static bool BeAValidBookColumn(string value)
    {
        return _validBookColumns.Contains(value.ToLower());
    }
}