namespace BookRental.Api.Contracts.Responses;

public class ValidationFailureResponse
{
    public required IEnumerable<ValidationFailureEntry> Errors { get; init; }
}

public class ValidationFailureEntry
{
    public required string PropertyName { get; init; }
    public required string Message { get; init; }
}
